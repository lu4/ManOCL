using System;
using System.Collections.Generic;
using System.Text;
using ManOCL.Internal.OpenCL;
using System.Runtime.InteropServices;
using ManOCL.Internal;


namespace ManOCL
{
    public class DeviceConstantMemory : DeviceBuffer<DeviceConstantMemory>
    {
        public static DeviceConstantMemory CreateWithSize(Int32 sizeInBytes)
        {
            return CreateInternal<Array>(null, new SizeT(sizeInBytes), CLMemFlags.ReadOnly, Context.Default, DeviceBufferAccess.Read);
        }
        public static DeviceConstantMemory CreateWithSize(Context context, Int32 sizeInBytes)
        {
            return CreateInternal<Array>(null, new SizeT(sizeInBytes), CLMemFlags.ReadOnly, context, DeviceBufferAccess.Read);
        }

        public static DeviceConstantMemory CreateWithArray(Array data)
        {
            return CreateWithArray(Context.Default, data);
        }
        public static DeviceConstantMemory CreateWithArray(Context context, Array data)
        {
            return CreateInternal(data, new SizeT(Marshal.SizeOf(data.GetType().GetElementType()) * data.Length), CLMemFlags.ReadOnly | CLMemFlags.CopyHostPtr, context, DeviceBufferAccess.Read);
        }

        public static DeviceConstantMemory CreateWithArray<T>(T data) where T : struct
        {
            return CreateWithArray<T>(Context.Default, data);
        }
        public static DeviceConstantMemory CreateWithArray<T>(Context context, T data) where T : struct
        {
            return CreateInternal(data, new SizeT(Marshal.SizeOf(data.GetType())), CLMemFlags.ReadOnly | CLMemFlags.CopyHostPtr, context, DeviceBufferAccess.Read);
        }
    }
}
