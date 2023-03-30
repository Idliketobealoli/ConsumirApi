using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsumirApi
{
    internal class Logs
    {
        public static ILog GetLogger([CallerFilePath] string filename = "")
        {
            return LogManager.GetLogger(filename);
        }

    }
}
