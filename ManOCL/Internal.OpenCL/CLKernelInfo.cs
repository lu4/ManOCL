namespace ManOCL.Internal.OpenCL
{
    using System;

    internal enum CLKernelInfo : uint
    {
        Context = 0x1193,
        FunctionName = 0x1190,
        NumArgs = 0x1191,
        Program = 0x1194,
        ReferenceCount = 0x1192
    }
}

