using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.Models {
    public class Tour {
        
        public string Name { get; set; }
        public string Description { get; set; }
        
        public Tour(string name, string description) { 
        
            Name = name;
            Description = description;
        }

    }
}
