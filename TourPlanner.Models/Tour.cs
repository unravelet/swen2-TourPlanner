using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.Models {
    public class Tour {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string  Id { get; set; }
        public string Date { get; set; }
        public int Distance { get; set; }
        public int Duration { get; set; }
        
        public Tour(string name, string description, string id, string date, int distance, int duration) { 
        
            Name = name;
            Description = description;
            Id = id;
            Date = date;
            Distance = distance;
            Duration = duration;

        }

    }
}
