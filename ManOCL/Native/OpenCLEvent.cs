namespace ManOCL.Native
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct OpenCLEvent
    {
        public static readonly OpenCLEvent None = new OpenCLEvent() { Value = IntPtr.Zero };

        public IntPtr Value;
    }
}
