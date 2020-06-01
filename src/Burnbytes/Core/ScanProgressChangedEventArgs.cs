using System;

namespace Burnbytes
{
    public class ScanProgressChangedEventArgs : EventArgs
    {
        public ScanProgressChangedEventArgs(long spaceUsed, CallbackFlags flags) => (SpaceUsed, Flags) = (spaceUsed, flags);


        public long SpaceUsed { get; }

        public CallbackFlags Flags { get; }
    }
}
