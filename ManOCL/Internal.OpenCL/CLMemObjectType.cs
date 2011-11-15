namespace ManOCL.Internal.OpenCL
{
    using System;

    internal enum CLMemObjectType : uint
    {
        Buffer = 0x10f0,
        Image2D = 0x10f1,
        Image3D = 0x10f2
    }
}

