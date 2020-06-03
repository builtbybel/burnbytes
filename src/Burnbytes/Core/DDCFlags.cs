using System;

namespace Burnbytes
{
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
}
