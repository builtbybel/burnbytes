using System;

namespace Burnbytes
{
    [Flags]
    public enum CallbackFlags : uint
    {
        None = 0,
        LastNotification = 1
    }
}
