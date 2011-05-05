namespace ManOCL.Native
{
    using System;

    public enum ExecutionStatus : uint
    {
        Complete = 0,
        Queued = 3,
        Running = 1,
        Submitted = 2
    }
}
