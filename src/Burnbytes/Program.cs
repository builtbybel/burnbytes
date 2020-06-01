using Burnbytes.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Burnbytes
{
    internal static class Program
    {
        internal static string GetCurrentVersionTostring() => new Version(Application.ProductVersion).ToString(3);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Environment.OSVersion.Version.Build < 9200)
                MessageBox.Show("You're running on a system older than Windows 8. Due to differences in Disk Cleanup architecture, only limited functionality will be available.", "Managed Disk Cleanup", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var availableDrives = new List<DriveStrings>();


            foreach (var di in DriveInfo.GetDrives())
            {
                if (di.DriveType == DriveType.Fixed)
                {
                    availableDrives.Add(new DriveStrings()
                    {
                        Name = string.Format("{0} ({1})", di.VolumeLabel, di.Name.TrimEnd('\\')),
                        Letter = di.Name
                    });
                }
            }
            if (availableDrives.Count > 1)
            {
                using (var driveSel = new DriveSelection(availableDrives))
                    Application.Run(driveSel);

                if (Preferences.SelectedDrive == null)
                    return;
            }
            else
                Preferences.SelectedDrive = availableDrives[0];

            using (var scanner = new Scanner())
                Application.Run(scanner);

            if (Preferences.CleanupHandlers != null && Preferences.CleanupHandlers.Any())
            {
                using (var choice = new HandlerChoice())
                    Application.Run(choice);

                if (!Preferences.ProcessPurge)
                    return;

                using (var cleaner = new Cleaner())
                    Application.Run(cleaner);
            }
        }
    }
}