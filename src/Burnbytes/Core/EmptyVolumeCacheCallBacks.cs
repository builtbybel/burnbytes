using System;
using System.Runtime.InteropServices;

namespace Burnbytes
{
    [ClassInterface(ClassInterfaceType.None)]
    public class EmptyVolumeCacheCallBacks : IEmptyVolumeCacheCallBack
    {
        // -2147467260 = 0x80004004 = E_ABORT
        public int ScanProgress(long dwlSpaceUsed, uint dwFlags, IntPtr pcwszStatus)
        {
            if (Abort)
                return -2147467260;

            OnScanProgressChanged(new ScanProgressChangedEventArgs(dwlSpaceUsed, (CallbackFlags)dwFlags));
            return 0;
        }

        public int PurgeProgress(long dwlSpaceFreed, long dwlSpaceToFree, uint dwFlags, IntPtr pcwszStatus)
        {
            if (Abort)
                return -2147467260;

            OnPurgeProgressChanged(new PurgeProgressChangedEventArgs(dwlSpaceFreed, dwlSpaceToFree, (CallbackFlags)dwFlags));
            return 0;
        }

        public event EventHandler<ScanProgressChangedEventArgs> ScanProgressChanged;

        [ComVisible(false)]
        protected virtual void OnScanProgressChanged(ScanProgressChangedEventArgs e) => ScanProgressChanged?.Invoke(this, e);


        public event EventHandler<PurgeProgressChangedEventArgs> PurgeProgressChanged;

        [ComVisible(false)]
        protected virtual void OnPurgeProgressChanged(PurgeProgressChangedEventArgs e) => PurgeProgressChanged?.Invoke(this, e);


        [ComVisible(false)]
        public bool Abort = false;
    }
}
