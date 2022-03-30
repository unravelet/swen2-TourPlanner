using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using TourPlanner.BL;

namespace TourPlanner {
    public class MainViewModel : INotifyPropertyChanged {

        public MainViewModel() {
            Searchbar = "search...";
            Tours = new ObservableCollection<string>() { "tour1", "tour2" };

            AddTourCommand = new DelegateCommand(
                (o) => Tours.Count() < 5,
                (o) => { Tours.Add("New Tour"); }
                );

        }

        public string Searchbar { get; set; }

        public DelegateCommand AddTourCommand { get; set; }
        public ObservableCollection<string> Tours { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }


}
