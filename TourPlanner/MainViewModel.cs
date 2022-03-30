using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using TourPlanner.Models;
using TourPlanner.BL;

namespace TourPlanner {
    public class MainViewModel : INotifyPropertyChanged {

        public MainViewModel(Businesslogic bl) {
            Searchbar = "search...";
            BL = bl;

            AddTourCommand = new DelegateCommand(
                (o) => BL.CanAddTour() ,
                (o) =>  BL.AddTours() 
                );

        }

        
        public string Searchbar { get; set; }

        public Businesslogic BL { get; set; }
        public DelegateCommand AddTourCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }


}
