using EEGGaming.Core.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EEGGaming.Trainer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            EEGGaming.Core.Data.EEGGamingDbContext db = new Core.Data.EEGGamingDbContext();
            if (Directory.Exists(CommonTools.GetAppRootDataFolderAbsolutePath()) == false)
            {
                Directory.CreateDirectory(CommonTools.GetAppRootDataFolderAbsolutePath());
            }
            db.Database.EnsureCreated();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMainGUI());
            
        }
    }
}
