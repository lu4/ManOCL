namespace ManOCL.Internal.OpenCL
{
    using System;

    internal enum CLMemInfo : uint
    {
        Context = 0x1106,
        Flags = 0x1101,
        HostPtr = 0x1103,
        MapCount = 0x1104,
        ReferenceCount = 0x1105,
        Size = 0x1102,
        Type = 0x1100
    }
}

