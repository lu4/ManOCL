namespace ManOCL.Internal.OpenCL
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal struct CLEvent
    {
        internal IntPtr Value;
	}
}

