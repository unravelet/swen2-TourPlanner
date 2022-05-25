using System;
using System.Windows;
using TourPlanner.Models;

namespace TourPlanner.ViewModels {
    public class EditTourLogViewModel : BaseViewModel {
        private string _windowName = "EditTourLog";

        private MainViewModel _mvm;
        public EditTourLogViewModel(MainViewModel mvm) {
            _mvm = mvm;


            OKCommand = new DelegateCommand(
                o => CanUpdateTourLog(),
                o => {
                    UpdateTourLog();
                    CloseWindow();
                }
                );

            CancelCommand = new DelegateCommand(
                (o) => {
                    CloseWindow();
                }
            );

            SelectedTourLog = new TourLog("", "", "", "", "", "", "", "");
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

        private TourLog _selectedTourLog;
        public TourLog SelectedTourLog {
            get {
                return _selectedTourLog;
            }
            set {
                if (_selectedTourLog != value) {
                    _selectedTourLog = value;
                    OnPropertyChanged();
                    OKCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public void UpdateTourLog() {
            SelectedTourLog.Date = Date;
            SelectedTourLog.Duration = Duration;
            SelectedTourLog.Distance = Distance;
            SelectedTourLog.Rating = Rating;
            SelectedTourLog.Difficulty = Difficulty;
            SelectedTourLog.Comment = Comment;

            _mvm.BL.UpdateTourLog(SelectedTourLog);
        }

        private bool CanUpdateTourLog() {
            if (String.IsNullOrEmpty(Date) || String.IsNullOrEmpty(Duration) || String.IsNullOrEmpty(Distance) ||
                String.IsNullOrEmpty(Rating) || String.IsNullOrEmpty(Difficulty) || String.IsNullOrEmpty(Comment)) {
                return false;
            }
            else {
                return true;
            }
        }

        private string _date;
        public string Date {
            get => _date;

            set {
                if (_date != value) {
                    _date = value;
                    OnPropertyChanged();
                    OKCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _duration;
        public string Duration {
            get => _duration;

            set {
                if (_duration != value) {
                    _duration = value;
                    OnPropertyChanged();
                    OKCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _distance;
        public string Distance {
            get => _distance;

            set {
                if (_distance != value) {
                    _distance = value;
                    OnPropertyChanged();
                    OKCommand.RaiseCanExecuteChanged();
                }
            }
        }


        private string _rating;
        public string Rating {
            get => _rating;

            set {
                if (_rating != value) {
                    _rating = value;
                    OnPropertyChanged();
                    OKCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _diffculty;
        public string Difficulty {
            get => _diffculty;

            set {
                if (_diffculty != value) {
                    _diffculty = value;
                    OnPropertyChanged();
                    OKCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _comment;
        public string Comment {
            get => _comment;

            set {
                if (_comment != value) {
                    _comment = value;
                    OnPropertyChanged();
                    OKCommand.RaiseCanExecuteChanged();
                }
            }
        }




    }
}
