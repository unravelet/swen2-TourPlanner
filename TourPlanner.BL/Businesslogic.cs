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


        }

        public Database _db;
        public TourRepository _tourRepo;
        

        public bool CanAddTour() {
            if (Tours.Count() < 10) {
                return true;
            }
            return false;
        }

        public void RemoveTour() {

        }




        private Tour _tour;

        public Tour CreateTour(string name, string description, string startAddress, string startAddressNum, string startZip, string startCountry,
            string endAddress, string endAddressNum, string endZip, string endCountry) {

            Tour tour = new Tour(Guid.NewGuid().ToString(), name, description, startAddress, startAddressNum, startZip, startCountry, endAddress, endAddressNum, endZip, endCountry);

            _tourRepo.Create(tour);

            return tour;
        
        }

        public bool CanCreateTour(string name, string startAddress, string startAddressNum, string startZip, string startCountry,
            string endAddress, string endAddressNum, string endZip, string endCountry) {

            return !String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(startAddress) && !String.IsNullOrEmpty(startAddressNum) &&
                !String.IsNullOrEmpty(startZip) && !String.IsNullOrEmpty(startCountry) && !String.IsNullOrEmpty(endAddress) &&
                !String.IsNullOrEmpty(endAddressNum) && !String.IsNullOrEmpty(endZip) && !String.IsNullOrEmpty(endCountry);

        }

        public ObservableCollection<string> GetTourList() {
            var tourList = new List<Tour>();
            tourList = _tourRepo.ReadAll();
            TourList = new ObservableCollection<Tour>();

            for (int i = 0; i < tourList.Count; i++) {
                Tours.Add(tourList[i].Name);
                //TourList.Add(tourList[i]);
            }

            return Tours;
            //return TourList;
        }

        public ObservableCollection<Tour> GetTourCollection() {
            var tourList = new List<Tour>();
            tourList = _tourRepo.ReadAll();
            TourList = new ObservableCollection<Tour>();

            for (int i = 0; i < tourList.Count; i++) {
                //Tours.Add(tourList[i].Name);
                TourList.Add(tourList[i]);
            }

            //return Tours;
            return TourList;
        }

        public ObservableCollection<Tour> TourList { get; set; }
        




    }
}
