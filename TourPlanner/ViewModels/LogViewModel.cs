using System.Collections.ObjectModel;
using TourPlanner.Models;

namespace TourPlanner.ViewModels {
    public class LogViewModel : BaseViewModel {
        private MainViewModel _mvm;
        private ListViewModel _lvm;

        public LogViewModel(MainViewModel mvm) {
            _mvm = mvm;
            
            TourLogs = new ObservableCollection<TourLog>();

            OpenTourLogWindowCommand = new DelegateCommand(
                o => true,
                o => {
                    var popup = new NewTourLogWindow();
                    popup.ShowDialog();
                }
                );
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
    }
}
