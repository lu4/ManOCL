namespace ManOCL.Internal.OpenCL
{
    using System;

    internal enum CLCommandType : uint
    {
        AcquireGLObjects = 0x11ff,
        CopyBuffer = 0x11f5,
        CopyBufferToImage = 0x11fa,
        CopyImage = 0x11f8,
        CopyImageToBuffer = 0x11f9,
        MapBuffer = 0x11fb,
        MapImage = 0x11fc,
        Marker = 0x11fe,
        NativeKernel = 0x11f2,
        NDRangeKernel = 0x11f0,
        ReadBuffer = 0x11f3,
        ReadImage = 0x11f6,
        ReleaseGLObjects = 0x1200,
        Task = 0x11f1,
        UnmapMemObject = 0x11fd,
        WriteBuffer = 0x11f4,
        WriteImage = 0x11f7
    }
}

