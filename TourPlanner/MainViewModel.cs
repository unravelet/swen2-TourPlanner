using System.Collections.ObjectModel;
using System.ComponentModel;
using TourPlanner.BL;

namespace TourPlanner {
    public class MainViewModel : INotifyPropertyChanged {

        public MainViewModel() { }
        public MainViewModel(Businesslogic bl) {
            Searchbar = "search...";
            BL = bl;

            AddTourCommand = new DelegateCommand(
                (o) => BL.CanAddTour(),
                (o) => BL.AddTours()
                );           
        }

        public string Searchbar { get; set; }

        public Businesslogic BL { get; set; }

        public DelegateCommand AddTourCommand { get; set; }

        public DelegateCommand RemoveTourCommand { get; set; }  
        public ObservableCollection<string> Tours { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }


}
