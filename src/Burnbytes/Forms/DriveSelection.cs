using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Burnbytes.Forms
{
    public partial class DriveSelection : Form
    {
        public DriveSelection(List<DriveStrings> AvailableDrives)
        {
            InitializeComponent();

            foreach (var ds in AvailableDrives)
                CbbDrives.Items.Add(ds);

            CbbDrives.SelectedIndex = 0;
        }

        private void BtnExit_Click(object sender, EventArgs e) => Close();

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Preferences.SelectedDrive = (DriveStrings)CbbDrives.SelectedItem;
            Close();
        }
    }
}
