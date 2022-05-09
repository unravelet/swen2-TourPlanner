using System.Collections.ObjectModel;
using TourPlanner.Models;
using TourPlanner.DAL;
using TourPlanner.DAL.DB;
using TourPlanner.DAL.Repositories;

namespace TourPlanner.BL {
    public class Businesslogic {
        public ObservableCollection<string> Tours { get; set; }


        public Businesslogic() {
            Tours = new ObservableCollection<string>();

            //TODO
            //db configs in external file
            //_db = new Database("Host = localhost; Username = postgres; Password = KnautschgesichtmitDatenbank; Database = TPDB");
            _db = new Database("Host = localhost; Username = postgres; Password = 1234; Database = TPDB");
            _tourRepo = new TourRepository(_db);
            _tourLogRepo = new TourLogRepository(_db);


        }

        private Database _db;
        private TourRepository _tourRepo;
        private TourLogRepository _tourLogRepo;
        

        public bool CanAddTour() {
            if (Tours.Count() < 10) {
                return true;
            }
            return false;
        }

        


        public Tour CreateTour(string name, string description, string startAddress, string startAddressNum, string startZip, string startCountry,
            string endAddress, string endAddressNum, string endZip, string endCountry, string transporttype, string startCity, string endCity) {

            Tour.transportType transp = (Tour.transportType)Enum.Parse(typeof(Tour.transportType), transporttype, true);

            Tour tour = new Tour(Guid.NewGuid().ToString(), name, description, startAddress, startAddressNum, startZip, startCountry, endAddress, endAddressNum, 
                endZip, endCountry, transp, startCity, endCity);

            

            _tourRepo.Create(tour);

            return tour;
        
        }

        public bool CanCreateTour(string name, string startAddress, string startAddressNum, string startZip, string startCountry,
            string endAddress, string endAddressNum, string endZip, string endCountry) {

            return !String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(startAddress) && !String.IsNullOrEmpty(startAddressNum) &&
                !String.IsNullOrEmpty(startZip) && !String.IsNullOrEmpty(startCountry) && !String.IsNullOrEmpty(endAddress) &&
                !String.IsNullOrEmpty(endAddressNum) && !String.IsNullOrEmpty(endZip) && !String.IsNullOrEmpty(endCountry);

        }

        

        public ObservableCollection<Tour> GetTourCollection() {
            var tourList = new List<Tour>();
            tourList = _tourRepo.ReadAll();

            

            TourCollection = new ObservableCollection<Tour>();

            for (int i = 0; i < tourList.Count; i++) {
                TourCollection.Add(tourList[i]);
            }

            return TourCollection;
        }

        public ObservableCollection<Tour> TourCollection { get; set; }
        

        public void DeleteTour(string id) {
            _tourRepo.Delete(id);
        }

        public void UpdateTour(Tour tour) { 
            _tourRepo.Update(tour);
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
        

    }
}
