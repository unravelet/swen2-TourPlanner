using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.ViewModels {
    public class DetailsViewModel : BaseViewModel{

        public DetailsViewModel() {
            Description = "this is a tour description jjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj";

            StartAddress = "Allerheiligenplatz";
            StartAddressNumber = "10";
            StartCity = "Wien";
            StartZip = "1200";
            StartCountry = "AT";

            EndAddress = "Höchstädtplatz";
            EndAddressNumber = "14";
            EndCity = "Wien";
            EndZip = "1200";
            EndCountry = "AT";


        }



        private string _description;
        public string Description {
            get => _description;

            set {
                if (_description != value) {
                    _description = value;
                    OnPropertyChanged();
                    
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
                    
                }
            }
        }
    }
}
