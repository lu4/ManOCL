namespace ManOCL.Native
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct OpenCLPlatform
    {
        public IntPtr Value;


        public OpenCLPlatform(IntPtr value)
        {
            this.Value = value;
        }

        public static readonly OpenCLPlatform None = new OpenCLPlatform(IntPtr.Zero);
    }
}
