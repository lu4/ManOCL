namespace ManOCL.Internal.OpenCL
{
    using System;

    internal enum CLProgramInfo : uint
    {
        Binaries = 0x1166,
        BinarySizes = 0x1165,
        Context = 0x1161,
        Devices = 0x1163,
        NumDevices = 0x1162,
        ReferenceCount = 0x1160,
        Source = 0x1164
    }
}

