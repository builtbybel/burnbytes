using Burnbytes.Properties;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Burnbytes.Forms
{
    public partial class Cleaner : FormBase
    {
        // Events

        protected override void OnLocalize()
        {
            base.OnLocalize();

            Resources.ResourceManager.Localize<Cleaner>
                (
                    lblDescription,
                    lblCleanup,
                    lblCleaning,
                    btnCancel
                );


            lblCleanup.Text += Preferences.SelectedDrive.Name;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Run();
        }

        // Fields

        private Thread _thread;
        private long _totalBytesDeleted;
        private int _lastTotalPercent;
        private EmptyVolumeCacheCallBacks _callBacks;
        private bool _processingHandlers;
        private int _lastHandlerPercent;
        private CleanupHandler _currentHandler;

        // Constructors

        public Cleaner() : base() => InitializeComponent();

        // Methods

        private void ReportLastHandlerPercent()
        {
            if (lblCurrentHandler.IsHandleCreated)
                Invoke((MethodInvoker)delegate
                {
                    lblCurrentHandler.Text = $"{_currentHandler.DisplayName} ({_lastHandlerPercent}%)";
                });
        }

        private void ReportLastTotalPercent()
        {
            if (prgCleaning.IsHandleCreated)
                Invoke((MethodInvoker)delegate
                {
                    prgCleaning.Value = _lastTotalPercent;
                });
        }

        private string GetFirstParam(string line)
        {
            // Get effective filename of process to run for pre/post cleanup actions

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

        private void Run()
        {
            lblCurrentHandler.Text = Resources.Label_Preparing.Format(Preferences.CleanupHandlers[0].DisplayName);

            _thread = new Thread(new ThreadStart(() =>
            {
                CleanupApi.ReinstateHandlers(Preferences.CleanupHandlers, Preferences.SelectedDrive.Letter);
                // Set up a callback for progress reporting
                _callBacks = new EmptyVolumeCacheCallBacks();
                _callBacks.PurgeProgressChanged += CallBacks_PurgeProgressChanged;
                _totalBytesDeleted = 0;
                _processingHandlers = true;
                for (int i = 0; i < Preferences.CleanupHandlers.Count; i++)
                {
                    _currentHandler = Preferences.CleanupHandlers[i];
                    if (_currentHandler.PreProcHint != null)
                        RunProcHint(_currentHandler.PreProcHint);
                    _lastHandlerPercent = 0;
                    if (i > 0 && lblCurrentHandler.IsHandleCreated)
                        Invoke((MethodInvoker)delegate
                        {
                            lblCurrentHandler.Text = Resources.Label_Preparing.Format(_currentHandler.DisplayName);
                        });
                    int spaceResult = _currentHandler.Instance.GetSpaceUsed(out long newSpaceUsed, _callBacks);
                    if (spaceResult >= 0)
                    {
                        Preferences.CurrentSelectionSavings = Preferences.CurrentSelectionSavings - _currentHandler.BytesUsed + newSpaceUsed;
                        _currentHandler.BytesUsed = newSpaceUsed;
                        ReportLastHandlerPercent();
                        int purgeResult = _currentHandler.Instance.Purge(_currentHandler.BytesUsed, _callBacks);
                        if (purgeResult == -2147467260) // -2147467260 = 0x80004004 = E_ABORT
                            break;
                        if (purgeResult < 0 && purgeResult != -2147287022) // -2147287022 == 0x80030012 == STG_E_NOMOREFILES
                            MessageBox.Show("Purging " + _currentHandler.DisplayName + " failed with error 0x" + purgeResult.ToString("x8"), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (_currentHandler.PostProcHint != null)
                            RunProcHint(_currentHandler.PostProcHint);
                    }
                    try { _currentHandler.Instance.Deactivate(out uint dummy); } catch { }
                    Marshal.FinalReleaseComObject(_currentHandler.Instance);
                    if (spaceResult < 0)
                        break;
                }
                _processingHandlers = false;
                CleanupApi.DeactivateHandlers(Preferences.CleanupHandlers);
                // A (stupid?) way to close the form once we are done cleaning
                Invoke((MethodInvoker)delegate
                {
                    Close();
                });
            }));

            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
        }

        // EventHandlers

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (_thread.IsAlive && _processingHandlers)
                _callBacks.Abort = true;
            else
            {
                _thread.Abort();
                Close();
            }
        }

        private void CallBacks_PurgeProgressChanged(object sender, PurgeProgressChangedEventArgs e)
        {
            if (Preferences.CurrentSelectionSavings > 0)
            {
                int ctPerc = (int)((double)(_totalBytesDeleted + e.SpaceFreed) / Preferences.CurrentSelectionSavings * 100);
                if (ctPerc != _lastTotalPercent)
                {
                    _lastTotalPercent = ctPerc;
                    ReportLastTotalPercent();
                }
                if (_currentHandler.BytesUsed > 0)
                {
                    int hPerc = Preferences.CleanupHandlers.Count == 1 ? ctPerc : (int)((double)e.SpaceFreed / _currentHandler.BytesUsed * 100);
                    if (hPerc != _lastHandlerPercent)
                    {
                        _lastHandlerPercent = hPerc;
                        ReportLastHandlerPercent();
                    }
                }
                if (e.Flags == CallbackFlags.LastNotification)
                {
                    _totalBytesDeleted += _currentHandler.BytesUsed;
                    _lastTotalPercent = (int)((double)_totalBytesDeleted / Preferences.CurrentSelectionSavings * 100);
                    ReportLastTotalPercent();
                }
            }
        }
    }
}
