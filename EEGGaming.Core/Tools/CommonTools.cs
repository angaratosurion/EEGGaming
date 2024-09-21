﻿using NLog;
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
    /// <summary>
    /// Classwith some common tools
    /// </summary>
    public  class CommonTools
    {
        public static Logger logger;
        /// <summary>
        ///  Creates  the Loger
        /// </summary>
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
     

        /// <summary>
        /// Checks if a string is empty
        /// </summary>
        /// <param name="str">string to be checked </param>
        /// <returns> true f its empty flase otherwise</returns>
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
        /// <summary>
        /// SavesErrors to log file
        /// </summary>
        /// <param name="ex">error that occured</param>
        public static void ErrorReporting(Exception ex)
        {
            
            if (ex.GetBaseException() is ValidationException)
            {
                // ValidationErrorReporting((ValidationException)ex);
                logger.Fatal(ex);

            }
            else
            {


                CreateLogger();


                
                logger.Fatal(ex.ToString());
                NLog.LogManager.Flush();
                
            }

        }
        /// <summary>
        /// Gets the absolute path of the app's binary folder
        /// </summary>
        /// <returns>the absolute path of the app's binary folder</returns>
        public static string GetAppRootBinaryFolderAbsolutePath()
        {
            try
            {
                string ap = "";

                string pathwithextention;


                pathwithextention = AppContext.BaseDirectory;


                
                string path;
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
        /// <summary>
        /// gets the absolute path of  app's data folder
        /// </summary>
        /// <returns>absolute path of  app's data folder</returns>
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
        /// <summary>
        /// Createsthe app's data folder
        /// </summary>
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


        /// <summary>
        /// Gets the version of EEGGaming Core
        /// </summary>
        /// <returns>version of EEGGaming Core</returns>

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
        /// <summary>
        /// Gets the version of Blinkbird
        /// </summary>
        /// <returns>version of Blinkbird</returns>
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
        /// <summary>
        /// Gets the Developer of BlinkBird
        /// </summary>
        /// <returns>Developer of BlinkBird</returns>
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
        /// <summary>
        /// gwts the copyright of blinkbird
        /// </summary>
        /// <returns>the copyright of blinkbird</returns>
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
        /// <summary>
        /// Gets the developer of  EEGGaming Core 
        /// </summary>
        /// <returns>developer of  EEGGaming Core </returns>

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
        /// <summary>
        /// Gets the copyright of  EEGGaming Core 
        /// </summary>
        /// <returns>copyright of  EEGGaming Core </returns>
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
        /// <summary>
        /// Gets the date EEGGaming Core  last modified  
        /// </summary>
        /// <returns>date EEGGaming Core  last modified  </returns>
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
        /// <summary>
        /// Gets the date BlinkBird  last modified
        /// </summary>
        /// <returns>date BlinkBird  last modified</returns>
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
        /// <summary>
        /// Gets the MDM5 Hash of Blinkbird 
        /// </summary>
        /// <returns>Hash of Blinkbird </returns>

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
