using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TourPlanner;

namespace TourPlanner.Test.Mocks {
    public class DummyViewModel : DummyBaseViewModel {
        string name;
        public string Name { 
            get { return name; } 
            set {
                if (name != value) { 
                    name = value;
                    OnPropertyChanged();
                }
            } 
        }

    }
}
