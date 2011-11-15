namespace ManOCL.Internal.OpenCL
{
    using System;

    internal enum CLDeviceType : ulong
    {
        Accelerator = 8L,
        All = 0xffffffffL,
        CPU = 2L,
        Default = 1L,
        GPU = 4L
    }
}

