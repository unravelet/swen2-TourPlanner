using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static TourPlanner.NewTourWindow;
using TourPlanner.Models;

namespace TourPlanner.ViewModels {
    public class NewTourViewModel : BaseViewModel {

        private string _windowName = "NewTour";
        private MainViewModel _mvm;
        private ListViewModel _lvm;

        public NewTourViewModel(MainViewModel mvm, ListViewModel lvm) {
            _mvm = mvm;
            _lvm = lvm;
            

            CreateTourCommand = new DelegateCommand(
                (o) => _mvm.BL.CanCreateTour(Name, StartAddress, StartAddressNumber, StartZip, StartCountry,
                    EndAddress, EndAddressNumber, EndZip, EndCountry, StartCity, EndCity)
                ,
                (o) => {
                    //Window win = Application.Current.Windows[2];
                    if (Description == null) {
                        Description = "";
                    }
                    _mvm.BL.CreateTour(Name, Description, StartAddress, StartAddressNumber, StartZip, StartCountry,
                    EndAddress, EndAddressNumber, EndZip, EndCountry, CurrentItem, StartCity, EndCity);

                    //trigger for "live update"
                    _lvm.TourCollection = _mvm.BL.GetTourCollection();

                    CloseWindow();
                }
            );

            CancelCommand = new DelegateCommand(
                (o) => {
                    CloseWindow();
                }
            );

            SetTransportTypes();

        }

        public void CloseWindow() {
            foreach (Window window in Application.Current.Windows) {
                if (window.Name == _windowName) {
                    window.Close();
                }
            }
            SetEmpty();
        }


        public void SetEmpty() {
            Name = "";
            Description = "";
            StartAddress = "";
            StartAddressNumber = "";
            StartZip = "";
            StartCity = "";
            StartCountry = "";
            EndAddress = "";
            EndAddressNumber = "";
            EndZip = "";
            EndCity = "";
            EndCountry = "";
            CurrentItem = AllItems[0];
        }

        private void SetTransportTypes() {
            AllItems = new ObservableCollection<string>();
            AllItems.Add("Car");
            AllItems.Add("Bicycle");
            AllItems.Add("Walking");

            CurrentItem = AllItems[0];
        }

        public ObservableCollection<string> AllItems { get; set; }
        
       
        private string _currentItem;
        public string CurrentItem {
            get => _currentItem;

            set {
                if (_currentItem != value) {
                    _currentItem = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public DelegateCommand CreateTourCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        private string _name;
        public string Name {
            get => _name;

            set {
                if (_name != value) {
                    _name = value;
                    OnPropertyChanged();
                    CreateTourCommand.RaiseCanExecuteChanged();
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
                    CreateTourCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _startCity;
        public string StartCity {
            get => _startCity;

            set {
                if (_startCity != value) {
                    _startCity = value;
                    OnPropertyChanged();
                    CreateTourCommand.RaiseCanExecuteChanged();
                }
            }
        }



        string _startAddress;
        public string StartAddress {
            get => _startAddress;

            set {
                if (_startAddress != value) {
                    _startAddress = value;
                    OnPropertyChanged();
                    CreateTourCommand.RaiseCanExecuteChanged();
                }
            }
        }
    

        string _startAddressNumber;
        public string StartAddressNumber {
            get => _startAddressNumber;

            set {
                if (_startAddressNumber != value) {
                    _startAddressNumber = value;
                    OnPropertyChanged();
                    CreateTourCommand.RaiseCanExecuteChanged();
                }
            }
        }

        string _startZip;
        public string StartZip {
            get => _startZip;

            set {
                if (_startZip != value) {
                    _startZip = value;
                    OnPropertyChanged();
                    CreateTourCommand.RaiseCanExecuteChanged();
                }
            }
        }
        
        string _startCountry;
        public string StartCountry {
            get => _startCountry;

            set {
                if (_startCountry != value) {
                    _startCountry = value;
                    OnPropertyChanged();
                    CreateTourCommand.RaiseCanExecuteChanged();
                }
            }

        }
        private string _endCity;
        public string EndCity {
            get => _endCity;

            set {
                if (_endCity != value) {
                    _endCity = value;
                    OnPropertyChanged();
                    CreateTourCommand.RaiseCanExecuteChanged();
                }
            }
        }


        string _endAddress;
        public string EndAddress {
            get => _endAddress;

            set {
                if (_endAddress != value) {
                    _endAddress = value;
                    OnPropertyChanged();
                    CreateTourCommand.RaiseCanExecuteChanged();
                }
            }

        }
        string _endAddressNumber;
        public string EndAddressNumber {
            get => _endAddressNumber;

            set {
                if (_endAddressNumber != value) {
                    _endAddressNumber = value;
                    OnPropertyChanged();
                    CreateTourCommand.RaiseCanExecuteChanged();
                }
            }

        }
        string _endZip;
        public string EndZip {
            get => _endZip;

            set {
                if (_endZip != value) {
                    _endZip = value;
                    OnPropertyChanged();
                    CreateTourCommand.RaiseCanExecuteChanged();
                }
            }
        }
        string _endCountry;
        public string EndCountry {
            get => _endCountry;

            set {
                if (_endCountry != value) {
                    _endCountry = value;
                    OnPropertyChanged();
                    CreateTourCommand.RaiseCanExecuteChanged();
                }
            }
        }


        



    }
}
