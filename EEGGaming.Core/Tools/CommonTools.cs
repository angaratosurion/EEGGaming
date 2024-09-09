using NLog;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using NLog.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;

namespace EEGGaming.Core.Tools
{
    public  class CommonTools
    {
        public static Logger logger;//= LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
        public static void CreateLogger()
        {
            try
            {
                var config = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, reloadOnChange: true)
                     .Build();
                var tlogger = LogManager.Setup()
                      .LoadConfigurationFromSection(config)
                    
                       .GetCurrentClassLogger();

                logger = tlogger;
            }
            catch (Exception ex)
            {
                ErrorReporting(ex);


            }

        }
     

        //public static FileRecordManager FileRecordManager = new FileRecordManager(usrmng.Context);
        public static Boolean isEmpty(string str)
        {
            try
            {
                Boolean ap = true;
                if (str != null && str != String.Empty)
                {
                    ap = false;
                }

                return ap;
            }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);

                return true;
            }
        }
        public static void ErrorReporting(Exception ex)
        {
            //throw (ex);
            //SlimeWeb.Core.Configuration.SlimeWeb.CoreSettingManager conf = new Configuration.SlimeWeb.CoreSettingManager();
            if (ex.GetBaseException() is ValidationException)
            {
                // ValidationErrorReporting((ValidationException)ex);
                logger.Fatal(ex);

            }
            else
            {


                CreateLogger();


                //(new CompactJsonFormatter());



                //.ReadFrom.Services(services)
                //  .Enrich.FromLogContext()

                // .WriteTo.File(new CompactJsonFormatter(), "/wwwroot/AppData/logs/logs.json"))
                //.CreateBootstrapLogger())

                logger.Fatal(ex.ToString());
                NLog.LogManager.Flush();
                // logger.Fatal(ex);
                // if (conf.ExceptionShownOnBrowser() == true)
                //  {
                //  Console.WriteLine(ex.ToString());
                //throw (ex);
                //   logger.TraceException(ex.Message, ex);
                //  }
            }

        }
        public static string GetAppRootBinaryFolderAbsolutePath()
        {
            try
            {
                string ap = "";

                string pathwithextention;


                pathwithextention = AppContext.BaseDirectory;


                ;//System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                string path;//= System.IO.Path.GetDirectoryName(pathwithextention).Replace("file:\\", "");
                //ap = pathwithextention.Replace("file:\\", "");
                path = AppContext.BaseDirectory;
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    ap = pathwithextention.Replace("file:\\", "");
                }
                else
                {
                    ap = pathwithextention.Replace("file:", "");
                }



                return ap;
            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
                return "";
            }
        }
        public static string GetAppRootDataFolderAbsolutePath()
        {
            try
            {
                string ap = "";

                string pathwithextention;


                pathwithextention = Path.Combine(GetAppRootBinaryFolderAbsolutePath(), "AppData");


                 
                string path; ;
                
                path = AppContext.BaseDirectory;
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    ap = pathwithextention.Replace("file:\\", "");
                }
                else
                {
                    ap = pathwithextention.Replace("file:", "");
                }



                return ap;
            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
                return "";
            }
        }
        public static void CreateAppRootdataFolder()
        {
            try
            {
                string path =GetAppRootDataFolderAbsolutePath();
                if ( path != null && Directory.Exists(path)==false)
                {
                    Directory.CreateDirectory(path);

                }

            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
               
            }
        }


        
        public static bool checkifDoubleTableisnotAll0(double[] ar)
        {
            try
            {
                bool ap = false;
                if( ar!=null)
                {
                    
                }

                return ap;


            }
            catch (Exception ex)
            {

                CommonTools.ErrorReporting(ex);
                return false;
            }
        }

        public static string GetEEGGamingCoreVersion()
        {
            try
            {
                string ap;
                ap = Assembly.GetExecutingAssembly().GetName().Version.ToString();

                return ap;

            }
            catch (Exception ex)
            {
                ErrorReporting(ex);

                return null;
            }
        }
        public static string GetBlinkBirdbVersion()
        {
            try
            {
                string ap="";
                if (Assembly.GetEntryAssembly() != null)
                {
                    ap = Assembly.GetEntryAssembly().GetName().Version.ToString();
                }

                return ap;

            }
            catch (Exception ex)
            {
                ErrorReporting(ex);

                throw;
                return null;
            }
        }
        public static string GetBlinkBirdDeveloper()
        {
            try
            { 
                string ap;
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);

                AssemblyCompanyAttribute attribute = null;
                if (attributes.Length > 0)
                {
                    attribute = attributes[0] as AssemblyCompanyAttribute;
                }
                ap = attribute.Company;

                return ap;

            }
            catch (Exception ex)
            {
                ErrorReporting(ex);

                return null;
            }
        }
        public static string GetBlinkBirdCopyright()
        {
            try
            {
                string ap;
                object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);

                AssemblyCopyrightAttribute attribute = null;
                if (attributes.Length > 0)
                {
                    attribute = attributes[0] as AssemblyCopyrightAttribute;
                }
                ap = attribute.Copyright;

                return ap;

            }
            catch (Exception ex)
            {
                ErrorReporting(ex);

                return null;
            }
        }
      
        public static string GetEEGGamingCoreDeveloper()
        {
            try
            {
                string ap;
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);

                AssemblyCompanyAttribute attribute = null;
                if (attributes.Length > 0)
                {
                    attribute = attributes[0] as AssemblyCompanyAttribute;
                }
                ap = attribute.Company;

                return ap;

            }
            catch (Exception ex)
            {
                ErrorReporting(ex);

                return null;
            }
        }
        public static string GetEEGGamingCoreCopyright()
        {
            try
            {
                string ap;
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);

                AssemblyCopyrightAttribute attribute = null;
                if (attributes.Length > 0)
                {
                    attribute = attributes[0] as AssemblyCopyrightAttribute;
                }
                ap = attribute.Copyright;

                return ap;

            }
            catch (Exception ex)
            {
                ErrorReporting(ex);

                return null;
            }
        }
        public static string GetEEGGamingCoreLastModifiedDateUTC()
        {
            try
            {
                string ap;
                string filepath = Assembly.GetExecutingAssembly().Location;
                ap = File.GetLastWriteTime(filepath).ToLongDateString() + " - " + File.GetLastWriteTimeUtc(filepath).ToLongTimeString();

                return ap;

            }
            catch (Exception ex)
            {
                ErrorReporting(ex);

                return null;
            }
        }
        public static string GetBlickBirdbLastModifiedDateUTC()
        {
            try
            {
                string ap;
                string filepath = Assembly.GetEntryAssembly().Location;
                ap = File.GetLastWriteTime(filepath).ToLongDateString() + " - " + File.GetLastWriteTimeUtc(filepath).ToLongTimeString();

                return ap;

            }
            catch (Exception ex)
            {
                ErrorReporting(ex);

                return null;
            }
        }
       
        public static string GetBlinBirdMD5Hash()
        {
            try
            {
                string ap;
                string filepath = Assembly.GetEntryAssembly().Location;

                StringBuilder sBuilder = new StringBuilder();
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(filepath))
                    {
                        var data = md5.ComputeHash(stream);
                        for (int i = 0; i < data.Length; i++)
                        {
                            sBuilder.Append(data[i].ToString("x2"));
                            // sBuilder.Append(data[i].ToString());
                        }
                        ap = sBuilder.ToString();
                        stream.Close();
                    }
                }
                return ap;

            }
            catch (Exception ex)
            {
                ErrorReporting(ex);

                return null;
            }
        }
    }
}
