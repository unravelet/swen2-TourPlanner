using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.BL {
    public class Log4NetWrapper {


        private log4net.ILog logger;

        private Log4NetWrapper(log4net.ILog logger) { 
            this.logger = logger;

        }


        /*public static Log4NetWrapper CreateLogger(string filename) {
            
        }
        */
    }
}
