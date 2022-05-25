using System.Collections.ObjectModel;
using TourPlanner.Models;

namespace TourPlanner.ViewModels {
    public class LogViewModel : BaseViewModel {
        private MainViewModel _mvm;
        private ListViewModel _lvm;
        private EditTourLogViewModel _etlvm;

        public LogViewModel(MainViewModel mvm, EditTourLogViewModel etlvm) {
            _mvm = mvm;
            _etlvm = etlvm;
            
            TourLogs = new ObservableCollection<TourLog>();

            OpenTourLogWindowCommand = new DelegateCommand(
                o => true,
                o => {
                    var popup = new NewTourLogWindow();
                    popup.ShowDialog();
                }
                );

            DeleteTourLogCommand = new DelegateCommand(
                o => IsItemSelected(),
                (o) => {
                    _mvm.BL.DeleteTourLog(SelectedItem.Id);
                    TourLogs = _mvm.BL.GetTourLogs(SelectedItem.TourId);

                }
                );

            EditTourLogCommand = new DelegateCommand(
                o => IsItemSelected(),
                (o) => {

                    var popup = new EditTourLogWindow();
                    _etlvm.SelectedTourLog = SelectedItem;
                    _etlvm.Date = SelectedItem.Date;
                    _etlvm.Duration = SelectedItem.Duration;
                    _etlvm.Distance = SelectedItem.Distance;
                    _etlvm.Rating = SelectedItem.Rating;
                    _etlvm.Difficulty = SelectedItem.Difficulty;
                    _etlvm.Comment = SelectedItem.Comment;
                    popup.ShowDialog();

                }
                );

        }


        public bool IsItemSelected() {
            if (SelectedItem == null) {
                return false;
            }
            else {
                return true;
            }
        }


        private ObservableCollection<TourLog> _tourLogs;
        public ObservableCollection<TourLog> TourLogs {
            get {
                return _tourLogs;
            }
            set {
                if (_tourLogs != value) {
                    _tourLogs = value;
                    OnPropertyChanged();
                   
                }
            }
        }

        public DelegateCommand OpenTourLogWindowCommand { get; set; }
        public DelegateCommand EditTourLogCommand { get; set; }
        public DelegateCommand DeleteTourLogCommand { get; set; }


        private TourLog _selectedItem;
        public TourLog SelectedItem {
            get {
                return _selectedItem;
            }
            set {
                if (_selectedItem != value) {
                    _selectedItem = value;
                    OnPropertyChanged();
                    EditTourLogCommand.RaiseCanExecuteChanged();
                    DeleteTourLogCommand.RaiseCanExecuteChanged();



                }
            }
        }

    }
}
