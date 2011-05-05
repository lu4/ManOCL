namespace ManOCL.Native
{
    using System;

    public enum KernelInfo : uint
    {
        Context = 0x1193,
        FunctionName = 0x1190,
        NumArgs = 0x1191,
        Program = 0x1194,
        ReferenceCount = 0x1192
    }
}
