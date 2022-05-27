using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.ViewModels {
    public class RouteViewModel : BaseViewModel {

        public RouteViewModel() {
            
        }

        private string _source;
        public string Source {
            get { return _source; }
            set {
                if (_source != value) {
                    _source = value;
                    OnPropertyChanged();
                }



            }
        }
    }
}
