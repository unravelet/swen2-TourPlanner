using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.BL.Services {
    public class UserInputService {

        //trying out changes
        public UserInputService() { }


        public int AddressNum { get; private set; }
        public int Zip { get; private set; }

        public bool IsInputInt(string input) {

            if (int.TryParse(input, out int n)) {
                AddressNum = n;
                return true;
            }
            else {
                AddressNum = 0;
                return false;
            }
        }

        public bool IsAddressNumber(int num) {
            //worlds highest address number
            if(num <= 986039 && num > 1) {
                return true;
            }
            else {
                return false;
            }
        }

        public bool IsZip(int num) {
            //highest and lowest zip
            if(num <= 999999 && num >= 501) {
               return true;
            }
            else {
                return false;
            }
        }

       


    }


    
}
