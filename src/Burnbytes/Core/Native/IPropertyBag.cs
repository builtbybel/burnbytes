using System;
using System.Runtime.InteropServices;

namespace Burnbytes
{
    [ComImport, Guid("55272A00-42CB-11CE-8135-00AA004BB851"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPropertyBag
    {
        [PreserveSig]
        int Read(string pszPropName, ref object pVar, IntPtr pErrorLog);

        [PreserveSig]
        int Write(string pszPropName, IntPtr pVar);
    }
}
