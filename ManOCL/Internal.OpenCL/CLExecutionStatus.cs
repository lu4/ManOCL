namespace ManOCL.Internal.OpenCL
{
    using System;

    internal enum CLExecutionStatus : uint
    {
        Complete = 0,
        Queued = 3,
        Running = 1,
        Submitted = 2
    }
}

