using EEGGaming.Core.Tools;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ConfigurationBuilder = Microsoft.Extensions.Configuration.ConfigurationBuilder;

namespace EEGGaming.Core.Managers
{
    /// <summary>
    /// This classmanages the settings of the library
    /// </summary>
   public static class AppSettingsManager
    {
        static string pathwithextention;

        static ConfigurationBuilder builder;
        static IConfigurationRoot config; 
        /// <summary>
        /// The class that starts reading the configuration file and  
        /// </summary>
        public static void Init()
        {
            try
            {
                pathwithextention = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;

                string path = "";//= System.IO.Path.GetDirectoryName(pathwithextention).Replace("file:\\", "");
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    path = System.IO.Path.GetDirectoryName(pathwithextention).Replace("file:\\", "");
                }
                else
                {
                    path = System.IO.Path.GetDirectoryName(pathwithextention).Replace("file:", "");
                }
                //return View();
                builder = (ConfigurationBuilder)new ConfigurationBuilder()
                          .SetBasePath(path)
                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                //  var config = builder.Build();//


                config = builder.Build();//
            }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);


            }

        }
        /// <summary>
        /// Gets the Conenction string from the config
        /// </summary>
        /// <returns>the connection string of the database</returns>
        public static string GetDefaultConnectionString()
        {
            try
            {
                string ap=null;
                string dbCon;
                Init();

                 
                
                string olddbConn = config.GetValue<string>("ConnectionStrings:DefaultConnection"); 
               
                string directory = CommonTools.GetAppRootDataFolderAbsolutePath();
                if (olddbConn != null)
                {
                    ap = olddbConn.Replace("|DataDirectory|", directory);

                }

                return ap;
            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
                return null;
            }
        }
    }
}
