using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Models;

namespace TourPlanner.ViewModels {
    public class LogViewModel : BaseViewModel {

        public LogViewModel() {
            
            TourLog tourlog = new TourLog("ss","ss" , "hh", "2", "2", "2", "2", "rrr");
            TourLogs = new ObservableCollection<TourLog> { tourlog };

            OpenTourLogWindowCommand = new DelegateCommand(
                o => true,
                o => {
                    var popup = new NewTourLogWindow();
                    popup.ShowDialog();
                }
                );

        }

        public string Duration { get; set; }
        public ObservableCollection<TourLog> TourLogs { get; set; }

        public DelegateCommand OpenTourLogWindowCommand { get; set; }
    }
}
