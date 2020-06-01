using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Comet
{
    public static class Api
    {
        public const string VolumeCacheStoreKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\VolumeCaches\";

        public static CleanupHandler InitializeHandler(string VolumeCacheName, string TargetDriveLetter)
        {
            CleanupHandler evcProps = new CleanupHandler() { DefaultName = VolumeCacheName };
            using (RegistryKey rKey = Registry.LocalMachine.OpenSubKey(VolumeCacheStoreKey + VolumeCacheName, false))
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

        public static void ReinstateHandlers(List<CleanupHandler> CleanupHandlers, string TargetDriveLetter)
        {
            foreach (CleanupHandler evp in CleanupHandlers)
            {
                string keyPath = string.Format("{0}\\{1}", VolumeCacheStoreKey, evp.DefaultName);
                object evcInstance = Activator.CreateInstance(Type.GetTypeFromCLSID(evp.HandlerGuid));
                using (RegistryKey rKey = Registry.LocalMachine.OpenSubKey(keyPath, false))
                {
                    if (evcInstance is IEmptyVolumeCache2 ex2Instance)
                    {
                        int initRes = ex2Instance.InitializeEx(rKey.Handle.DangerousGetHandle(), TargetDriveLetter, evp.DefaultName, out IntPtr ppwszDisplayName, out IntPtr ppwszDescription, out IntPtr ppwszBtnText, out uint pdwFlags);
                        if (initRes != 0)
                        {
                            try { ex2Instance.Deactivate(out uint dummy); } catch { }
                            Marshal.FinalReleaseComObject(ex2Instance);
                        }
                        evp.Instance = ex2Instance;
                    }
                    else
                    {
                        IEmptyVolumeCache vcInstance = (IEmptyVolumeCache)evcInstance;
                        int initRes = vcInstance.Initialize(rKey.Handle.DangerousGetHandle(), TargetDriveLetter, out IntPtr ppwszDisplayName, out IntPtr ppwszDescription, out uint pdwFlags);
                        if (initRes != 0)
                        {
                            try { vcInstance.Deactivate(out uint dummy); } catch { }
                            Marshal.FinalReleaseComObject(vcInstance);
                        }
                        evp.Instance = vcInstance;
                    }
                }
            }
        }

        public static void DeactivateHandlers(List<CleanupHandler> CleanupHandlers)
        {
            foreach (CleanupHandler evp in CleanupHandlers)
            {
                try { evp.Instance.Deactivate(out uint dummy); } catch { }
                Marshal.FinalReleaseComObject(evp.Instance);
            }
        }

        public static void UpdateHandlerStateFlag(CleanupHandler HandlerObj)
        {
            using (RegistryKey rKey = Registry.LocalMachine.OpenSubKey(VolumeCacheStoreKey + HandlerObj.DefaultName, true))
                rKey.SetValue("StateFlags", HandlerObj.StateFlag ? 1 : 0);
        }
    }

    public class DriveStrings
    {
        public string Letter { get; set; }
        public string Name { get; set; }
    }

    public class CleanupHandler
    {
        public Guid HandlerGuid { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string ButtonText { get; set; }
        public HandlerFlags Flags { get; set; }
        public IEmptyVolumeCache Instance { get; set; }
        public long BytesUsed { get; set; }
        public object IconHint { get; set; }
        public DDCFlags DataDrivenFlags { get; set; }
        public uint Priority { get; set; }
        public string PreProcHint { get; set; }
        public string PostProcHint { get; set; }
        public string DefaultName { get; set; }
        public bool StateFlag { get; set; }
    }

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

    [ComImport, Guid("6E793361-73C6-11D0-8469-00AA00442901"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEmptyVolumeCacheCallBack
    {
        [PreserveSig]
        int ScanProgress(long dwlSpaceUsed, uint dwFlags, IntPtr pcwszStatus);
        [PreserveSig]
        int PurgeProgress(long dwlSpaceFreed, long dwlSpaceToFree, uint dwFlags, IntPtr pcwszStatus);
    }

    [ComImport, Guid("55272A00-42CB-11CE-8135-00AA004BB851"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPropertyBag
    {
        [PreserveSig]
        int Read(string pszPropName, ref object pVar, IntPtr pErrorLog);
        [PreserveSig]
        int Write(string pszPropName, IntPtr pVar);
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class EmptyVolumeCacheCallBacks : IEmptyVolumeCacheCallBack
    {
        // -2147467260 = 0x80004004 = E_ABORT
        public int ScanProgress(long dwlSpaceUsed, uint dwFlags, IntPtr pcwszStatus)
        {
            if (Abort)
                return -2147467260;
            OnScanProgressChanged(new ScanProgressChangedEventArgs() { SpaceUsed = dwlSpaceUsed, Flags = (CallbackFlags)dwFlags });
            return 0;
        }

        public int PurgeProgress(long dwlSpaceFreed, long dwlSpaceToFree, uint dwFlags, IntPtr pcwszStatus)
        {
            if (Abort)
                return -2147467260;
            OnPurgeProgressChanged(new PurgeProgressChangedEventArgs() { SpaceFreed = dwlSpaceFreed, SpaceToFree = dwlSpaceToFree, Flags = (CallbackFlags)dwFlags });
            return 0;
        }

        public event EventHandler<ScanProgressChangedEventArgs> ScanProgressChanged;

        [ComVisible(false)]
        protected virtual void OnScanProgressChanged(ScanProgressChangedEventArgs e)
        {
            ScanProgressChanged?.Invoke(this, e);
        }

        public event EventHandler<PurgeProgressChangedEventArgs> PurgeProgressChanged;

        [ComVisible(false)]
        protected virtual void OnPurgeProgressChanged(PurgeProgressChangedEventArgs e)
        {
            PurgeProgressChanged?.Invoke(this, e);
        }

        [ComVisible(false)]
        public bool Abort = false;
    }

    public class ScanProgressChangedEventArgs : EventArgs
    {
        public long SpaceUsed { get; set; }
        public CallbackFlags Flags { get; set; }
    }

    public class PurgeProgressChangedEventArgs : EventArgs
    {
        public long SpaceFreed { get; set; }
        public long SpaceToFree { get; set; }
        public CallbackFlags Flags { get; set; }
    }

    [Flags]
    public enum HandlerFlags : uint
    {
        None = 0,
        HasSettings = 1,
        EnableByDefault = 2,
        RemoveFromList = 4,
        EnableByDefaultAuto = 8,
        DontShowIfZero = 16,
        SettingsMode = 32,
        OutOfDiskSpace = 64,
        UserConsentObtained = 128
    }

    [Flags]
    public enum DDCFlags : uint
    {
        None = 0,
        DoSubDirs = 1,
        RemoveAfterClean = 2,
        RemoveReadOnly = 4,
        RemoveSystem = 8,
        RemoveHidden = 16,
        DontShowIfZero = 32,
        RemoveDirs = 64,
        RunIfOutOfDiskSpace = 128,
        RemoveParentDir = 256,
        PrivateLastAccess = 268435456
    }

    [Flags]
    public enum CallbackFlags : uint
    {
        None = 0,
        LastNotification = 1
    }
}
