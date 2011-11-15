using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManOCL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Mem
    {
        internal IntPtr Value;
    }
}
