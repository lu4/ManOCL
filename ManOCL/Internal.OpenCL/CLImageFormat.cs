namespace ManOCL.Internal.OpenCL
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal struct CLImageFormat
    {
        internal CLChannelOrder image_channel_order;
        internal CLChannelType image_channel_data_type;
    }
}

