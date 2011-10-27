using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using ManOCL.Internal.OpenCL;

namespace ManOCL
{
    public class DeviceLocalMemory : Argument
    {
        private IntPtr size;

        internal DeviceLocalMemory(IntPtr size)
        {
            this.size = size;
        }

        internal IntPtr IntPtr
        {
            get { return IntPtr.Zero; }
        }
        internal IntPtr IntPtrSize
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
		
		internal override void SetAsKernelArgument (CLKernel kernel, int index)
		{
			throw new NotImplementedException ();
		}
    }
}
