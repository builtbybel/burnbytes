using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Burnbytes
{
    public static class CleanupApi
    {
        public const string VolumeCacheStoreKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VolumeCaches\";

        public static CleanupHandler InitializeHandler(string VolumeCacheName, string TargetDriveLetter)
        {
            var evcProps = new CleanupHandler() { DefaultName = VolumeCacheName };
            using (var rKey = Registry.LocalMachine.OpenSubKey(VolumeCacheStoreKey + VolumeCacheName, false))
            {
                // StateFlags specify if a particular handler was used last time Disk Cleanup ran as Administrator
                evcProps.StateFlag = (int)rKey.GetValue("StateFlags", 0) == 0 ? false : true;
                evcProps.HandlerGuid = new Guid((string)rKey.GetValue(null));
                object evcInstance;
                // This is needed due to Data Driven Cleaner {C0E13E61-0CC6-11d1-BBB6-0060978B2AE6} always throwing E_NOTIMPLEMENTED on <= Windows 7
                try { evcInstance = Activator.CreateInstance(Type.GetTypeFromCLSID(evcProps.HandlerGuid)); }
                catch
                {
                    //System.Windows.Forms.MessageBox.Show(evcProps.HandlerGuid.ToString(), "Failed to load provider");
                    return null;
                }
                // Check if newer interface with InitializeEx is available
                if (evcInstance is IEmptyVolumeCache2 ex2Instance)
                {
                    int initRes = ex2Instance.InitializeEx(rKey.Handle.DangerousGetHandle(), TargetDriveLetter, VolumeCacheName, out IntPtr ppwszDisplayName, out IntPtr ppwszDescription, out IntPtr ppwszBtnText, out uint pdwFlags);
                    // Discard handler if initialization failed
                    if (initRes != 0)
                    {
                        try { ex2Instance.Deactivate(out uint dummy); } catch { }
                        Marshal.FinalReleaseComObject(ex2Instance);
                        return null;
                    }
                    evcProps.DisplayName = Marshal.PtrToStringAuto(ppwszDisplayName);
                    evcProps.Description = Marshal.PtrToStringAuto(ppwszDescription);
                    evcProps.ButtonText = Marshal.PtrToStringAuto(ppwszBtnText);
                    evcProps.Flags = (HandlerFlags)pdwFlags;
                    evcProps.Instance = ex2Instance;
                }
                else
                {
                    // It appears that only the old interface is available
                    IEmptyVolumeCache vcInstance = (IEmptyVolumeCache)evcInstance;
                    int initRes = vcInstance.Initialize(rKey.Handle.DangerousGetHandle(), TargetDriveLetter, out IntPtr ppwszDisplayName, out IntPtr ppwszDescription, out uint pdwFlags);
                    // Discard handler if initialization failed
                    if (initRes != 0)
                    {
                        try { vcInstance.Deactivate(out uint dummy); } catch { }
                        Marshal.FinalReleaseComObject(vcInstance);
                        return null;
                    }
                    evcProps.DisplayName = Marshal.PtrToStringAuto(ppwszDisplayName);
                    evcProps.Description = Marshal.PtrToStringAuto(ppwszDescription);
                    evcProps.Flags = (HandlerFlags)pdwFlags;
                    evcProps.Instance = vcInstance;
                }
                evcProps.IconHint = rKey.GetValue("IconPath", null);
                if (evcProps.IconHint == null)
                {
                    // Icons can sometimes be provided by the DefaultIcon of a handler's class
                    RegistryKey hkrKey = Registry.ClassesRoot.OpenSubKey(string.Format("CLSID\\{{{0}}}\\DefaultIcon", evcProps.HandlerGuid));
                    if (hkrKey != null)
                    {
                        evcProps.IconHint = (string)hkrKey.GetValue(null);
                        hkrKey.Close();
                    }
                }
                evcProps.PreProcHint = (string)rKey.GetValue("PreCleanupString", null);
                evcProps.PostProcHint = (string)rKey.GetValue("CleanupString", null);
                #region Multi-Type registry value to uint loader
                object optValObj = rKey.GetValue("Flags");
                if (optValObj != null)
                {
                    RegistryValueKind optValKind = rKey.GetValueKind("Flags");
                    uint optVal = 0;
                    switch (optValKind)
                    {
                        case RegistryValueKind.Binary:
                            optVal = BitConverter.ToUInt32((byte[])optValObj, 0);
                            break;
                        case RegistryValueKind.DWord:
                            optVal = (uint)(int)optValObj;
                            break;
                    }
                    if (optVal > 0)
                        evcProps.DataDrivenFlags = (DDCFlags)optVal;
                }
                optValObj = rKey.GetValue("Priority");
                if (optValObj != null)
                {
                    RegistryValueKind optValKind = rKey.GetValueKind("Priority");
                    uint optVal = 0;
                    switch (optValKind)
                    {
                        case RegistryValueKind.Binary:
                            optVal = BitConverter.ToUInt32((byte[])optValObj, 0);
                            break;
                        case RegistryValueKind.DWord:
                            optVal = (uint)(int)optValObj;
                            break;
                    }
                    if (optVal > 0)
                        evcProps.Priority = optVal;
                }
                #endregion
                // Multiple paths strike again, we check if there's a Property Bag or PE resource contain strings in case we still have none loaded
                if (evcProps.DisplayName == null)
                {
                    string optionalValue = (string)rKey.GetValue("PropertyBag", null);
                    if (optionalValue != null)
                    {
                        IPropertyBag pbInstance = (IPropertyBag)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid(optionalValue)));
                        object bagContent = "";
                        if (pbInstance.Read("display", ref bagContent, IntPtr.Zero) == 0)
                            evcProps.DisplayName = (string)bagContent;
                        if (pbInstance.Read("Description", ref bagContent, IntPtr.Zero) == 0)
                            evcProps.Description = (string)bagContent;
                        if (pbInstance.Read("AdvancedButtonText", ref bagContent, IntPtr.Zero) == 0)
                            evcProps.ButtonText = (string)bagContent;
                        Marshal.FinalReleaseComObject(pbInstance);
                        return evcProps;
                    }
                    optionalValue = (string)rKey.GetValue("display", null);
                    if (optionalValue != null)
                    {
                        StringBuilder strBld = new StringBuilder(513);
                        NativeMethods.SHLoadIndirectString(optionalValue, strBld, 513, IntPtr.Zero);
                        evcProps.DisplayName = strBld.ToString();
                        optionalValue = (string)rKey.GetValue("Description", null);
                        strBld.Clear();
                        NativeMethods.SHLoadIndirectString(optionalValue, strBld, 513, IntPtr.Zero);
                        evcProps.Description = strBld.ToString();
                        optionalValue = (string)rKey.GetValue("AdvancedButtonText", null);
                        strBld.Clear();
                        NativeMethods.SHLoadIndirectString(optionalValue, strBld, 513, IntPtr.Zero);
                        evcProps.ButtonText = strBld.ToString();
                        return evcProps;
                    }
                }
            }
            if (evcProps.DisplayName == null)
                evcProps.DisplayName = VolumeCacheName;
            return evcProps;
        }

        public static void ReinstateHandlers(List<CleanupHandler> cleanupHandlers, string targetDriveLetter)
        {
            foreach (var cleanupHandler in cleanupHandlers)
            {
                string keyPath = string.Format("{0}\\{1}", VolumeCacheStoreKey, cleanupHandler.DefaultName);
                object evcInstance = Activator.CreateInstance(Type.GetTypeFromCLSID(cleanupHandler.HandlerGuid));
                using (RegistryKey rKey = Registry.LocalMachine.OpenSubKey(keyPath, false))
                {
                    if (evcInstance is IEmptyVolumeCache2 ex2Instance)
                    {
                        int initRes = ex2Instance.InitializeEx(rKey.Handle.DangerousGetHandle(), targetDriveLetter, cleanupHandler.DefaultName, out IntPtr ppwszDisplayName, out IntPtr ppwszDescription, out IntPtr ppwszBtnText, out uint pdwFlags);
                        if (initRes != 0)
                        {
                            try { ex2Instance.Deactivate(out uint dummy); } catch { }
                            Marshal.FinalReleaseComObject(ex2Instance);
                        }
                        cleanupHandler.Instance = ex2Instance;
                    }
                    else
                    {
                        var vcInstance = (IEmptyVolumeCache)evcInstance;
                        int initRes = vcInstance.Initialize(rKey.Handle.DangerousGetHandle(), targetDriveLetter, out IntPtr ppwszDisplayName, out IntPtr ppwszDescription, out uint pdwFlags);
                        if (initRes != 0)
                        {
                            try { vcInstance.Deactivate(out uint dummy); } catch { }
                            Marshal.FinalReleaseComObject(vcInstance);
                        }
                        cleanupHandler.Instance = vcInstance;
                    }
                }
            }
        }

        public static void DeactivateHandlers(List<CleanupHandler> cleanupHandlers)
        {
            foreach (var cleanupHandler in cleanupHandlers)
            {
                try { cleanupHandler.Instance.Deactivate(out uint dummy); } catch { }
                Marshal.FinalReleaseComObject(cleanupHandler.Instance);
            }
        }

        public static void UpdateHandlerStateFlag(CleanupHandler cleanupHandler)
        {
            using (var rKey = Registry.LocalMachine.OpenSubKey(VolumeCacheStoreKey + cleanupHandler.DefaultName, true))
                rKey.SetValue("StateFlags", cleanupHandler.StateFlag ? 1 : 0);
        }
    }
}
