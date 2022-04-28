using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.ViewModels {
    public class NewTourViewModel : BaseViewModel {

        public NewTourViewModel(MainViewModel mvm) {

            CreateTourCommand = new DelegateCommand(
                (o) => mvm.BL.CanCreateTour(Name, StartAddress, StartAddressNumber, StartZip, StartCountry, 
                    EndAddress, EndAddressNumber, EndZip, EndCountry)
                ,
                (window) => {
                    var win = (NewTourWindow)window;
                    /*mvm.BL.CreateTour(win.TourName.Text, win.TourDescription.Text, win.StartAddress.Text, win.StartAddressNumber.Text, win.StartZip.Text,
                        win.StartCountry.Text, win.EndAddress.Text, win.EndAddressNumber.Text, win.EndZip.Text, win.EndCountry.Text);
                    */
                    mvm.BL.CreateTour(Name, Description, StartAddress, StartAddressNumber, StartZip, StartCountry,
                    EndAddress, EndAddressNumber, EndZip, EndCountry);

                    SetEmpty();

                    win.Close();
                }
                );

            CancelCommand = new DelegateCommand(
                
                (window) => {
                    var win = (NewTourWindow)window;
                    win.Close();
                }
                );

        }



        public void SetEmpty() {
            Name = "";
            Description = "";
            StartAddress = "";
            StartAddressNumber = "";
            StartZip = "";
            StartCountry = "";
            EndAddress = "";
            EndAddressNumber = "";
            EndZip = "";
            EndCountry = "";
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
