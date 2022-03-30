using System.Collections.ObjectModel;
using TourPlanner.Models;

namespace TourPlanner.BL {
    public class Businesslogic {
        public ObservableCollection<string> Tours { get; set; }

        public Businesslogic() {
            Tours = new ObservableCollection<string>();
        }

        public void AddTours() {
            Tour myTour = new Tour("new tour", "hi");
            string tourName = myTour.Name;

            Tours.Add(tourName);

            
        }

        public bool CanAddTour() {
            if (Tours.Count() < 10) {
                return true;
            }
            return false;
        }

        public void RemoveTour() {
        }
    }
}
