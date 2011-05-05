using System;
using System.Collections.Generic;
using System.Text;
using ManOCL.Native;
using System.Runtime.InteropServices;

namespace ManOCL
{
    public class HostMemory : DeviceBuffer<HostMemory>
    {
        public const DeviceBufferAccess DefaultAccess = DeviceBufferAccess.ReadWrite;

        public static HostMemory Create(Int32 sizeInBytes)
        {
            return CreateInternal<Array>(null, new IntPtr(sizeInBytes), GetMemFlags(DefaultAccess) | MemFlags.AllocHostPtr, Context.Default, DefaultAccess);
        }
        public static HostMemory Create(Int32 sizeInBytes, DeviceBufferAccess access)
        {
            return CreateInternal<Array>(null, new IntPtr(sizeInBytes), GetMemFlags(DefaultAccess) | MemFlags.AllocHostPtr, Context.Default, DefaultAccess);
        }
        public static HostMemory Create(Context context, Int32 sizeInBytes)
        {
            return CreateInternal<Array>(null, new IntPtr(sizeInBytes), GetMemFlags(DefaultAccess) | MemFlags.AllocHostPtr, context, DefaultAccess);
        }
        public static HostMemory Create(Context context, Int32 sizeInBytes, DeviceBufferAccess access)
        {
            return CreateInternal<Array>(null, new IntPtr(sizeInBytes), GetMemFlags(access) | MemFlags.AllocHostPtr, context, access);
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
            return CreateInternal(data, new IntPtr(Marshal.SizeOf(data.GetType().GetElementType()) * data.Length), GetMemFlags(DefaultAccess) | MemFlags.AllocHostPtr | MemFlags.CopyHostPtr, context, DefaultAccess);
        }
        public static HostMemory Create(Context context, Array data, DeviceBufferAccess access)
        {
            return CreateInternal(data, new IntPtr(Marshal.SizeOf(data.GetType().GetElementType()) * data.Length), GetMemFlags(access) | MemFlags.AllocHostPtr | MemFlags.CopyHostPtr, context, access);
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
            return CreateInternal(data, new IntPtr(Marshal.SizeOf(data.GetType())), GetMemFlags(DefaultAccess) | MemFlags.AllocHostPtr | MemFlags.CopyHostPtr, context, DefaultAccess);
        }
        public static HostMemory Create<T>(Context context, T data, DeviceBufferAccess access) where T : struct
        {
            return CreateInternal(data, new IntPtr(Marshal.SizeOf(data.GetType())), GetMemFlags(access) | MemFlags.AllocHostPtr | MemFlags.CopyHostPtr, context, access);
        }

        public static implicit operator HostMemory(Array array)
        {
            return HostMemory.Create(array);
        }
    }
}
