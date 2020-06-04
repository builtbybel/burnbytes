using Burnbytes.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace Burnbytes.Forms
{
    public partial class HandlerChoice : FormBase
    {
        // Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            CleanupApi.ReinstateHandlers(Preferences.CleanupHandlers, Preferences.SelectedDrive.Letter);

            InitializeListViewItems();

            CalculateSelectedSavings();
        }

        protected override void OnLocalize()
        {
            base.OnLocalize();

            Text += " " + Preferences.SelectedDrive.Name;

            Resources.ResourceManager.Localize<HandlerChoice>
                (
                    lblStorage,
                    lblInformation,
                    lblSystem,
                    chkSelectAllHandlers,
                    lblAboutCurrentCleanupHandler,
                    lblShowFilesInExplorer,
                    lblShoreMoreSettings,
                    btnRunCleaning
                );


            tsMenuItemAbout.Text = Resources.HandlerChoice_tsMenuItemAbout.Format(Application.ProductName);
        }

        protected override void OnApplicationIdle()
        {
            base.OnApplicationIdle();

            lblIntroduction.Text = Resources.HandlerChoice_lblIntroduction.Format(Preferences.CurrentSelectionSavings.ToReadableString(), Preferences.SelectedDrive.Name);
            btnRunCleaning.Enabled = lvCleanupHandlers.Items.OfType<ListViewItem>().Any(item => item.Checked);
        }

        // Conctructors

        public HandlerChoice() : base()
        {
            InitializeComponent();


            // Check if we are running as administrator, if yes, give the elevation button a shield
            using (var identity = WindowsIdentity.GetCurrent())
            {
                var principal = new WindowsPrincipal(identity);
                if (principal.IsInRole(WindowsBuiltInRole.Administrator))
                    lblShoreMoreSettings.Visible = false;
                else
                    NativeMethods.SendMessage(lblShoreMoreSettings.Handle, 0x160C, 0, 1);
            }

            var il = new ImageList
            {
                ColorDepth = ColorDepth.Depth32Bit,
                // Get proper sizes for small icon lists on different DPIs, 49 = SM_CXSMICON, 50 = SM_CYSMICON
                ImageSize = new Size(NativeMethods.GetSystemMetrics(49), NativeMethods.GetSystemMetrics(50))
            };
            il.Images.Add(GetIconFromLib("imageres.dll", 2));

            var IconListIndexForHint = new Dictionary<string, int>();
            long totalSpaceUsed = 0;

            for (var i = 0; i < Preferences.CleanupHandlers.Count; i++)
            {
                var oHandler = Preferences.CleanupHandlers[i];
                totalSpaceUsed += oHandler.BytesUsed;

                if (oHandler.IconHint != null)
                {
                    // Reuse already loaded icon
                    if (IconListIndexForHint.ContainsKey((string)oHandler.IconHint))
                    {
                        oHandler.IconHint = IconListIndexForHint[(string)oHandler.IconHint];
                    }
                    else
                    {
                        // Get icon from PE file, comma separates filename and ID
                        string[] splitHint = ((string)oHandler.IconHint).TrimStart('@').Split(',');
                        Icon obtIcon = GetIconFromLib(splitHint[0], int.Parse(splitHint[1]));
                        if (obtIcon != null)
                        {
                            il.Images.Add(obtIcon);
                            IconListIndexForHint[(string)oHandler.IconHint] = il.Images.Count - 1;
                            oHandler.IconHint = il.Images.Count - 1;
                        }
                        else
                        {
                            // Otherwise use placeholder icon
                            IconListIndexForHint[(string)oHandler.IconHint] = 0;
                            oHandler.IconHint = 0;
                        }
                    }
                }
                else
                    oHandler.IconHint = 0;
            }
            lblIntroduction.Text = string.Format(lblIntroduction.Text, totalSpaceUsed.ToReadableString(), Preferences.SelectedDrive.Name);
            lvCleanupHandlers.SmallImageList = il;
        }

        // Nethods

        private void InitializeListViewItems()
        {
            for (var i = 0; i < Preferences.CleanupHandlers.Count; i++)
            {
                var cleanupHandler = Preferences.CleanupHandlers[i];
                lvCleanupHandlers.Items.Add(new ListViewItem(new[] { cleanupHandler.DisplayName, cleanupHandler.BytesUsed.ToReadableString() }) { ImageIndex = (int)cleanupHandler.IconHint, Tag = cleanupHandler, Checked = cleanupHandler.StateFlag });
                lvCleanupHandlers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvCleanupHandlers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }

            lvCleanupHandlers.SelectedIndices.Add(0);
        }

        private void ScaleListViewColumns(ListView listview, SizeF factor)
        {
            foreach (var columnHeader in listview.Columns.OfType<ColumnHeader>())
            {
                columnHeader.Width = (int)Math.Round(columnHeader.Width * factor.Width);
            }
        }

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);
            ScaleListViewColumns(lvCleanupHandlers, factor);
        }

        private void CalculateSelectedSavings()
        {
            Preferences.CurrentSelectionSavings = 0;

            foreach (var listViewItem in lvCleanupHandlers.Items.OfType<ListViewItem>())
            {
                if (listViewItem.Checked)
                {
                    Preferences.CurrentSelectionSavings += ((CleanupHandler)listViewItem.Tag).BytesUsed;
                }
            }

            lblSavingsNum.Text = Preferences.CurrentSelectionSavings.ToReadableString(); ;
        }

        private void SetChkSelectAllCheckWithoutEvent(bool @checked)
        {
            chkSelectAllHandlers.CheckedChanged -= ChkSelectAllHandlers_CheckedChanged;
            chkSelectAllHandlers.Checked = @checked;
            chkSelectAllHandlers.CheckedChanged += ChkSelectAllHandlers_CheckedChanged;
        }

        private Icon GetIconFromLib(string file, int number)
        {
            NativeMethods.ExtractIconEx(file, number, out IntPtr bigIcon, out IntPtr smallIcon, 1);
            if (smallIcon != IntPtr.Zero)
            {
                NativeMethods.DestroyIcon(bigIcon);
                return Icon.FromHandle(smallIcon).AsDisposableIcon();
            }
            else if (bigIcon != IntPtr.Zero)
                return Icon.FromHandle(bigIcon).AsDisposableIcon();
            else
                return null;
        }

        // EventHandler

        private void LvwHandlers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCleanupHandlers.SelectedItems.Count > 0)
            {
                var currentCleanupHandler = lvCleanupHandlers.SelectedItems[0].Tag as CleanupHandler;

                lblDescriptionOfCurrentCleanupHandler.Text = currentCleanupHandler.Description;

                if ((currentCleanupHandler.Flags & HandlerFlags.HasSettings) == HandlerFlags.HasSettings)
                {
                    if (currentCleanupHandler.ButtonText != null)
                        lblShowFilesInExplorer.Text = currentCleanupHandler.ButtonText;

                    lblShowFilesInExplorer.Visible = true;
                }
                else
                    lblShowFilesInExplorer.Visible = false;
            }
        }

        private void LvwHandlers_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            CalculateSelectedSavings();

            if (chkSelectAllHandlers.Checked && lvCleanupHandlers.Items.OfType<ListViewItem>().Any(item => !item.Checked))
            {
                SetChkSelectAllCheckWithoutEvent(false);
            }

            if (!chkSelectAllHandlers.Checked && lvCleanupHandlers.Items.OfType<ListViewItem>().All(item => item.Checked))
            {
                SetChkSelectAllCheckWithoutEvent(true);
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(Resources.Message_ReallyDeleteFiles, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                int removedCount = 0;

                foreach (var listViewItem in lvCleanupHandlers.Items.OfType<ListViewItem>())
                {
                    if (listViewItem.Tag is CleanupHandler cHandler)
                    {
                        if (!lblShoreMoreSettings.Visible)
                        {
                            cHandler.StateFlag = listViewItem.Checked;
                            CleanupApi.UpdateHandlerStateFlag(cHandler);
                        }

                        // Get rid of handlers that we won't need early on
                        if (!listViewItem.Checked)
                        {
                            try { cHandler.Instance.Deactivate(out uint dummy); } catch { }
                            Marshal.FinalReleaseComObject(cHandler.Instance);
                            Preferences.CleanupHandlers.Remove(cHandler);
                            removedCount++;
                        }
                    }
                }

                CleanupApi.DeactivateHandlers(Preferences.CleanupHandlers);
                Preferences.ProcessPurge = true;
                Close();
            }
        }

        private void LblAdvanced_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => ((CleanupHandler)lvCleanupHandlers.SelectedItems[0].Tag).Instance.ShowProperties(Handle);

        private void LblElevate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                WorkingDirectory = Environment.CurrentDirectory,
                FileName = Application.ExecutablePath,
                Verb = "runas"
            };
            try { Process.Start(startInfo); } catch { return; }
            Close();
        }

        private void TsMenuItemAbout_Click(object sender, EventArgs e) => MessageBox.Show(Resources.Message_About.Format(Application.ProductName, Program.GetCurrentVersionTostring()), Resources.HandlerChoice_tsMenuItemAbout.Format(Application.ProductName), MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void TsMenuItemShowWebsite_Click(object sender, EventArgs e) => Process.Start("https://github.com/mirinsoft/burnbytes");

        private void BtnShowMainMenu_Click(object sender, EventArgs e) => contextMenu.Show(Cursor.Position.X, Cursor.Position.Y);

        private void ChkSelectAllHandlers_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                lvCleanupHandlers.ItemChecked -= LvwHandlers_ItemChecked;

                foreach (var listViewItem in lvCleanupHandlers.Items.OfType<ListViewItem>())
                    listViewItem.Checked = checkBox.Checked;

                lvCleanupHandlers.ItemChecked += LvwHandlers_ItemChecked;

                CalculateSelectedSavings();
            }
        }
    }
}