namespace ManOCL.Internal.OpenCL
{
    using System;

    internal enum CLChannelType : uint
    {
        Float = 0x10de,
        HalfFloat = 0x10dd,
        SignedInt16 = 0x10d8,
        SignedInt32 = 0x10d9,
        SignedInt8 = 0x10d7,
        SNormInt16 = 0x10d1,
        SNormInt8 = 0x10d0,
        UNormInt101010 = 0x10d6,
        UNormInt16 = 0x10d3,
        UNormInt8 = 0x10d2,
        UNormShort555 = 0x10d5,
        UNormShort565 = 0x10d4,
        UnSignedInt16 = 0x10db,
        UnSignedInt32 = 0x10dc,
        UnSignedInt8 = 0x10da
    }
}

