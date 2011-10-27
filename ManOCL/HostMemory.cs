using System;
using System.Collections.Generic;
using System.Text;
using ManOCL.Internal.OpenCL;
using System.Runtime.InteropServices;
using ManOCL.Internal;


namespace ManOCL
{
    public class HostMemory : DeviceBuffer<HostMemory>
    {
        public const DeviceBufferAccess DefaultAccess = DeviceBufferAccess.ReadWrite;

        public static HostMemory Create(Int32 sizeInBytes)
        {
            return CreateInternal<Array>(null, new SizeT(sizeInBytes), GetMemFlags(DefaultAccess) | CLMemFlags.AllocHostPtr, Context.Default, DefaultAccess);
        }
        public static HostMemory Create(Int32 sizeInBytes, DeviceBufferAccess access)
        {
            return CreateInternal<Array>(null, new SizeT(sizeInBytes), GetMemFlags(DefaultAccess) | CLMemFlags.AllocHostPtr, Context.Default, DefaultAccess);
        }
        public static HostMemory Create(Context context, Int32 sizeInBytes)
        {
            return CreateInternal<Array>(null, new SizeT(sizeInBytes), GetMemFlags(DefaultAccess) | CLMemFlags.AllocHostPtr, context, DefaultAccess);
        }
        public static HostMemory Create(Context context, Int32 sizeInBytes, DeviceBufferAccess access)
        {
            return CreateInternal<Array>(null, new SizeT(sizeInBytes), GetMemFlags(access) | CLMemFlags.AllocHostPtr, context, access);
        }

        public static HostMemory Create(Array data)
        {
            return Create(Context.Default, data, DefaultAccess);
        }
        public static HostMemory Create(Array data, DeviceBufferAccess access)
        {
            return Create(Context.Default, data, access);
        }
        public static HostMemory Create(Context context, Array data)
        {
            return CreateInternal(data, new SizeT(Marshal.SizeOf(data.GetType().GetElementType()) * data.Length), GetMemFlags(DefaultAccess) | CLMemFlags.AllocHostPtr | CLMemFlags.CopyHostPtr, context, DefaultAccess);
        }
        public static HostMemory Create(Context context, Array data, DeviceBufferAccess access)
        {
            return CreateInternal(data, new SizeT(Marshal.SizeOf(data.GetType().GetElementType()) * data.Length), GetMemFlags(access) | CLMemFlags.AllocHostPtr | CLMemFlags.CopyHostPtr, context, access);
        }

        public static HostMemory Create<T>(T data) where T : struct
        {
            return Create<T>(Context.Default, data, DefaultAccess);
        }
        public static HostMemory Create<T>(T data, DeviceBufferAccess access) where T : struct
        {
            return Create<T>(Context.Default, data, access);
        }
        public static HostMemory Create<T>(Context context, T data) where T : struct
        {
            return CreateInternal(data, new SizeT(Marshal.SizeOf(data.GetType())), GetMemFlags(DefaultAccess) | CLMemFlags.AllocHostPtr | CLMemFlags.CopyHostPtr, context, DefaultAccess);
        }
        public static HostMemory Create<T>(Context context, T data, DeviceBufferAccess access) where T : struct
        {
            return CreateInternal(data, new SizeT(Marshal.SizeOf(data.GetType())), GetMemFlags(access) | CLMemFlags.AllocHostPtr | CLMemFlags.CopyHostPtr, context, access);
        }

        public static implicit operator HostMemory(Array array)
        {
            return HostMemory.Create(array);
        }
    }
}
