using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.ViewModels {
    public class ListViewModel : BaseViewModel {

        public ListViewModel(MainViewModel mvm)  {


            _mvm = mvm;
            /* OpenTourWindowCommand = new DelegateCommand(
                (o) => true,
                (o) => {
                    var popup = new NewTourWindow();
                    popup.ShowDialog();

                }) ;
            */


            /* AddTourCommand = new RelayCommand(
                      (o) => mvm.BL.AddTours(),
                      (o) => true
                      );
            */


            OpenTourWindowCommand = new RelayCommand(
                o => {
                    var popup = new NewTourWindow();
                    popup.ShowDialog();
                },
                o => true
                );

            AddTourCommand = new DelegateCommand(
                    (o) => _mvm.BL.CanAddTour(),
                    (o) => _mvm.BL.AddTours()
                    );


        }
       
       // public DelegateCommand OpenTourWindowCommand { get; set; } 
        //public RelayCommand AddTourCommand { get; set; } 
        public DelegateCommand AddTourCommand { get; set; }

        public RelayCommand OpenTourWindowCommand { get; set; }

        public MainViewModel _mvm;

    }
}
