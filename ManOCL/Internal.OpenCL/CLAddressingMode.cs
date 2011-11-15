namespace ManOCL.Internal.OpenCL
{
    using System;

    internal enum CLAddressingMode : uint
    {
        Clamp = 0x1132,
        ClampToEdge = 0x1131,
        None = 0x1130,
        Repeat = 0x1133
    }
}

