using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using TourPlanner.BL.Services;
using TourPlanner.DAL.DB;
using TourPlanner.DAL.Repositories;
using TourPlanner.Models;

namespace TourPlanner.BL {
    public class Businesslogic {
        
        private MapQuestService _mapQuestService;
        private ReportService _reportService;
        private UserInputService _userInputService;
        private Database _db;
        private TourRepository _tourRepo;
        private TourLogRepository _tourLogRepo;
        private ILoggerWrapper _logger;

        public ObservableCollection<Tour> TourCollection { get; set; }


        public Businesslogic(MapQuestService mqs, Database db, TourRepository trp, TourLogRepository tlrp, ReportService rs, UserInputService uis) {
            _db = db;
            _tourRepo = trp;
            _tourLogRepo = tlrp;

            _mapQuestService = mqs;

            _logger = LoggerFactory.GetLogger();
            _reportService = rs;
            _userInputService = uis;
        }

        public async void CreateTour(string name, string description, string startAddress, string startAddressNum, string startZip, string startCountry,
            string endAddress, string endAddressNum, string endZip, string endCountry, string transporttype, string startCity, string endCity) {

            Tour.transportType transp = (Tour.transportType)Enum.Parse(typeof(Tour.transportType), transporttype, true);

            Tour tour = new Tour(Guid.NewGuid().ToString(), name, description, startAddress, startAddressNum, startZip, startCountry, endAddress, endAddressNum,
                endZip, endCountry, transp, startCity, endCity);

            try
            {
                tour = await _mapQuestService.getTourData(tour);

                _mapQuestService.getStaticMap(tour);

                _tourRepo.Create(tour);
            }
            catch(Exception ex)
            {
                _logger.Warn($"Tour [Name:{tour.Name}] wasnt created exception: {ex.InnerException}");
                return;
            }

            _logger.Debug($"Created tour {tour.Id} at {DateTime.Now}");
        }

        public bool CanCreateTour(string name, string startAddress, string startAddressNum, string startZip, string startCountry,
            string endAddress, string endAddressNum, string endZip, string endCountry, string startCity, string endCity) {

            return !String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(startAddress) && !String.IsNullOrEmpty(startAddressNum) &&
                !String.IsNullOrEmpty(startZip) && !String.IsNullOrEmpty(startCountry) && !String.IsNullOrEmpty(endAddress) &&
                !String.IsNullOrEmpty(endAddressNum) && !String.IsNullOrEmpty(endZip) && !String.IsNullOrEmpty(endCountry) && !String.IsNullOrEmpty(startCity)
                && !String.IsNullOrEmpty(endCity);

        }
        public bool CanCreateTourLog(string date, string duration, string distance, string rating, string difficulty) {

            return !String.IsNullOrEmpty(date) && !String.IsNullOrEmpty(duration) && !String.IsNullOrEmpty(distance) &&
                !String.IsNullOrEmpty(rating) && !String.IsNullOrEmpty(difficulty);

        }



        public ObservableCollection<Tour> GetTourCollection() {
            
            return _tourRepo.ReadAll();
        }


        public void DeleteTour(string id) {
            _tourRepo.Delete(id);
        }

        public void DeleteTourLog(string id) {
            _tourLogRepo.Delete(id);
        }

        public void UpdateTour(Tour tour) {
            _tourRepo.Update(tour);
        }

        public void UpdateTourLog(TourLog tourlog) {
            _tourLogRepo.Update(tourlog);
        }

        public Tour FindTour(string id) {
            return _tourRepo.Read(id);
        }


        public void CreateTourLog(string tourId, string date, string duration, string distance, string rating, string difficulty, string comment) {

            TourLog tourLog = new TourLog(Guid.NewGuid().ToString(), tourId, date, duration, distance, rating, difficulty, comment);
            _tourLogRepo.Create(tourLog);
        }

        public ObservableCollection<TourLog> GetTourLogs(string tourId) {

            return _tourLogRepo.GetTourLogs(tourId);
        }

        
        public void SingleReport(Tour tour) {
            
            _reportService.GenerateSingleReport(tour, GetTourLogs(tour.Id));
        }

        public void TourSummary() {

            _reportService.GenerateSummary(GetTourCollection());
        }

        


    }
}
