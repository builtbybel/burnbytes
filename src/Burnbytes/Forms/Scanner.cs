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
        private readonly Thread HandlerThread;

        public Scanner()
        {
            InitializeComponent();
            LblIntro.Text = string.Format(LblIntro.Text, Preferences.SelectedDrive.Name);
            HandlerThread = new Thread(new ThreadStart(() =>
            {
                Preferences.CleanupHandlers = new List<CleanupHandler>();
                using (var rKey = Registry.LocalMachine.OpenSubKey(CleanupApi.VolumeCacheStoreKey, false))
                {
                    var subKeyNames = rKey.GetSubKeyNames();
                    
                    // Adjust progress bar maximum to discovered handler count
                    Invoke((MethodInvoker)delegate
                    {
                        PrgScan.Maximum = subKeyNames.Length;
                    });

                    // Set up a dummy callback because COM stuff goes haywire for particular handlers if we supply none
                    var callBacks = new EmptyVolumeCacheCallBacks();
                    for (int i = 0; i < subKeyNames.Length; i++)
                    {
                        var evp = CleanupApi.InitializeHandler(subKeyNames[i], Preferences.SelectedDrive.Letter);
                        if (evp != null)
                        {
                            if (LblHandler.IsHandleCreated)
                                Invoke((MethodInvoker)delegate
                                {
                                    LblHandler.Text = evp.DisplayName;
                                    PrgScan.Value = i + 1;
                                });
                            int spaceResult = evp.Instance.GetSpaceUsed(out long spaceUsed, callBacks);
                            if (spaceResult < 0 || (spaceUsed == 0 &&
                                ((evp.Flags & HandlerFlags.DontShowIfZero) == HandlerFlags.DontShowIfZero ||
                                (evp.DataDrivenFlags & DDCFlags.DontShowIfZero) == DDCFlags.DontShowIfZero)))
                            {
                                try { evp.Instance.Deactivate(out uint dummy); } catch { }
                                Marshal.FinalReleaseComObject(evp.Instance);
                            }
                            else
                            {
                                evp.BytesUsed = spaceUsed;
                                Preferences.CleanupHandlers.Add(evp);
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            HandlerThread.Abort();
            Close();
        }
    }
}
