namespace TourPlanner.Models {
    public class Tour {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartCity { get; set; }
        public string StartAddress { get; set; }
        public string StartAddressNum { get; set; }
        public string StartZip { get; set; }
        public string StartCountry { get; set; }
        public string EndCity { get; set; }
        public string EndAddress { get; set; }
        public string EndAddressNum { get; set; }
        public string EndZip { get; set; }
        public string EndCountry { get; set; }

        public enum transportType {
            car,
            bicycle,
            walking
        }

        public transportType TransportType { get; set; }

        public float Distance { get; set; }
        public float Duration { get; set; }
        public string ?StartLng { get; set; }
        public string ?StartLat { get; set; }
        public string ?EndLng { get; set; }
        public string ?EndLat { get; set; }

        public Tour(string id, string name, string description, string startAddress, string startAddressNum, string startZip, string startCountry,
            string endAddress, string endAddressNum, string endZip, string endCountry, transportType transportType, string startCity, string endCity) {

            Id = id;
            Name = name;
            Description = description;

            StartAddress = startAddress;
            StartAddressNum = startAddressNum;
            StartZip = startZip;
            StartCountry = startCountry;

            EndAddress = endAddress;
            EndAddressNum = endAddressNum;
            EndZip = endZip;
            EndCountry = endCountry;

            TransportType = transportType;

            StartCity = startCity;
            EndCity = endCity;


        }

    }
}
