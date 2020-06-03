using Burnbytes.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Burnbytes.Forms
{
    public partial class DriveSelection : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Text = Application.ProductName;
            btnExit.Text = Resources.Button_Exit;
            btnOk.Text = Resources.Button_Ok;
            lblDrives.Text = Resources.Label_DriveSelection_Drives;
            lblDescription.Text = Resources.Label_DriveSelection_Description;
        }

        public DriveSelection(List<DriveStrings> availableDrives)
        {
            InitializeComponent();

            availableDrives.ForEach(ds => cbDrives.Items.Add(ds));

            cbDrives.SelectedIndex = 0;
        }

        public DriveStrings SelectedDrive => DialogResult == DialogResult.OK ? (DriveStrings)cbDrives.SelectedItem : null;
    }
}
