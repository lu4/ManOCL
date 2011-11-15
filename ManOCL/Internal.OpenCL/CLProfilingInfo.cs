namespace ManOCL.Internal.OpenCL
{
    using System;

    internal enum CLProfilingInfo : uint
    {
        End = 0x1283,
        Queued = 0x1280,
        Start = 0x1282,
        Submit = 0x1281
    }
}

