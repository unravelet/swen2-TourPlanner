using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.BL
{
    public class Businesslogic
    {
        public ObservableCollection<string> Tours { get; set; }

        public Businesslogic()
        {
            Tours = new();
        }

        public void AddTours()
        {
            Tours.Add("New Tour");
        }

        public bool CanAddTour()
        {
            if(Tours.Count() < 10)
            {
                return true;
            }
            return false;
        }
    }
}
