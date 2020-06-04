using Burnbytes.Properties;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Burnbytes.Forms
{
    public partial class DriveSelection : FormBase
    {
        // Events

        protected override void OnLocalize()
        {
            base.OnLocalize();

            Resources.ResourceManager.Localize<DriveSelection>
                (
                    btnExit,
                    btnOk,
                    lblDrives,
                    lblDescription
                ); ;
        }

        // Constructors

        public DriveSelection(IEnumerable<DriveStrings> availableDrives) : base()
        {
            InitializeComponent();

            availableDrives.ForEach(ds => cbDrives.Items.Add(ds));

            cbDrives.SelectedIndex = 0;
        }

        // Properties

        public DriveStrings SelectedDrive => DialogResult == DialogResult.OK ? (DriveStrings)cbDrives.SelectedItem : null;
    }
}
