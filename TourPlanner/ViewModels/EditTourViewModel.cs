using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TourPlanner.ViewModels {
    public class EditTourViewModel : BaseViewModel {
        private string _windowName = "EditTour";

        private MainViewModel _mvm;
        private ListViewModel _lvm;
        public EditTourViewModel(MainViewModel mvm, ListViewModel lvm) {
            _mvm = mvm;
            _lvm = lvm;

            //TODO
            //name and desc doesnt update when opening window

            Name = _lvm.SelectedItem.Name;
            Description = _lvm.SelectedItem.Description;

            OKCommand = new DelegateCommand(
                o => true,
                o => {
                    UpdateTour();
                    CloseWindow();
                }
                );

            CancelCommand = new DelegateCommand(
                (o) => {
                    CloseWindow();
                }
            );

        }

        private string _name;
        public string Name {
            get { 
                return _name; 
            }
            set {
                if (_name != value) {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _description;
        public string Description {
            get {
                return _description;
            }
            set {
                if (_description != value) {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

        public DelegateCommand OKCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        public void CloseWindow() {
            foreach (Window window in Application.Current.Windows) {
                if (window.Name == _windowName) {
                    
                    window.Close();
                    
                }
            }
            
        }

        

        public void UpdateTour() {
            _lvm.SelectedItem.Name = Name;
            _lvm.SelectedItem.Description = Description;

            _mvm.BL.UpdateTour(_lvm.SelectedItem);
        }

       


    }
}
