using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManOCL.Internal;
using ManOCL.Internal.OpenCL;


namespace ManOCL
{
    public class ValueArgument<T> : Argument
        where T : struct
    {
        public T Value { get; private set; }

        public ValueArgument(T value)
        {
			this.Value = value;
		}

		internal override void SetAsKernelArgument(CLKernel kernel, int index)
		{
			GCHandle handle = GCHandle.Alloc(Value, GCHandleType.Pinned);
			
			try
			{
            	OpenCLError.Validate(OpenCLDriver.clSetKernelArg(kernel, index, new SizeT(Marshal.SizeOf(typeof(T))), handle.AddrOfPinnedObject()));
			}
			finally
			{
				handle.Free();
			}
		}
		
        public static implicit operator ValueArgument<T>(T value)
        {
            return new ValueArgument<T>(value);
        }
    }
}
