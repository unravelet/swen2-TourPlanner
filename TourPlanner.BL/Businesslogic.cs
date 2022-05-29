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
        private ExportImportService _exportImportService;


        public Businesslogic(MapQuestService mqs, Database db, TourRepository trp, TourLogRepository tlrp, ReportService rs, UserInputService uis,
            ExportImportService eis) {
            _db = db;
            _tourRepo = trp;
            _tourLogRepo = tlrp;

            _mapQuestService = mqs;

            _logger = LoggerFactory.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            _reportService = rs;
            _userInputService = uis;
            _exportImportService = eis;
        }

        public async void CreateTour(string name, string description, string startAddress, string startAddressNum, string startZip, string startCountry,
            string endAddress, string endAddressNum, string endZip, string endCountry, string transporttype, string startCity, string endCity) {

            Tour.transportType transp = (Tour.transportType)Enum.Parse(typeof(Tour.transportType), transporttype, true);

            Tour tour = new Tour(Guid.NewGuid().ToString(), name, description, startAddress, startAddressNum, startZip, startCountry, endAddress, endAddressNum,
                endZip, endCountry, transp, startCity, endCity);

            try {
                tour = await _mapQuestService.getTourData(tour);

                _mapQuestService.getStaticMap(tour);

                _tourRepo.Create(tour);
            }
            catch(Exception ex)
            {
                _logger.Error($"Tour [Name:{tour.Name}] wasnt created exception: {ex.Message} stackinfo: {ex.InnerException}");
                return;
            }

            _logger.Debug($"Created tour {tour.Id} at {DateTime.Now}");
        }

        public bool CanCreateTour(string name, string startAddress, string startAddressNum, string startZip, string startCountry,
            string endAddress, string endAddressNum, string endZip, string endCountry, string startCity, string endCity) {

            return _userInputService.CanCreateTour(name, startAddress, startAddressNum, startZip, startCountry,
            endAddress, endAddressNum, endZip, endCountry, startCity, endCity);

        }
        public bool CanCreateTourLog(string date, string duration, string distance, string rating, string difficulty) {

            return _userInputService.CanCreateTourLog(date, duration, distance, rating, difficulty);

        }



        public ObservableCollection<Tour> GetTourCollection() {
            try
            {
                return _tourRepo.ReadAll();
            }
            catch(Exception ex)
            {
                _logger.Error($"Could not get tourcollection exception: {ex.Message} stackinfo: {ex.StackTrace}");
                return new ObservableCollection<Tour>();
            }
        }


        public void DeleteTour(string id) {
            try
            {
                _tourRepo.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.Error($"Could not delete tour [ID:{id}] exception: {ex.InnerException}");
            }
        }
        public void DeleteTourLog(string id) {
            try
            {
                _tourLogRepo.Delete(id);
            }
            catch(Exception ex)
            {
                _logger.Error($"Could not delete tourlog [ID:{id}] exception: {ex.InnerException}");
            }
        }

        public void UpdateTour(Tour tour) {
            try
            {
                _tourRepo.Update(tour);
            }
            catch(Exception ex)
            {
                _logger.Error($"Could not update tour [ID:{tour.Id}] exception: {ex.InnerException}");
            }
        }

        public void UpdateTourLog(TourLog tourlog) {
            try
            {
                _tourLogRepo.Update(tourlog);
            }
            catch(Exception ex)
            {
                _logger.Error($"Could not update tourlog for tour [ID:{tourlog.TourId}] exception: {ex.InnerException}");
            }
        }

        public Tour FindTour(string id) {
            try
            {
                return _tourRepo.Read(id);
            }
            catch(Exception ex)
            {
                _logger.Error($"Could not find tour [ID:{id}] exception: {ex.InnerException}");
                return new Tour("","","","","","","","","","","",Tour.transportType.car,"","");
            }
        }


        public void CreateTourLog(string tourId, string date, string duration, string distance, string rating, string difficulty, string comment) {

            TourLog tourLog = new TourLog(Guid.NewGuid().ToString(), tourId, date, duration, distance, rating, difficulty, comment);
            try
            {
                _tourLogRepo.Create(tourLog);
            }
            catch (Exception ex)
            {
                _logger.Error($"tourlog for Tour [ID:{tourId}] was not created exception: {ex.InnerException}");
            }
        }

        public ObservableCollection<TourLog> GetTourLogs(string tourId) {
            try
            {
                return _tourLogRepo.GetTourLogs(tourId);
            }
            catch(Exception ex)
            {
                _logger.Error($"Could not get tourlogs for tour [ID:{tourId}] exception: {ex.InnerException}");
                return new ObservableCollection<TourLog>();
            }
        }


        public void SingleReport(Tour tour) {

            _reportService.GenerateSingleReport(tour, GetTourLogs(tour.Id));
        }

        public void TourSummary() {

            _reportService.GenerateSummary(GetTourCollection());
        }

        public void ExportTour(Tour tour) {

            _exportImportService.ExportTour(tour);
        }

        public void ImportTour(string fileName) {
           
            _tourRepo.Create(_exportImportService.ImportTour(fileName)); 
        }

        

        public bool IsZip(string zip) {
            
            
            return _userInputService.IsZip(_userInputService.ParseInputToInt(zip));
        }

        public bool IsAddNum(string addNum) {
            return _userInputService.IsAddressNumber(_userInputService.ParseInputToInt(addNum));
        }

    }
}
