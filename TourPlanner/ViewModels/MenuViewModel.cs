using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Models;

namespace TourPlanner.ViewModels {
    public class MenuViewModel : BaseViewModel {
        private MainViewModel _mvm;
        public MenuViewModel(MainViewModel mvm)  {
            _mvm = mvm;

            SelectedReportCommand = new DelegateCommand(
                o => IsItemSelected(),
                o => _mvm.BL.SingleReport(_mvm.BL.FindTour(SelectedTour.Id))
                );

            AllReportCommand = new DelegateCommand(
                o => true,
                o => _mvm.BL.TourSummary()
                );

            ExportTourCommand = new DelegateCommand(
                o => true,
                o => _mvm.BL.ExportTour(SelectedTour)
                );
        }

        public DelegateCommand ImportCommand { get; set; }
        public DelegateCommand ExportTourCommand { get; set; }

        public DelegateCommand SelectedReportCommand { get; set; }
        public DelegateCommand AllReportCommand { get; set; }

        public bool IsItemSelected() {
            if (SelectedTour == null) {
                return false;
            }
            else {
                return true;
            }
        }

        private Tour _selectedTour;
        public Tour SelectedTour {
            get {
                return _selectedTour;
            }
            set {
                if (_selectedTour != value) {
                    _selectedTour = value;
                    OnPropertyChanged();

                    SelectedReportCommand.RaiseCanExecuteChanged();
                }
            }
        }
    }
}
