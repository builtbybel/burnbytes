using System;
using System.Runtime.InteropServices;

namespace Burnbytes
{
    [ComImport, Guid("8FCE5227-04DA-11d1-A004-00805F8ABE06"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEmptyVolumeCache
    {
        [PreserveSig]
        int Initialize(IntPtr hkRegKey, string pcwszVolume, out IntPtr ppwszDisplayName, out IntPtr ppwszDescription, out uint pdwFlags);

        [PreserveSig]
        int GetSpaceUsed(out long pdwlSpaceUsed, IEmptyVolumeCacheCallBack picb);

        [PreserveSig]
        int Purge(long dwlSpaceToFree, IEmptyVolumeCacheCallBack picb);

        [PreserveSig]
        int ShowProperties(IntPtr hwnd);

        [PreserveSig]
        int Deactivate(out uint pdwFlags);
    }
}
