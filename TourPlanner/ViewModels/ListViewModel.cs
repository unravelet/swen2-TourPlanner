using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Models;

namespace TourPlanner.ViewModels {
    public class ListViewModel : BaseViewModel {
        public MainViewModel _mvm;
        public ListViewModel(MainViewModel mvm)  {
            _mvm = mvm;
            
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
