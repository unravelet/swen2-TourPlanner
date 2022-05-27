using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.BL.Services {
    public class UserInputService {


        public UserInputService() { }


        public int AddressNum { get; private set; }
        public int Zip { get; private set; }

        public bool IsInputInt(string input) {

            if (int.TryParse(input, out int n)) {
                AddressNum = n;
                return true;
            }
            else {
                AddressNum = -1;
                return false;
            }
        }

        public bool IsAddressNumber(int num) {
            //worlds highest address number
            if(num <= 986039 && num > 0) {
                return true;
            }
            else {
                return false;
            }
        }

       


    }


    
}
