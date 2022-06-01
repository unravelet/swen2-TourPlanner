using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.BL.Services {
    public class UserInputService {

        
        public UserInputService() { }


        public int Num { get; private set; }
        

        public bool IsInputInt(string input) {

            if (int.TryParse(input, out int n)) {
                Num = n;
                return true;
            }
            else {
                Num = 0;
                return false;
            }
        }

        public int ParseInputToInt(string input) {
            if (int.TryParse(input, out int n)) {
                return n;
            }
            else {
                return 0;
            }
        }


        public bool IsAddressNumber(int num) {
            //worlds highest address number
            if(num <= 986039 && num >= 1) {
                return true;
            }
            else {
                return false;
            }
        }

        public bool IsZip(int num) {
            //highest and lowest zip
            if(num <= 999999 && num >= 1) {
               return true;
            }
            else {
                return false;
            }
        }

        public bool CanCreateTour(string name, string startAddress, string startAddressNum, string startZip, string startCountry,
            string endAddress, string endAddressNum, string endZip, string endCountry, string startCity, string endCity) {

            return !String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(startAddress) && !String.IsNullOrEmpty(startAddressNum) &&
                !String.IsNullOrEmpty(startZip) && !String.IsNullOrEmpty(startCountry) && !String.IsNullOrEmpty(endAddress) &&
                !String.IsNullOrEmpty(endAddressNum) && !String.IsNullOrEmpty(endZip) && !String.IsNullOrEmpty(endCountry) && !String.IsNullOrEmpty(startCity)
                && !String.IsNullOrEmpty(endCity);

        }
        public bool CanCreateTourLog(string date, string duration, string distance, string rating, string difficulty) {

            return !String.IsNullOrEmpty(date) && !String.IsNullOrEmpty(duration) && !String.IsNullOrEmpty(distance) &&
                !String.IsNullOrEmpty(rating) && !String.IsNullOrEmpty(difficulty);

        }


        public bool isRating(int rating) {
            if (rating >= 1 && rating <= 5) {
                return true;
            }
            else {
                return false;
            }

        }




    }


    
}
