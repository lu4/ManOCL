namespace ManOCL.Native
{
    using System;

    public enum ChannelOrder : uint
    {
        A = 0x10b1,
        ARGB = 0x10b7,
        BGRA = 0x10b6,
        Intensity = 0x10b8,
        Luminance = 0x10b9,
        R = 0x10b0,
        RA = 0x10b3,
        RG = 0x10b2,
        RGB = 0x10b4,
        RGBA = 0x10b5
    }
}
