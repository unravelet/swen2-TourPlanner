using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.ViewModels {
    public class NewTourViewModel : BaseViewModel {

        public NewTourViewModel() {

            CreateTourCommand = new DelegateCommand(
                o => true,
                o => {
                    Name = "hello";
                }
                );

        }


        public string Name { get; set; }
        public string Description { get; set; }
        public string StartAddress { get; set; }
        public string StartAddressNumber { get; set; }
        public string StartZip { get; set; }
        public string StartCountry { get; set; }

        
        public string EndAddress { get; set; }
        public string EndAddressNumber { get; set; }
        public string EndZip { get; set; }
        public string EndCountry { get; set; }

        public DelegateCommand CreateTourCommand { get; set; }



    }
}
