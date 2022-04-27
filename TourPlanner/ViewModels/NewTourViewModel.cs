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
                (window) => {
                   
                    


                    //closing works 
                    var win = (NewTourWindow)window;

                    Name = win.TourName.Text;
                    Description = win.TourDescription.Text;

                    //givetoBL (tourname.text,....)
                    win.Close();
                }
                );

        }

        private string _name;
        public string Name {
            get => _name;

            set {
                if (_name != value) {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _description;
        public string Description {
            get => _description;

            set {
                if (_description != value) {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }
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
