namespace ManOCL.Native
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct ImageFormat
    {
        public ChannelOrder image_channel_order;
        public ChannelType image_channel_data_type;
    }
}
