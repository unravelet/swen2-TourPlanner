using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Models;

namespace TourPlanner.ViewModels {
    public class ListViewModel : BaseViewModel {

        //problems:
        //deleteTour deletes first duplicate, not selected item -> maybe unique names, or find a way to make them objects maybe
        //list doesnt update on runtime



        public ListViewModel(MainViewModel mvm)  {


            _mvm = mvm;
            
            ShowTourList();


            OpenTourWindowCommand = new DelegateCommand(
                o => true,
                o => {
                    var popup = new NewTourWindow();
                    popup.ShowDialog();
                }
                
                );

            

            DeleteTourCommand = new DelegateCommand(
                o => true,
                (o) => {
                    TourCollection.Remove(SelectedItem);
                }
                );

        }

        public Tour SelectedItem { get; set; }
       
       // public DelegateCommand OpenTourWindowCommand { get; set; } 
        //public RelayCommand AddTourCommand { get; set; } 
        public DelegateCommand AddTourCommand { get; set; }

        public DelegateCommand OpenTourWindowCommand { get; set; }
        public DelegateCommand DeleteTourCommand { get; set; }

        public MainViewModel _mvm;

        /*private ObservableCollection<string> _tours;
        public ObservableCollection<string> Tours {
            get { return _tours; }
            set {
                if (_tours != value) {
                    _tours = value;
                    //TODO
                    //tour list not updating at runtime
                    OnPropertyChanged("Tours");
                }
            }
        }
        */

        private ObservableCollection<Tour> _tourCollection;
        public ObservableCollection<Tour> TourCollection {
            get {
                return _tourCollection;
            }
            set {
                if (_tourCollection != value) {
                    _tourCollection = value;
                    //OnPropertyChanged();
                }
            }
        }

        public void ShowTourList() {
            TourCollection = _mvm.BL.GetTourCollection();
        }

    }
}
