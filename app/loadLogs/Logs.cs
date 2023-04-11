using log4net;
using System.Runtime.CompilerServices;

namespace ConsumirApi.app.loadLogs
{
    internal class Logs
    {
        public static ILog GetLogger([CallerFilePath] string filename = "")
        {
            return LogManager.GetLogger(filename);
        }

    }
}
