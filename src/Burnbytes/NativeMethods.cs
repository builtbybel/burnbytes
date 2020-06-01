using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Comet
{
    internal static class NativeMethods
    {
        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int SHLoadIndirectString(string pszSource, StringBuilder pszOutBuf, int cchOutBuf, IntPtr ppvReserved);

        [DllImport("shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion, out IntPtr piSmallVersion, int amountIcons);

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        internal static extern int SHGetFileInfo(string pszPath, int dwFileAttributes, out SHFILEINFO psfi, uint cbfileInfo, int uFlags);

        [DllImport("user32.dll")]
        internal static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        internal static extern int GetSystemMetrics(int nIndex);

        [DllImport("user32.dll")]
        internal static extern int DestroyIcon(IntPtr hIcon);
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct SHFILEINFO
    {
        internal SHFILEINFO(bool b)
        {
            hIcon = IntPtr.Zero;
            iIcon = 0;
            dwAttributes = 0;
            szDisplayName = "";
            szTypeName = "";
        }
        internal IntPtr hIcon;
        internal int iIcon;
        internal uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        internal string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        internal string szTypeName;
    };
}
