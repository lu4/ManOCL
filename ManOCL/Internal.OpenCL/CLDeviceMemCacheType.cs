namespace ManOCL.Internal.OpenCL
{
    using System;

    internal enum CLDeviceMemCacheType : uint
    {
        None = 0,
        ReadOnlyCache = 1,
        ReadWriteCache = 2
    }
}

