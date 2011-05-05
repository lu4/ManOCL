namespace ManOCL.Native
{
    using System;

    public enum MemObjectType : uint
    {
        Buffer = 0x10f0,
        Image2D = 0x10f1,
        Image3D = 0x10f2
    }
}
