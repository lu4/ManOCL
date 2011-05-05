namespace ManOCL
{
    using System;

    public enum DeviceFPConfig : ulong
    {
        Denorm = 1L,
        FMA = 0x20L,
        InfNan = 2L,
        RoundToInf = 0x10L,
        RoundToNearest = 4L,
        RoundToZero = 8L
    }
}
