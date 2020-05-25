using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Comet
{
    internal static class Program
    {
        internal static string GetCurrentVersionTostring()
        {
            Version v = new Version(Application.ProductVersion);
            return v.ToString(3);
        }

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
            List<DriveStrings> availableDrives = new List<DriveStrings>();
            foreach (DriveInfo di in DriveInfo.GetDrives())
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
                using (UI.DriveSelection driveSel = new UI.DriveSelection(availableDrives))
                    Application.Run(driveSel);
                if (Preferences.SelectedDrive == null)
                    return;
            }
            else
                Preferences.SelectedDrive = availableDrives[0];
            using (UI.Scanner scanner = new UI.Scanner())
                Application.Run(scanner);
            if (Preferences.CleanupHandlers == null || Preferences.CleanupHandlers.Count == 0)
                return;
            using (UI.HandlerChoice choice = new UI.HandlerChoice())
                Application.Run(choice);
            if (!Preferences.ProcessPurge)
                return;
            using (UI.Cleaner cleaner = new UI.Cleaner())
                Application.Run(cleaner);
        }
    }
}