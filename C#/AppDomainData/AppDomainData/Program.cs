using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainData
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nBaseDirectory: " + AppDomain.CurrentDomain.BaseDirectory);

            Console.WriteLine("\nRelativeSearchPath: " + AppDomain.CurrentDomain.RelativeSearchPath);


            /*System values
            "APPBASE"                       AppDomainSetup.ApplicationBase
            "APP_CONFIG_FILE"               AppDomainSetup.ConfigurationFile
            "APP_LAUNCH_URL"                (no property)
            "APP_LAUNCH_URL"                represents the URL originally requested by the user, before any redirection. It is available only when the application has been launched with a browser such as Internet Explorer.Not all browsers provide this value.
            "APP_NAME"                      AppDomainSetup.ApplicationName
            "BINPATH_PROBE_ONLY"            AppDomainSetup.PrivateBinPathProbe
            "CACHE_BASE"                    AppDomainSetup.CachePath
            "CODE_DOWNLOAD_DISABLED"        AppDomainSetup.DisallowCodeDownload
            "DEV_PATH"                      (no property)
            "DISALLOW_APP"                  AppDomainSetup.DisallowPublisherPolicy
            "DISALLOW_APP_BASE_PROBING"     AppDomainSetup.DisallowApplicationBaseProbing
            "DISALLOW_APP_REDIRECTS"        AppDomainSetup.DisallowBindingRedirects
            "DYNAMIC_BASE"                  AppDomainSetup.DynamicBase
            "FORCE_CACHE_INSTALL"           AppDomainSetup.ShadowCopyFiles
            "LICENSE_FILE"                  , or an application - specific string AppDomainSetup.LicenseFile
            "LOADER_OPTIMIZATION"            AppDomainSetup.LoaderOptimization
            "LOCATION_URI"                  (no property)
            "PRIVATE_BINPATH"               AppDomainSetup.PrivateBinPath
            "REGEX_DEFAULT_MATCH_TIMEOUT"   Regex.MatchTimeout
            "REGEX_DEFAULT_MATCH_TIMEOUT"   is not a system entry, and its value can be set by calling the SetData method.
            "SHADOW_COPY_DIRS"              AppDomainSetup.ShadowCopyDirectories
            */

            Console.WriteLine("\nApplicationBase: " + AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
            Console.WriteLine("\nAPPBASE: " + AppDomain.CurrentDomain.GetData("APPBASE"));

            Console.WriteLine("\nConfigurationFile: " + AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            Console.WriteLine("\nAPP_CONFIG_FILE: " + AppDomain.CurrentDomain.GetData("APP_CONFIG_FILE"));


            //Custom value
            AppDomain.CurrentDomain.SetData("MyConfigKey", "MyConfigValue");
            Console.WriteLine("\nMyConfigKey: " + AppDomain.CurrentDomain.GetData("MyConfigKey"));


            if (AppDomain.CurrentDomain.GetData("DoesNotExist") == null)
            {
                Console.WriteLine("Setting 'DoesNotExist' doesn't exist. This is as it should be.");
            }

        }
    }
}
