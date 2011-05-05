using System;
using System.Text;
using ManOCL.Native;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ManOCL
{
    public abstract class Argument
    {
        internal abstract IntPtr IntPtr { get; }
        internal abstract IntPtr IntPtrSize { get; }
    }
}
