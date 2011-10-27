namespace ManOCL.Internal.OpenCL
{
    using System;

    internal enum CLKernelWorkGroupInfo : uint
    {
        CompileWithWorkGroupSize = 0x11b1,
        LocalMemSize = 0x11b2,
        WorkGroupSize = 0x11b0
    }
}

