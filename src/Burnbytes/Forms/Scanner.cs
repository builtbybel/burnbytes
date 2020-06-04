using Burnbytes.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Burnbytes.Forms
{
    public partial class Scanner : FormBase
    {
        // Events

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (_thread.ThreadState == ThreadState.Running)
            {
                _thread.Abort();
            }

            base.OnFormClosed(e);
        }

        protected override void OnLocalize()
        {
            base.OnLocalize();


            Resources.ResourceManager.Localize<Scanner>
                (
                    lblDescription,
                    btnCancel,
                    lblCalculation,
                    lblScanning
                );

            lblDescription.Text = lblDescription.Text.Format(Preferences.SelectedDrive.Name);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Run();
        }

        // Fields

        private Thread _thread;

        // Constructors

        public Scanner() : base() => InitializeComponent();

        // Methods

        private void Run()
        {
            _thread = new Thread(new ThreadStart(() =>
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

            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
        }

        // EventHandler

        private void BtnCancel_Click(object sender, EventArgs e)
        {

            _thread?.Abort();
            Close();
        }
    }
}
