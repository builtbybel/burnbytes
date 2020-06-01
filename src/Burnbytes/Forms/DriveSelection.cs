using System.Collections.Generic;
using System.Windows.Forms;

namespace Burnbytes.Forms
{
    public partial class DriveSelection : Form
    {
        public DriveSelection(List<DriveStrings> availableDrives)
        {
            InitializeComponent();

            availableDrives.ForEach(ds => CbbDrives.Items.Add(ds));

            CbbDrives.SelectedIndex = 0;
        }

        public DriveStrings SelectedDrive => DialogResult == DialogResult.OK ? (DriveStrings)CbbDrives.SelectedItem : null;
    }
}
