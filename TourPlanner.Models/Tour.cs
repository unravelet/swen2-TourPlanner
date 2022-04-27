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
        public string StartAddress { get; set; }
        public string StartAddressNum { get; set; }
        public string StartZip { get; set; }
        public string StartCountry { get; set; }
        public string EndAddress { get; set; }
        public string EndAddressNum { get; set; }
        public string EndZip { get; set; }
        public string EndCountry { get; set; }


        public float Distance { get; set; }
        public float Duration { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        
        public Tour(Guid id, string name, string description, string startAddress, string startAddressNum, string startZip, string startCountry,
            string endAddress, string endAddressNum, string endZip, string endCountry) {

            Id = id.ToString();
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



        }

    }
}
