using System.Collections.ObjectModel;
using TourPlanner.Models;

namespace TourPlanner.BL {
    public class Businesslogic {
        public ObservableCollection<string> Tours { get; set; }

        public Businesslogic() {
            Tours = new ObservableCollection<string>();
        }

        public void AddTours() {
            //Tour myTour = new Tour("new tour", "dummy tour", Guid.NewGuid().ToString(),4.3f, 3.2f, 1231.3f, 323.1f);

            //Tours.Add(myTour.Name);

            
        }

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

            Tour tour = new Tour(new Guid(), name, description, startAddress, startAddressNum, startZip, startCountry, endAddress, endAddressNum, endZip, endCountry);


            return tour;
        
        }

        public bool CanCreateTour(string name, string startAddress, string startAddressNum, string startZip, string startCountry,
            string endAddress, string endAddressNum, string endZip, string endCountry) {

            return !String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(startAddress) && !String.IsNullOrEmpty(startAddressNum) &&
                !String.IsNullOrEmpty(startZip) && !String.IsNullOrEmpty(startCountry) && !String.IsNullOrEmpty(endAddress) &&
                !String.IsNullOrEmpty(endAddressNum) && !String.IsNullOrEmpty(endZip) && !String.IsNullOrEmpty(endCountry);

        }


        
            
        
    }
}
