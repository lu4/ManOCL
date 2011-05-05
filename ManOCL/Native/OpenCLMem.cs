namespace ManOCL.Native
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct OpenCLMem
    {
        public static readonly OpenCLMem None = new OpenCLMem() { Value = IntPtr.Zero };

        public IntPtr Value;
    }
}
