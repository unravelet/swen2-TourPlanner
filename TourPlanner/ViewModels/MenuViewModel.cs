using Microsoft.Win32;
using System.IO;
using TourPlanner.Models;

namespace TourPlanner.ViewModels {
    public class MenuViewModel : BaseViewModel {
        private MainViewModel _mvm;
        public MenuViewModel(MainViewModel mvm) {
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
                o => IsItemSelected(),
                o => _mvm.BL.ExportTour(SelectedTour)
                );

            ImportTourCommand = new DelegateCommand(
                o => true,
                o => _mvm.BL.ImportTour(OpenFile())
                );
        }

        public DelegateCommand ImportTourCommand { get; set; }
        public DelegateCommand ExportTourCommand { get; set; }

        public DelegateCommand SelectedReportCommand { get; set; }
        public DelegateCommand AllReportCommand { get; set; }

        private string OpenFile() {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true) {
                return File.ReadAllText(openFileDialog.FileName);
            }
            else {
                return null;
            }
        }


        private bool IsItemSelected() {
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
