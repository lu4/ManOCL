using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using ManOCL.Native;

namespace ManOCL
{
    public class DeviceLocalMemory : Argument
    {
        private IntPtr size;

        internal DeviceLocalMemory(IntPtr size)
        {
            this.size = size;
        }

        internal override IntPtr IntPtr
        {
            get { return IntPtr.Zero; }
        }
        internal override IntPtr IntPtrSize
        {
            get { throw new NotImplementedException(); }
        }

        public static DeviceLocalMemory CreateWithSize(Int32 bytes)
        {
            return new DeviceLocalMemory(new IntPtr(bytes));
        }
        public static DeviceLocalMemory CreateWithSize(Int64 bytes)
        {
            return new DeviceLocalMemory(new IntPtr(bytes));
        }
    }
}
