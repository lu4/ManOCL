namespace ManOCL.Internal.OpenCL
{
    using System;

    internal enum CLCommandQueueInfo : uint
    {
        Context = 0x1090,
        Device = 0x1091,
        Properties = 0x1093,
        ReferenceCount = 0x1092
    }
}

