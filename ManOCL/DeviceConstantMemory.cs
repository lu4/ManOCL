using System;
using System.Collections.Generic;
using System.Text;
using ManOCL.Native;
using System.Runtime.InteropServices;

namespace ManOCL
{
    public class DeviceConstantMemory : DeviceBuffer<DeviceConstantMemory>
    {
        public static DeviceConstantMemory CreateWithSize(Int32 sizeInBytes)
        {
            return CreateInternal<Array>(null, new IntPtr(sizeInBytes), MemFlags.ReadOnly, Context.Default, DeviceBufferAccess.Read);
        }
        public static DeviceConstantMemory CreateWithSize(Context context, Int32 sizeInBytes)
        {
            return CreateInternal<Array>(null, new IntPtr(sizeInBytes), MemFlags.ReadOnly, context, DeviceBufferAccess.Read);
        }

        public static DeviceConstantMemory CreateWithArray(Array data)
        {
            return CreateWithArray(Context.Default, data);
        }
        public static DeviceConstantMemory CreateWithArray(Context context, Array data)
        {
            return CreateInternal(data, new IntPtr(Marshal.SizeOf(data.GetType().GetElementType()) * data.Length), MemFlags.ReadOnly | MemFlags.CopyHostPtr, context, DeviceBufferAccess.Read);
        }

        public static DeviceConstantMemory CreateWithArray<T>(T data) where T : struct
        {
            return CreateWithArray<T>(Context.Default, data);
        }
        public static DeviceConstantMemory CreateWithArray<T>(Context context, T data) where T : struct
        {
            return CreateInternal(data, new IntPtr(Marshal.SizeOf(data.GetType())), MemFlags.ReadOnly | MemFlags.CopyHostPtr, context, DeviceBufferAccess.Read);
        }
    }
}
