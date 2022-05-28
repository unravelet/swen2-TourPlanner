﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.BL.Services
{
    public static class LoggerFactory
    {
        public static ILoggerWrapper GetLogger()
        {
            return Log4NetWrapper.CreateLogger("./log4net.txt");
        }
    }
}
