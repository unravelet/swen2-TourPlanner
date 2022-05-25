using System.Collections.ObjectModel;
using TourPlanner.Models;

namespace TourPlanner.ViewModels {
    public class ListViewModel : BaseViewModel {
        private MainViewModel _mvm;
        private LogViewModel _logvm;
        private EditTourViewModel _etvm;
        public ListViewModel(MainViewModel mvm, LogViewModel logvm, EditTourViewModel etvm) {
            _mvm = mvm;
            _logvm = logvm;
            _etvm = etvm;

            ShowTourList();

            OpenTourWindowCommand = new DelegateCommand(
                o => true,
                o => {
                    var popup = new NewTourWindow();
                    popup.ShowDialog();
                }
                );

            DeleteTourCommand = new DelegateCommand(
                o => IsItemSelected(),
                (o) => {
                    _mvm.BL.DeleteTour(SelectedItem.Id);
                    TourCollection = _mvm.BL.GetTourCollection();

                }
                );

            EditTourCommand = new DelegateCommand(
                o => IsItemSelected(),
                (o) => {

                    var popup = new EditTourWindow();
                    _etvm.SelectedTour = SelectedItem;
                    _etvm.Name = SelectedItem.Name;
                    _etvm.Description = SelectedItem.Description;
                    popup.ShowDialog();

                }
                );

        }
        private Tour _selectedItem;
        public Tour SelectedItem {
            get {
                return _selectedItem;
            }
            set {
                if (_selectedItem != value) {
                    _selectedItem = value;
                    OnPropertyChanged();
                    EditTourCommand.RaiseCanExecuteChanged();
                    DeleteTourCommand.RaiseCanExecuteChanged();

                    if (_selectedItem != null) {
                        _logvm.TourLogs = _mvm.BL.GetTourLogs(_selectedItem.Id);
                    }


                }
            }
        }
        public DelegateCommand AddTourCommand { get; set; }
        public DelegateCommand OpenTourWindowCommand { get; set; }
        public DelegateCommand DeleteTourCommand { get; set; }
        public DelegateCommand EditTourCommand { get; set; }

        private ObservableCollection<Tour> _tourCollection;
        public ObservableCollection<Tour> TourCollection {
            get {
                return _tourCollection;
            }
            set {
                if (_tourCollection != value) {
                    _tourCollection = value;
                    OnPropertyChanged();

                }
            }
        }

        public void ShowTourList() {
            TourCollection = _mvm.BL.GetTourCollection();
        }

        public bool IsItemSelected() {
            if (SelectedItem == null) {
                return false;
            }
            else {
                return true;
            }
        }

    }
}
