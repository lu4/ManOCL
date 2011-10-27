using System;
using System.Text;
using ManOCL.Internal.OpenCL;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ManOCL
{
    public abstract class Argument
    {
		internal abstract void SetAsKernelArgument(CLKernel kernel, Int32 index);

		internal static CLMemFlags GetMemFlags(DeviceBufferAccess access)
        {
            if (access == DeviceBufferAccess.ReadWrite)
            {
                return CLMemFlags.ReadWrite;
            }
            else if (access == DeviceBufferAccess.Read)
            {
                return CLMemFlags.ReadOnly;
            }
            else if (access == DeviceBufferAccess.Write)
            {
                return CLMemFlags.WriteOnly;
            }
            else
            {
                throw new ArgumentException();
            }
        }
		
    }
}
