namespace ManOCL.Internal.OpenCL
{
    using System;

    internal enum CLEventInfo : uint
    {
        CommandExecutionStatus = 0x11d3,
        CommandQueue = 0x11d0,
        CommandType = 0x11d1,
        ReferenceCount = 0x11d2
    }
}

