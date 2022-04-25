using System.Collections.ObjectModel;
using TourPlanner.Models;

namespace TourPlanner.BL {
    public class Businesslogic {
        public ObservableCollection<string> Tours { get; set; }

        public Businesslogic() {
            Tours = new ObservableCollection<string>();
        }

        public void AddTours() {
            Tour myTour = new Tour("new tour", "dummy tour", Guid.NewGuid().ToString(),4.3f, 3.2f, 1231.3f, 323.1f);

            Tours.Add(myTour.Name);

            
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
