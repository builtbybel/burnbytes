using Burnbytes.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Burnbytes.Forms
{
    public partial class Scanner : Form
    {
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (HandlerThread.ThreadState == ThreadState.Running)
            {
                HandlerThread.Abort();
            }

            base.OnFormClosed(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Text = Application.ProductName;
            lblDescription.Text = Resources.Label_Scanner_Description.Format(Preferences.SelectedDrive.Name);
            btnCancel.Text = Resources.Button_Cancel;
            lblCalculation.Text = Resources.Label_Calculating;
            lblScanning.Text = Resources.Label_Scanning;

        }

        private readonly Thread HandlerThread;

        public Scanner()
        {
            InitializeComponent();

            HandlerThread = new Thread(new ThreadStart(() =>
            {
                Preferences.CleanupHandlers = new List<CleanupHandler>();
                using (var registryKey = Registry.LocalMachine.OpenSubKey(CleanupApi.VolumeCacheStoreKey, false))
                {
                    var subKeyNames = registryKey.GetSubKeyNames();

                    // Adjust progress bar maximum to discovered handler count
                    Invoke((MethodInvoker)delegate
                    {
                        pgrScanning.Maximum = subKeyNames.Length;
                    });

                    // Set up a dummy callback because COM stuff goes haywire for particular handlers if we supply none
                    var callBacks = new EmptyVolumeCacheCallBacks();

                    for (var i = 0; i < subKeyNames.Length; i++)
                    {
                        var cleanupHandler = CleanupApi.InitializeHandler(subKeyNames[i], Preferences.SelectedDrive.Letter);
                        if (cleanupHandler != null)
                        {
                            if (lblCurrentHandler.IsHandleCreated)
                                Invoke((MethodInvoker)delegate
                                {
                                    lblCurrentHandler.Text = cleanupHandler.DisplayName;
                                    pgrScanning.Value = i + 1;
                                });

                            var spaceResult = cleanupHandler.Instance.GetSpaceUsed(out long spaceUsed, callBacks);
                            if (spaceResult < 0 || (spaceUsed == 0 &&
                                ((cleanupHandler.Flags & HandlerFlags.DontShowIfZero) == HandlerFlags.DontShowIfZero ||
                                (cleanupHandler.DataDrivenFlags & DDCFlags.DontShowIfZero) == DDCFlags.DontShowIfZero)))
                            {
                                try { cleanupHandler.Instance.Deactivate(out uint dummy); } catch { }
                                Marshal.FinalReleaseComObject(cleanupHandler.Instance);
                            }
                            else
                            {
                                cleanupHandler.BytesUsed = spaceUsed;
                                Preferences.CleanupHandlers.Add(cleanupHandler);
                            }
                        }
                    }
                }

                CleanupApi.DeactivateHandlers(Preferences.CleanupHandlers);

                // Sort handlers by priority, making sure they'll run in correct order
                Preferences.CleanupHandlers.Sort((x, y) => y.Priority.CompareTo(x.Priority));


                // A (stupid?) way to close the form once we are done cleaning

                Invoke((MethodInvoker)delegate
                {
                    Close();
                });
            }));

            HandlerThread.SetApartmentState(ApartmentState.STA);
            HandlerThread.Start();
        }
    }
}
