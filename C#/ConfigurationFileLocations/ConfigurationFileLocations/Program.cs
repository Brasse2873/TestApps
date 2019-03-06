using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConfigurationFileLocations
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();
            Console.WriteLine("\nMachine configuration file: " + path + @"Config\machine.config");

            Console.WriteLine("\nApplication configuration file: " + AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            Console.WriteLine("\nUser Setting local location: " + Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

            Console.WriteLine("\nUser Setting roaming location: " + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

            Console.WriteLine("\nUser Setting local file: " + ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath); //doesn't give a valid path in debug!?

            Console.WriteLine("\nUser Setting roaming file: " + ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming).FilePath);//doesn't give a valid path in debug!?

            Console.WriteLine("\nAPP_CONFIG_FILE setting: " + AppDomain.CurrentDomain.GetData("APP_CONFIG_FILE"));
        }
    }
}
