namespace TourPlanner.Models {
    public class TourLog {
        
        public TourLog(string id, string tourId, string date, string duration, string distance, string rating, string difficulty, string comment) {
            Id = id;
            TourId = tourId;
            Date = date;
            Duration = duration;
            Distance = distance;
            Rating = rating;
            Difficulty = difficulty;
            Comment = comment;

        }

        public string Id { get; set; }
        public string TourId { get; set; }
        public string Date { get; set; }
        public string Duration { get; set; }
        public string Distance { get; set; }
        public string Rating { get; set; }
        public string Difficulty { get; set; }
        public string Comment { get; set; }


    }
}
