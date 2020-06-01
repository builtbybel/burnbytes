using System;
using System.Runtime.InteropServices;

namespace Burnbytes
{
#pragma warning disable CS0108
    [ComImport, Guid("02b7e3ba-4db3-11d2-b2d9-00c04f8eec8c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEmptyVolumeCache2 : IEmptyVolumeCache
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

        [PreserveSig]
        int InitializeEx(IntPtr hkRegKey, string pcwszVolume, string pcwszKey, out IntPtr ppwszDisplayName, out IntPtr ppwszDescription, out IntPtr ppwszBtnText, out uint pdwFlags);
    }
#pragma warning restore
}
