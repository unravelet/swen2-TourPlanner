using System.Collections.ObjectModel;
using System.ComponentModel;
using TourPlanner.BL;


namespace TourPlanner.ViewModels {
    public class MainViewModel : BaseViewModel {

        public MainViewModel(Businesslogic bl) {
            Searchbar = "search...";
            BL = bl;

            //Color = System.Windows.Media.Brushes.White;


            

            /*SetDarkMode = new DelegateCommand(
                o => true,
                o => { Color = System.Windows.Media.Brushes.Black; }
                );
            */
        }

        public string Searchbar { get; set; }

        public Businesslogic BL { get; set; }

        public DelegateCommand AddTourCommand { get; set; }
        public DelegateCommand SetLightMode { get; set; }
        public DelegateCommand SetDarkMode { get; set; }


        public DelegateCommand RemoveTourCommand { get; set; }  
        public ObservableCollection<string> Tours { get; set; }

        
        //public System.Windows.Media.SolidColorBrush Color { get; set; }
        /*public void DarkMode() {
            Color = System.Windows.Media.Brushes.Black;
        }
        */
        
    }


}
