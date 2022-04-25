using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.ViewModels {
    public class ListViewModel : BaseViewModel {

        public ListViewModel()  {

            OpenTourWindowCommand = new DelegateCommand(
               (o) => true,
               (o) => {
                   var popup = new NewTourWindow();
                   popup.ShowDialog();
               
               }) ;
            

        }
       
        public DelegateCommand OpenTourWindowCommand { get; set; } 

    }
}
