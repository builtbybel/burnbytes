using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comet.UI
{
    public partial class DriveSelection : Form
    {
        public DriveSelection(List<DriveStrings> AvailableDrives)
        {
            InitializeComponent();
            foreach (DriveStrings ds in AvailableDrives)
                CbbDrives.Items.Add(ds);
            CbbDrives.SelectedIndex = 0;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Preferences.SelectedDrive = (DriveStrings)CbbDrives.SelectedItem;
            Close();
        }
    }
}
