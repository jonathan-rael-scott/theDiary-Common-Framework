using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace theDiary.Tools.Development.HostFileManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ElevatedApplication.EnableVisualStyles();
            ElevatedApplication.SetCompatibleTextRenderingDefault(false);
            ElevatedApplication.SetElevationRequirement(ApplicationElevationRequirement.ElevationNotRequired);
            ElevatedApplication.Run(new MainForm());
        }
    }
}
