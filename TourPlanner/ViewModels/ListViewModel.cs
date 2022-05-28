using System;
using System.Collections.ObjectModel;
using TourPlanner.Models;

namespace TourPlanner.ViewModels {
    public class ListViewModel : BaseViewModel {
        private MainViewModel _mvm;
        private LogViewModel _logvm;
        private EditTourViewModel _etvm;
        private TourViewModel _tvm;
        private DetailsViewModel _detailsvm;
        private RouteViewModel _routevm;
        private MenuViewModel _menuvm;
        public ListViewModel(MainViewModel mvm, LogViewModel logvm, EditTourViewModel etvm, TourViewModel tvm,
            DetailsViewModel dvm, RouteViewModel rvm, MenuViewModel menuvm) {
            _mvm = mvm;
            _logvm = logvm;
            _etvm = etvm;
            _tvm = tvm;
            _detailsvm = dvm;
            _routevm = rvm;
            _menuvm = menuvm;

            ShowTourList();
            if (_selectedItem != null) {
                SetProperties();
            }

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

            UpdateCommand = new DelegateCommand(
                o => true,
                o => {
                    TourCollection = _mvm.BL.GetTourCollection();
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
                        SetProperties();
                    }


                }
            }
        }
        public DelegateCommand AddTourCommand { get; set; }
        public DelegateCommand OpenTourWindowCommand { get; set; }
        public DelegateCommand DeleteTourCommand { get; set; }
        public DelegateCommand EditTourCommand { get; set; }
        public DelegateCommand UpdateCommand { get; set; }

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

        public void SetProperties() {
            _logvm.TourLogs = _mvm.BL.GetTourLogs(_selectedItem.Id);
            _tvm.Name = _selectedItem.Name;

            _detailsvm.Description = _selectedItem.Description;
            _detailsvm.StartAddress = _selectedItem.StartAddress;
            _detailsvm.StartAddressNumber = _selectedItem.StartAddressNum;
            _detailsvm.StartCity = _selectedItem.StartCity;
            _detailsvm.StartZip = _selectedItem.StartZip;
            _detailsvm.StartCountry = _selectedItem.StartCountry;

            _detailsvm.EndAddress = _selectedItem.EndAddress;
            _detailsvm.EndAddressNumber = _selectedItem.EndAddressNum;
            _detailsvm.EndCity = _selectedItem.EndCity;
            _detailsvm.EndZip = _selectedItem.EndZip;
            _detailsvm.EndCountry = _selectedItem.EndCountry;


            _routevm.Source = $"{Environment.CurrentDirectory}" + $"/img/{_selectedItem.Id}.jpg";

            _menuvm.SelectedTour = SelectedItem;
        }

    }
}
