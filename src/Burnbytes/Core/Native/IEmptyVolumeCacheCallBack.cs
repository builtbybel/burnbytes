using System;
using System.Runtime.InteropServices;

namespace Burnbytes
{
    [ComImport, Guid("6E793361-73C6-11D0-8469-00AA00442901"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEmptyVolumeCacheCallBack
    {
        [PreserveSig]
        int ScanProgress(long dwlSpaceUsed, uint dwFlags, IntPtr pcwszStatus);

        [PreserveSig]
        int PurgeProgress(long dwlSpaceFreed, long dwlSpaceToFree, uint dwFlags, IntPtr pcwszStatus);
    }
}
