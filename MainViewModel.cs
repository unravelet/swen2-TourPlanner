using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swen2_TourPlanner
{
    public class MainViewModel
    {

        public MainViewModel()
        {
            Searchbar = "search...";
        }
        
        public string Searchbar { get; set; }
    }

    
}
