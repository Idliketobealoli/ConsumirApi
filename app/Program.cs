/*
 * Guias Logs: https://blog.junglacode.org/memorias/tutoriales/log4net-c-instalacion-y-guia-rapida-para-vs2019/
 * 
 * https://logging.apache.org/log4net/release/manual/configuration.html
 * 
 * https://stackoverflow.com/questions/32892021/log4net-in-a-separate-configuration-file
 */

using log4net;
using System.Configuration;

namespace ConsumirApi.app
{
    public class Program
    {
        private static readonly ILog Log = loadLogs.Logs.GetLogger();

        private static void Main()
        {
            LoadConfig();
        }

        private static void LoadConfig()
        {

            GlobalContext.Properties["LogFileName"] = @$"{Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName}" +
                $"{Path.DirectorySeparatorChar}logs{Path.DirectorySeparatorChar}logs.log";

            log4net.Config.XmlConfigurator.Configure();


            Console.WriteLine("Hola mundo");
            Log.Info("Hola Mundo");
        }

    }
}
