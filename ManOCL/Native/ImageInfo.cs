namespace ManOCL.Native
{
    using System;

    public enum ImageInfo : uint
    {
        Depth = 0x1116,
        ElementSize = 0x1111,
        Format = 0x1110,
        Height = 0x1115,
        RowPitch = 0x1112,
        SlicePitch = 0x1113,
        Width = 0x1114
    }
}
