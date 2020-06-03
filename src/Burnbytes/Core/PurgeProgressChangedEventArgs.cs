using System;

namespace Burnbytes
{
    public class PurgeProgressChangedEventArgs : EventArgs
    {
        public PurgeProgressChangedEventArgs(long spaceFreed, long spaceToFree, CallbackFlags flags)
        {
            SpaceFreed = spaceFreed;
            SpaceToFree = spaceToFree;
            Flags = flags;
        }

        public long SpaceFreed { get; }

        public long SpaceToFree { get; }

        public CallbackFlags Flags { get; }
    }
}
