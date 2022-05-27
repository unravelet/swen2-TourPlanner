using System;
using System.Windows;
using TourPlanner.Models;

namespace TourPlanner.ViewModels {
    public class EditTourViewModel : BaseViewModel {
        private string _windowName = "EditTour";

        private MainViewModel _mvm;
        public EditTourViewModel(MainViewModel mvm) {
            _mvm = mvm;


            OKCommand = new DelegateCommand(
                o => CanUpdateTour(),
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

            //SelectedTour = new Tour("", "", "", "", "", "", "", "", "", "", "", Tour.transportType.car, "", "");
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


        private string _name;
        public string Name {
            get => _name;

            set {
                if (_name != value) {
                    _name = value;
                    OnPropertyChanged();
                    OKCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _description;
        public string Description {
            get => _description;

            set {
                if (_description != value) {
                    _description = value;
                    OnPropertyChanged();
                    OKCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private Tour _selectedTour;
        public Tour SelectedTour {
            get {
                return _selectedTour;
            }
            set {
                if (_selectedTour != value) {
                    _selectedTour = value;
                    OnPropertyChanged();
                    OKCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public void UpdateTour() {
            SelectedTour.Name = Name;
            SelectedTour.Description = Description;

            _mvm.BL.UpdateTour(SelectedTour);
        }

        private bool CanUpdateTour() {
            if (String.IsNullOrEmpty(Name)) {
                return false;
            }
            else {
                return true;
            }
        }


    }
}
