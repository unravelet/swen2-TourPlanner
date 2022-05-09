using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TourPlanner.ViewModels {
    public class NewTourLogViewModel : BaseViewModel{
        private string _windowName = "NewTourLog";
        private MainViewModel _mvm;
        private LogViewModel _logvm;
        private ListViewModel _listvm;
        public NewTourLogViewModel(MainViewModel mvm, LogViewModel logvm, ListViewModel listvm) {
            _mvm = mvm;
            _logvm = logvm;
            _listvm = listvm;

            CreateTourLogCommand = new DelegateCommand(
                (o) => true
                ,
                (o) => {
                    _mvm.BL.CreateTourLog(_listvm.SelectedItem.Id, Date, Duration, Distance, Rating, Difficulty, Comment);
                    //update on runtime
                    _logvm.TourLogs = _mvm.BL.GetTourLogs(_listvm.SelectedItem.Id);
                    CloseWindow();
                }
            );

            CancelCommand = new DelegateCommand(
                (o) => {
                    CloseWindow();
                }
            );

        }

        public DelegateCommand CreateTourLogCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        public void CloseWindow() {
            foreach (Window window in Application.Current.Windows) {
                if (window.Name == _windowName) {
                    window.Close();
                }
            }
            SetEmpty();
        }


        public void SetEmpty() {
            Date = "";
            Duration = "";
            Distance = "";
            Rating = "";
            Difficulty = "";
            Comment = "";
        }


        private string _date;
        public string Date {
            get { return _date; }
            set {
                if (_date != value) { 
                    _date = value;
                    OnPropertyChanged();
                    CreateTourLogCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _duration;
        public string Duration {
            get { return _duration; }
            set {
                if (_duration != value) {
                    _duration = value;
                    OnPropertyChanged();
                    CreateTourLogCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _distance;
        public string Distance {
            get { return _distance; }
            set {
                if (_distance != value) {
                    _distance = value;
                    OnPropertyChanged();
                    CreateTourLogCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _rating;
        public string Rating {
            get { return _rating; }
            set {
                if (_rating != value) {
                    _rating = value;
                    OnPropertyChanged();
                    CreateTourLogCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _difficulty;
        public string Difficulty {
            get { return _difficulty; }
            set {
                if (_difficulty != value) {
                    _difficulty = value;
                    OnPropertyChanged();
                    CreateTourLogCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _comment;
        public string Comment {
            get { return _comment; }
            set {
                if (_comment != value) {
                    _comment = value;
                    OnPropertyChanged();
                    CreateTourLogCommand.RaiseCanExecuteChanged();
                }
            }
        }

    }
}
