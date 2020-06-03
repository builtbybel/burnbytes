using System;

namespace Burnbytes
{
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
}
