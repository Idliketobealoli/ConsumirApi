/*
 * Guias Logs: https://blog.junglacode.org/memorias/tutoriales/log4net-c-instalacion-y-guia-rapida-para-vs2019/
 * 
 * https://logging.apache.org/log4net/release/manual/configuration.html
 * 
 * https://stackoverflow.com/questions/32892021/log4net-in-a-separate-configuration-file
 */

using ConsumirApi.app.models.consumo;
using log4net;

namespace ConsumirApi.app
{
    public class Program
    {
        private static readonly ILog Log = loadLogs.Logs.GetLogger(); 
        private static readonly Consumidor Cons = new Consumidor();

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

            if (di.Exists )
            {
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }
        }

        private static void InitialMenu()
        {
            bool salir = false;
            Console.WriteLine("INICIANDO APP...");

            while (!salir)
            {
                Console.WriteLine("\nEscoga la opción del menú: " +
                    "\n1.Buscar Pokémon." +
                    "\n2.Mostrar todos los pokemon en memoria." +
                    "\n3.Mostrar pokemon en memoria por nombre." +
                    "\n4.Salir");
                var lectura = Console.ReadKey(true).KeyChar.ToString();
                var opcion = 0;

                int.TryParse(lectura, out opcion);

                //Console.WriteLine(opcion);
                switch (opcion)
                {
                    case 1: 
                        {
                            Console.WriteLine("Indique el nombre o ID del Pokémon:");
                            var busqueda = Console.ReadLine() ?? "";
                            Log.Info(busqueda);
                            Cons.Find(busqueda);
                        }
                        break;

                    case 2: 
                        {
                            Console.WriteLine("Mostrando todos los pokemons en memoria...");
                            Log.Info("Mostrando todos los pokemons.");
                            Cons.Show();
                        }
                        break;

                    case 3:
                        {
                            var name = Console.ReadLine() ?? "";
                            Console.WriteLine($"Mostrando pokemon con nombre {name}...");
                            Log.Info($"Mostrando pokemon con nombre {name}.");
                            Cons.Show(name);
                        }
                        break;

                    case 4: salir = true;
                        break;

                    default: 
                        { 
                            salir = true;
                            Console.WriteLine("Opcion invalida.");
                            Log.Error("Opcion invalida.");
                        }
                        break;
                }
            }

            Log.Info("SALIENDO DE LA APP...");
            Console.WriteLine("SALIENDO DE LA APP...");
        }

    }
}
