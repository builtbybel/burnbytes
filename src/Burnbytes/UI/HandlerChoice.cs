using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace Comet.UI
{
    public partial class HandlerChoice : Form
    {
        public HandlerChoice()
        {
            InitializeComponent();
            Text += Preferences.SelectedDrive.Name;
            // Check if we are running as administrator, if yes, give the elevation button a shield
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                if (principal.IsInRole(WindowsBuiltInRole.Administrator))
                    LblElevate.Visible = false;
                else
                    NativeMethods.SendMessage(LblElevate.Handle, 0x160C, 0, 1);
            }
            ImageList il = new ImageList
            {
                ColorDepth = ColorDepth.Depth32Bit,
                // Get proper sizes for small icon lists on different DPIs, 49 = SM_CXSMICON, 50 = SM_CYSMICON
                ImageSize = new Size(NativeMethods.GetSystemMetrics(49), NativeMethods.GetSystemMetrics(50))
            };
            il.Images.Add(GetIconFromLib("imageres.dll", 2));
            Dictionary<string, int> IconListIndexForHint = new Dictionary<string, int>();
            long totalSpaceUsed = 0;
            for (int i = 0; i < Preferences.CleanupHandlers.Count; i++)
            {
                CleanupHandler oHandler = Preferences.CleanupHandlers[i];
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
            LblIntro.Text = string.Format(LblIntro.Text, NiceSize(totalSpaceUsed), Preferences.SelectedDrive.Name);
            LvwHandlers.SmallImageList = il;
        }

        private void HandlerChoice_Load(object sender, EventArgs e)
        {
            // Some GUI options
            BtnCheckAll.Text = "\u2611"; // Ballot box with check

            Api.ReinstateHandlers(Preferences.CleanupHandlers, Preferences.SelectedDrive.Letter);
            for (int i = 0; i < Preferences.CleanupHandlers.Count; i++)
            {
                CleanupHandler oHandler = Preferences.CleanupHandlers[i];
                LvwHandlers.Items.Add(new ListViewItem(new[] { oHandler.DisplayName, NiceSize(oHandler.BytesUsed) }) { ImageIndex = (int)oHandler.IconHint, Tag = i, Checked = oHandler.StateFlag });
                LvwHandlers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                LvwHandlers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            CalculateSelectedSavings();
            // Select first loaded handler so its description gets shown
            LvwHandlers.SelectedIndices.Add(0);
        }

        private void ScaleListViewColumns(ListView listview, SizeF factor)
        {
            foreach (ColumnHeader column in listview.Columns)
            {
                column.Width = (int)Math.Round(column.Width * factor.Width);
            }
        }

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);
            ScaleListViewColumns(LvwHandlers, factor);
        }

        private void CalculateSelectedSavings()
        {
            Preferences.CurrentSelectionSavings = 0;
            for (int i = 0; i < LvwHandlers.Items.Count; i++)
            {
                if (LvwHandlers.Items[i].Checked)
                    Preferences.CurrentSelectionSavings += Preferences.CleanupHandlers[(int)LvwHandlers.Items[i].Tag].BytesUsed;
            }
            LblSavingsNum.Text = NiceSize(Preferences.CurrentSelectionSavings);
        }

        private string NiceSize(long bytes)
        {
            string[] norm = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            int count = norm.Length - 1;
            decimal size = bytes;
            int x = 0;

            while (size >= 1000 && x < count)
            {
                size /= 1024;
                x++;
            }

            return string.Format($"{Math.Round(size, 2)} {norm[x]}", MidpointRounding.AwayFromZero);
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

        private void LvwHandlers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LvwHandlers.SelectedItems.Count > 0)
            {
                CleanupHandler oHandler = Preferences.CleanupHandlers[(int)LvwHandlers.SelectedItems[0].Tag];
                LblDesc.Text = oHandler.Description;
                if ((oHandler.Flags & HandlerFlags.HasSettings) == HandlerFlags.HasSettings)
                {
                    if (oHandler.ButtonText != null)
                        LblAdvanced.Text = oHandler.ButtonText;
                    LblAdvanced.Visible = true;
                }
                else
                    LblAdvanced.Visible = false;
            }
        }

        private void LvwHandlers_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            CalculateSelectedSavings();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            DialogResult dlgRes = MessageBox.Show("Are you sure you want to permanently delete these files?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dlgRes == DialogResult.Yes)
            {
                int removedCount = 0;
                for (int i = 0; i < LvwHandlers.Items.Count; i++)
                {
                    CleanupHandler cHandler = Preferences.CleanupHandlers[(int)LvwHandlers.Items[i].Tag - removedCount];
                    if (!LblElevate.Visible)
                    {
                        cHandler.StateFlag = LvwHandlers.Items[i].Checked;
                        Api.UpdateHandlerStateFlag(cHandler);
                    }
                    // Get rid of handlers that we won't need early on
                    if (!LvwHandlers.Items[i].Checked)
                    {
                        try { cHandler.Instance.Deactivate(out uint dummy); } catch { }
                        Marshal.FinalReleaseComObject(cHandler.Instance);
                        Preferences.CleanupHandlers.Remove(cHandler);
                        removedCount++;
                    }
                }
                Api.DeactivateHandlers(Preferences.CleanupHandlers);
                Preferences.ProcessPurge = true;
                Close();
            }
        }

        private void LblAdvanced_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Preferences.CleanupHandlers[(int)LvwHandlers.SelectedItems[0].Tag].Instance.ShowProperties(Handle);
        }

        private void LblElevate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo proc = new ProcessStartInfo
            {
                UseShellExecute = true,
                WorkingDirectory = Environment.CurrentDirectory,
                FileName = Application.ExecutablePath,
                Verb = "runas"
            };
            try { Process.Start(proc); } catch { return; }
            Close();
        }

        private void Info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Burnbytes (Phoenix)\nAimed as open community cleaner! " + "\nVersion " + Program.GetCurrentVersionTostring() +
         "\r\n\nThis is my vision of a Disk cleanup utility in Windows 10, which should have been implemented by Microsoft instead of Storage sense. It combines the classic menu navigation of Disk cleanup (cleanmgr.exe) with a modernized Windows 10 typical user interface." +
         "\r\n\nThis project is based upon Albacore's Managed Disk Cleanup\nhttps://github.com/thebookisclosed/Comet\r\n\n" +
         "(C#) 2019, thebookisclosed\nhttps://twitter.com/thebookisclosed\r\n\n" +
         "Modernised version\n(C#) 2020, Belim from www.mirinsoft.com",
         "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GitHub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/mirinsoft/burnbytes");
        }

        private void LblMainMenu_Click(object sender, EventArgs e)
        {
            this.contextMenu.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void BtnCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem listItem in LvwHandlers.Items)
                listItem.Checked = !listItem.Checked;
        }

    }

 }