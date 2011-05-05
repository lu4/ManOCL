namespace ManOCL.Native
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct OpenCLSampler
    {
        public IntPtr Value;
    }
}
