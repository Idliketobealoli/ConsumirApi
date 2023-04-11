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
            InitialMenu();
        }

        private static void LoadConfig()
        {

            var path = $"{Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName}" +
                $"{Path.DirectorySeparatorChar}logs";

            ResetLogs(path);

            GlobalContext.Properties["LogFileName"] = @$"{path}{Path.DirectorySeparatorChar}logs.log";

            log4net.Config.XmlConfigurator.Configure();
        }

        private static void ResetLogs(string path)
        {
            DirectoryInfo di = new (path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }

        private static void InitialMenu()
        {
            bool salir = false;
            Console.WriteLine("INICIANDO APP...");

            while (!salir)
            {
                Console.WriteLine("\nEscoga la opción del menú: \n1.Buscar Pokémon\n2.Salir");
                var lectura = Console.ReadKey(true).KeyChar.ToString();
                var opcion = 0;

                int.TryParse(lectura, out opcion);

                //Console.WriteLine(opcion);
                switch (opcion)
                {
                    case 1: {
                            Console.WriteLine("Indique el nombre o ID del Pokémon:");
                            var busqueda = Console.ReadKey().KeyChar.ToString();
                            Log.Info(busqueda);
                        }
                        break;

                    case 2: {
                        salir = true;
                        };
                        break;

                    default: { 
                        salir = true; 
                        };
                        break;

                }
            }

            Log.Info("SALIENDO DE LA APP...");
            Console.WriteLine("SALIENDO DE LA APP...");
        }

    }
}
