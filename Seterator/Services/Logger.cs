using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seterator.Services
{
    public static class Logger
    {
        public static NLog.Logger Default => LogManager.GetLogger("Default");
        public static NLog.Logger Sensitive => LogManager.GetLogger("Sensitive");
        public static NLog.Logger Console => LogManager.GetLogger("Console");
    }
}
