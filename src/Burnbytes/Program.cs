using Burnbytes.Forms;
using Burnbytes.Properties;
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
                MessageBox.Show(Resources.MessageBox_IncompleteSupportedOs, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            Preferences.SelectedDrive = InitializeSelectedDrive();

            if (Preferences.SelectedDrive is null) return;

            ShowForm<Scanner>();

            if (Preferences.CleanupHandlers != null && Preferences.CleanupHandlers.Any())
            {
                ShowForm<HandlerChoice>();

                if (Preferences.ProcessPurge)
                {
                    ShowForm<Cleaner>();
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
                    driveSelection.ShowDialog();

                    return driveSelection.SelectedDrive;
                }
            }

            return availableDrives[0];
        }

        static void ShowForm<T>() where T : Form
        {
            using (var form = Activator.CreateInstance(typeof(T)) as Form)
            {
                form.ShowDialog();
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