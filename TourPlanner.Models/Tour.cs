using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.Models {
    public class Tour {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Distance { get; set; }
        public float Duration { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        
        public Tour(string name, string description, string id, float distance, float duration, float latitude, float longitude) { 
        
            Name = name;
            Description = description;
            Id = id;
            Distance = distance;
            Duration = duration;
            Longitude = longitude;
            Latitude = latitude;

        }

    }
}
