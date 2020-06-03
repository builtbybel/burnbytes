using System;

namespace Burnbytes
{
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
}
