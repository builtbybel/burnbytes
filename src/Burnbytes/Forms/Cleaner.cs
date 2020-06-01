using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Burnbytes.Forms
{
    public partial class Cleaner : Form
    {
        private Thread HandlerThread;
        private long TotalBytesDeleted;
        private int LastTotalPercent;
        private EmptyVolumeCacheCallBacks CallBacks;
        private bool ProcessingHandlers;
        private int LastHandlerPercent;
        private CleanupHandler CurrentHandler;

        public Cleaner()
        {
            InitializeComponent();
            LblClnUp.Text += Preferences.SelectedDrive.Name;
            LblHandler.Text = $"{Preferences.CleanupHandlers[0].DisplayName} (Preparing...)";
            HandlerThread = new Thread(new ThreadStart(() =>
            {
                CleanupApi.ReinstateHandlers(Preferences.CleanupHandlers, Preferences.SelectedDrive.Letter);
                // Set up a callback for progress reporting
                CallBacks = new EmptyVolumeCacheCallBacks();
                CallBacks.PurgeProgressChanged += CallBacks_PurgeProgressChanged;
                TotalBytesDeleted = 0;
                ProcessingHandlers = true;
                for (int i = 0; i < Preferences.CleanupHandlers.Count; i++)
                {
                    CurrentHandler = Preferences.CleanupHandlers[i];
                    if (CurrentHandler.PreProcHint != null)
                        RunProcHint(CurrentHandler.PreProcHint);
                    LastHandlerPercent = 0;
                    if (i > 0 && LblHandler.IsHandleCreated)
                        Invoke((MethodInvoker)delegate
                        {
                            LblHandler.Text = $"{CurrentHandler.DisplayName} (Preparing...)";
                        });
                    int spaceResult = CurrentHandler.Instance.GetSpaceUsed(out long newSpaceUsed, CallBacks);
                    if (spaceResult >= 0)
                    {
                        Preferences.CurrentSelectionSavings = Preferences.CurrentSelectionSavings - CurrentHandler.BytesUsed + newSpaceUsed;
                        CurrentHandler.BytesUsed = newSpaceUsed;
                        ReportLastHandlerPercent();
                        int purgeResult = CurrentHandler.Instance.Purge(CurrentHandler.BytesUsed, CallBacks);
                        if (purgeResult == -2147467260) // -2147467260 = 0x80004004 = E_ABORT
                            break;
                        if (purgeResult < 0 && purgeResult != -2147287022) // -2147287022 == 0x80030012 == STG_E_NOMOREFILES
                            MessageBox.Show("Purging " + CurrentHandler.DisplayName + " failed with error 0x" + purgeResult.ToString("x8"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (CurrentHandler.PostProcHint != null)
                            RunProcHint(CurrentHandler.PostProcHint);
                    }
                    try { CurrentHandler.Instance.Deactivate(out uint dummy); } catch { }
                    Marshal.FinalReleaseComObject(CurrentHandler.Instance);
                    if (spaceResult < 0)
                        break;
                }
                ProcessingHandlers = false;
                CleanupApi.DeactivateHandlers(Preferences.CleanupHandlers);
                // A (stupid?) way to close the form once we are done cleaning
                Invoke((MethodInvoker)delegate
                {
                    Close();
                });
            }));
            HandlerThread.SetApartmentState(ApartmentState.STA);
            HandlerThread.Start();
        }

        private void CallBacks_PurgeProgressChanged(object sender, PurgeProgressChangedEventArgs e)
        {
            if (Preferences.CurrentSelectionSavings > 0)
            {
                int ctPerc = (int)((double)(TotalBytesDeleted + e.SpaceFreed) / Preferences.CurrentSelectionSavings * 100);
                if (ctPerc != LastTotalPercent)
                {
                    LastTotalPercent = ctPerc;
                    ReportLastTotalPercent();
                }
                if (CurrentHandler.BytesUsed > 0)
                {
                    int hPerc = Preferences.CleanupHandlers.Count == 1 ? ctPerc : (int)((double)e.SpaceFreed / CurrentHandler.BytesUsed * 100);
                    if (hPerc != LastHandlerPercent)
                    {
                        LastHandlerPercent = hPerc;
                        ReportLastHandlerPercent();
                    }
                }
                if (e.Flags == CallbackFlags.LastNotification)
                {
                    TotalBytesDeleted += CurrentHandler.BytesUsed;
                    LastTotalPercent = (int)((double)TotalBytesDeleted / Preferences.CurrentSelectionSavings * 100);
                    ReportLastTotalPercent();
                }
            }
        }

        private void ReportLastHandlerPercent()
        {
            if (LblHandler.IsHandleCreated)
                Invoke((MethodInvoker)delegate
                {
                    LblHandler.Text = $"{CurrentHandler.DisplayName} ({LastHandlerPercent}%)";
                });
        }

        private void ReportLastTotalPercent()
        {
            if (PrgClean.IsHandleCreated)
                Invoke((MethodInvoker)delegate
                {
                    PrgClean.Value = LastTotalPercent;
                });
        }

        // Get effective filename of process to run for pre/post cleanup actions
        private string GetFirstParam(string line)
        {
            char prevChar = '\0';
            char nextChar = '\0';
            char currentChar = '\0';
            bool inString = false;
            for (int i = 0; i < line.Length; i++)
            {
                currentChar = line[i];
                if (i > 0)
                    prevChar = line[i - 1];
                if (i + 1 < line.Length)
                    nextChar = line[i + 1];
                else
                    nextChar = '\0';
                if (currentChar == '"' && (prevChar == '\0' || prevChar == ' ') && !inString)
                    inString = true;
                if (currentChar == '"' && (nextChar == '\0' || nextChar == ' ') && inString)
                    inString = false;
                if (currentChar == ' ' && !inString)
                    return line.Substring(0, i);
            }
            return line;
        }

        private void RunProcHint(string ProcHint)
        {
            string fileName = GetFirstParam(ProcHint);
            Process p = new Process();
            p.StartInfo.FileName = fileName.Trim('"');
            if (ProcHint.Length > fileName.Length + 1)
                p.StartInfo.Arguments = ProcHint.Substring(fileName.Length + 1);
            try
            {
                p.Start();
                p.WaitForExit();
            }
            catch { MessageBox.Show("Couldn't start the following process: " + ProcHint, Text, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (HandlerThread.IsAlive && ProcessingHandlers)
                CallBacks.Abort = true;
            else
            {
                HandlerThread.Abort();
                Close();
            }
        }
    }
}
