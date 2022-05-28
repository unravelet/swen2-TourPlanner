﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.BL.Services
{
        public interface ILoggerWrapper
        {
            void Debug(string message);
            void Error(string message);
            void Fatal(string message);
            void Warn(string message);
        }
}
