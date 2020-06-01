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
            {
                MessageBox.Show("You're running on a system older than Windows 8. Due to differences in Disk Cleanup architecture, only limited functionality will be available.", "Burnbytes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            Preferences.SelectedDrive = InitializeSelectedDrive();

            if (Preferences.SelectedDrive is null) return;

            ShowForm(new Scanner());

            if (Preferences.CleanupHandlers != null && Preferences.CleanupHandlers.Any())
            {
                ShowForm(new HandlerChoice());

                if (Preferences.ProcessPurge)
                {
                    ShowForm(new Cleaner());
                }
            }
        }

        static DriveStrings InitializeSelectedDrive()
        {
            var availableDrives = LoadAvailableDrives();

            if (availableDrives.Count > 1)
            {
                using (var driveSelection = new DriveSelection(availableDrives))
                {
                    Application.Run(driveSelection);

                    return driveSelection.SelectedDrive;
                }
            }

            return availableDrives[0];
        }

        static void ShowForm(Form form)
        {
            using (form)
            {
                Application.Run(form);
            }
        }

        static List<DriveStrings> LoadAvailableDrives()
        {
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

            return availableDrives;
        }

    }
}