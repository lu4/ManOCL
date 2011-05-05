using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ManOCL
{
    using Native;
    using ManOCL.IO;

    public class DeviceGlobalMemory : DeviceBuffer<DeviceGlobalMemory>
    {
        public const DeviceBufferAccess DefaultAccess = DeviceBufferAccess.ReadWrite;

        public static DeviceGlobalMemory CreateFromSize(Int32 sizeInBytes)
        {
            return CreateInternal<Array>(null, new IntPtr(sizeInBytes), GetMemFlags(DefaultAccess), Context.Default, DefaultAccess);
        }
        public static DeviceGlobalMemory CreateFromSize(Int32 sizeInBytes, Context context)
        {
            return CreateInternal<Array>(null, new IntPtr(sizeInBytes), GetMemFlags(DefaultAccess), context, DefaultAccess);
        }
        public static DeviceGlobalMemory CreateFromSize(Int32 sizeInBytes, DeviceBufferAccess access)
        {
            return CreateInternal<Array>(null, new IntPtr(sizeInBytes), GetMemFlags(access), Context.Default, access);
        }
        public static DeviceGlobalMemory CreateFromSize(Int32 sizeInBytes, DeviceBufferAccess access, Context context)
        {
            return CreateInternal<Array>(null, new IntPtr(sizeInBytes), GetMemFlags(access), context, access);
        }

        public static DeviceGlobalMemory CreateFromSize(Int64 sizeInBytes)
        {
            return CreateInternal<Array>(null, new IntPtr(sizeInBytes), GetMemFlags(DefaultAccess), Context.Default, DefaultAccess);
        }
        public static DeviceGlobalMemory CreateFromSize(Int64 sizeInBytes, Context context)
        {
            return CreateInternal<Array>(null, new IntPtr(sizeInBytes), GetMemFlags(DefaultAccess), context, DefaultAccess);
        }
        public static DeviceGlobalMemory CreateFromSize(Int64 sizeInBytes, DeviceBufferAccess access)
        {
            return CreateInternal<Array>(null, new IntPtr(sizeInBytes), GetMemFlags(access), Context.Default, access);
        }
        public static DeviceGlobalMemory CreateFromSize(Int64 sizeInBytes, DeviceBufferAccess access, Context context)
        {
            return CreateInternal<Array>(null, new IntPtr(sizeInBytes), GetMemFlags(access), context, access);
        }

        public static DeviceGlobalMemory CreateFromArray(Array data)
        {
            return CreateFromArray(data, DefaultAccess, Context.Default);
        }
        public static DeviceGlobalMemory CreateFromArray(Array data, Context context)
        {
            return CreateInternal(data, new IntPtr(Marshal.SizeOf(data.GetType().GetElementType()) * data.Length), GetMemFlags(DefaultAccess) | MemFlags.CopyHostPtr, context, DefaultAccess);
        }
        public static DeviceGlobalMemory CreateFromArray(Array data, DeviceBufferAccess access)
        {
            return CreateFromArray(data, access, Context.Default);
        }
        public static DeviceGlobalMemory CreateFromArray(Array data, DeviceBufferAccess access, Context context)
        {
            return CreateInternal(data, new IntPtr(Marshal.SizeOf(data.GetType().GetElementType()) * data.Length), GetMemFlags(access) | MemFlags.CopyHostPtr, context, access);
        }

        public static DeviceGlobalMemory CreateFromStructure<T>(T data) where T : struct
        {
            return CreateFromStructure<T>(data, DefaultAccess, Context.Default);
        }
        public static DeviceGlobalMemory CreateFromStructure<T>(T data, DeviceBufferAccess access) where T : struct
        {
            return CreateFromStructure<T>(data, access, Context.Default);
        }
        public static DeviceGlobalMemory CreateFromStructure<T>(T data, Context context) where T : struct
        {
            return CreateInternal(data, new IntPtr(Marshal.SizeOf(data.GetType())), GetMemFlags(DefaultAccess) | MemFlags.CopyHostPtr, context, DefaultAccess);
        }
        public static DeviceGlobalMemory CreateFromStructure<T>(T data, DeviceBufferAccess access, Context context) where T : struct
        {
            return CreateInternal(data, new IntPtr(Marshal.SizeOf(data.GetType())), GetMemFlags(access) | MemFlags.CopyHostPtr, context, access);
        }

        public static implicit operator DeviceGlobalMemory(Array array)
        {
            return DeviceGlobalMemory.CreateFromArray(array);
        }
    }
}