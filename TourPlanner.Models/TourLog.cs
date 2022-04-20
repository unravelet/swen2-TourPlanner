using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.Models {
    public class TourLog {
        public TourLog(string id, DateTime date, float duration, float distance, float rating, float difficulty, string comment) {
            Id = id;
            Date = date;
            Duration = duration;
            Distance = distance;
            Rating = rating;
            Difficulty = difficulty;
            Comment = comment;

        }

        public string Id { get; set; }
        public DateTime Date { get; set; }
        public float Duration { get; set; }
        public float Distance { get; set; }
        public float Rating { get; set; }
        public float Difficulty { get; set; }
        public string Comment { get; set; }
        

    }
}
