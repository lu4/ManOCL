using System;
using System.Collections.Generic;
using System.Text;
using ManOCL.Native;
using System.Runtime.InteropServices;
using System.IO;

namespace ManOCL
{
    public abstract class DeviceBuffer : Argument
    {
        private Boolean disposed;

        private delegate Error WriteOperation(OpenCLCommandQueue command_queue, OpenCLMem buffer, Boolean blocking_read, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e);

        private static Event WriteBytesInternal(OpenCLMem openCLMem, CommandQueue commandQueue, Array array, Int64 bytesToCopy, Int64 arrayOffset, Int64 arraySize, Int64 bufferOffset, Int64 bufferSize, Events eventWaitList, WriteOperation writeDelegate)
        {
            if (bufferSize < bufferOffset + bytesToCopy) throw new ArgumentException(Resources.Buffer_out_of_bounds);
            if (arraySize < arrayOffset + bytesToCopy) throw new ArgumentException(Resources.Array_out_of_bounds);

            GCHandle valueHandle = GCHandle.Alloc(array, GCHandleType.Pinned);

            try
            {
                OpenCLEvent e;

                unsafe
                {
                    IntPtr valuePtr = new IntPtr((Byte*)(valueHandle.AddrOfPinnedObject().ToPointer()) + arrayOffset);

                    OpenCLError.Validate
                    (
                        writeDelegate
                        (
                            commandQueue.OpenCLCommandQueue,
                            openCLMem,
                            true,
                            new IntPtr(bufferOffset),
                            new IntPtr(bytesToCopy),
                            valuePtr,
                            eventWaitList == null ? 0 : eventWaitList.Count,
                            eventWaitList == null ? null : eventWaitList.OpenCLEventArray,
                            out e
                        )
                    );
                }

                return new Event(e);
            }
            finally
            {
                valueHandle.Free();
            }
        }

        internal OpenCLMem OpenCLMem { get; private set; }
        internal IntPtr SizeInternal { get; private set; }

        internal DeviceBuffer()
        {
        }

        internal void InitializeInternal(OpenCLMem openclMem, IntPtr sizeInternal, Context context, DeviceBufferAccess access)
        {
            this.Access = access;
            this.Context = context;
            this.OpenCLMem = openclMem;
            this.SizeInternal = sizeInternal;
        }

        internal override IntPtr IntPtr
        {
            get { return OpenCLMem.Value; }
        }
        internal override IntPtr IntPtrSize
        {
            get { return new IntPtr(IntPtr.Size); }
        }

        public Int64 Size
        {
            get
            {
                return SizeInternal.ToInt64();
            }
        }

        public Context Context { get; private set; }

        public DeviceBufferAccess Access { get; private set; }

        public Event Read(Array array, Int64 arrayOffset, Int64 bufferOffset, Int64 bytesToCopy)
        {
            return Read(array, arrayOffset, bufferOffset, bytesToCopy, CommandQueue.Default, null);
        }
        public Event Read(Array array, Int64 arrayOffset, Int64 bufferOffset, Int64 bytesToCopy, Events eventWaitList)
        {
            return Read(array, arrayOffset, bufferOffset, bytesToCopy, CommandQueue.Default, eventWaitList);
        }
        public Event Read(Array array, Int64 arrayOffset, Int64 bufferOffset, Int64 bytesToCopy, CommandQueue commandQueue)
        {
            Int64 arraySize = array.Length * Marshal.SizeOf(array.GetType().GetElementType());

            return WriteBytesInternal(OpenCLMem, commandQueue, array, bytesToCopy, arrayOffset, arraySize, bufferOffset, SizeInternal.ToInt32(), null, OpenCLDriver.clEnqueueReadBuffer);
        }
        public Event Read(Array array, Int64 arrayOffset, Int64 bufferOffset, Int64 bytesToCopy, CommandQueue commandQueue, Events eventWaitList)
        {
            Int64 arraySize = array.Length * Marshal.SizeOf(array.GetType().GetElementType());

            return WriteBytesInternal(OpenCLMem, commandQueue, array, bytesToCopy, arrayOffset, arraySize, bufferOffset, SizeInternal.ToInt32(), eventWaitList, OpenCLDriver.clEnqueueReadBuffer);
        }

        public Event Write(Array array, Int64 arrayOffset, Int64 bufferOffset, Int64 bytesToCopy)
        {
            return Write(array, arrayOffset, bufferOffset, bytesToCopy, CommandQueue.Default, null);
        }
        public Event Write(Array array, Int64 arrayOffset, Int64 bufferOffset, Int64 bytesToCopy, Events eventWaitList)
        {
            return Write(array, arrayOffset, bufferOffset, bytesToCopy, CommandQueue.Default, eventWaitList);
        }
        public Event Write(Array array, Int64 arrayOffset, Int64 bufferOffset, Int64 bytesToCopy, CommandQueue commandQueue)
        {
            Int64 arraySize = array.Length * Marshal.SizeOf(array.GetType().GetElementType());

            return WriteBytesInternal(OpenCLMem, commandQueue, array, bytesToCopy, arrayOffset, arraySize, bufferOffset, SizeInternal.ToInt32(), null, OpenCLDriver.clEnqueueWriteBuffer);
        }
        public Event Write(Array array, Int64 arrayOffset, Int64 bufferOffset, Int64 bytesToCopy, CommandQueue commandQueue, Events eventWaitList)
        {
            Int64 arraySize = array.Length * Marshal.SizeOf(array.GetType().GetElementType());

            return WriteBytesInternal(OpenCLMem, commandQueue, array, bytesToCopy, arrayOffset, arraySize, bufferOffset, SizeInternal.ToInt32(), eventWaitList, OpenCLDriver.clEnqueueWriteBuffer);
        }

        public void Read(Stream stream, Int64 bufferOffset, Int64 bytesToCopy)
        {
            Read(stream, bufferOffset, bytesToCopy, new Byte[0xFFFF], CommandQueue.Default, null);
        }
        public void Read(Stream stream, Int64 bufferOffset, Int64 bytesToCopy, Int32 bufferSize)
        {
            Read(stream, bufferOffset, bytesToCopy, new Byte[bufferSize], CommandQueue.Default, null);
        }
        public void Read(Stream stream, Int64 bufferOffset, Int64 bytesToCopy, Int32 bufferSize, Events eventWaitList)
        {
            Read(stream, bufferOffset, bytesToCopy, new Byte[bufferSize], CommandQueue.Default, eventWaitList);
        }
        public void Read(Stream stream, Int64 bufferOffset, Int64 bytesToCopy, Int32 bufferSize, CommandQueue commandQueue)
        {
            Read(stream, bufferOffset, bytesToCopy, new Byte[bufferSize], commandQueue, null);
        }
        public void Read(Stream stream, Int64 bufferOffset, Int64 bytesToCopy, Int32 bufferSize, CommandQueue commandQueue, Events eventWaitList)
        {
            Read(stream, bufferOffset, bytesToCopy, new Byte[bufferSize], commandQueue, eventWaitList);
        }

        public void Read(Stream stream, Int64 bufferOffset, Int64 bytesToCopy, Byte[] buffer)
        {
            Read(stream, bufferOffset, bytesToCopy, buffer, CommandQueue.Default, null);
        }
        public void Read(Stream stream, Int64 bufferOffset, Int64 bytesToCopy, Byte[] buffer, CommandQueue commandQueue)
        {
            Read(stream, bufferOffset, bytesToCopy, buffer, commandQueue, null);
        }
        public void Read(Stream stream, Int64 bufferOffset, Int64 bytesToCopy, Byte[] buffer, CommandQueue commandQueue, Events eventWaitList)
        {
            while (bytesToCopy > buffer.Length)
            {
                Read(buffer, 0, bufferOffset, buffer.Length, commandQueue, eventWaitList);

                stream.Write(buffer, 0, buffer.Length);

                bufferOffset += buffer.Length;
                bytesToCopy -= buffer.Length;
            }

            Read(buffer, 0, bufferOffset, bytesToCopy, commandQueue, eventWaitList);

            stream.Write(buffer, 0, (Int32)bytesToCopy);
        }

        public void Write(Stream stream, Int64 bufferOffset, Int64 bytesToCopy)
        {
            Write(stream, bufferOffset, bytesToCopy, new Byte[0xFFFF], CommandQueue.Default, null);
        }
        public void Write(Stream stream, Int64 bufferOffset, Int64 bytesToCopy, Int32 bufferSize)
        {
            Write(stream, bufferOffset, bytesToCopy, new Byte[bufferSize], CommandQueue.Default, null);
        }
        public void Write(Stream stream, Int64 bufferOffset, Int64 bytesToCopy, Int32 bufferSize, Events eventWaitList)
        {
            Write(stream, bufferOffset, bytesToCopy, new Byte[bufferSize], CommandQueue.Default, eventWaitList);
        }
        public void Write(Stream stream, Int64 bufferOffset, Int64 bytesToCopy, Int32 bufferSize, CommandQueue commandQueue)
        {
            Write(stream, bufferOffset, bytesToCopy, new Byte[bufferSize], commandQueue, null);
        }
        public void Write(Stream stream, Int64 bufferOffset, Int64 bytesToCopy, Int32 bufferSize, CommandQueue commandQueue, Events eventWaitList)
        {
            Write(stream, bufferOffset, bytesToCopy, new Byte[bufferSize], commandQueue, eventWaitList);
        }

        public void Write(Stream stream, Int64 bufferOffset, Int64 bytesToCopy, Byte[] buffer)
        {
            Write(stream, bufferOffset, bytesToCopy, buffer, CommandQueue.Default, null);
        }
        public void Write(Stream stream, Int64 bufferOffset, Int64 bytesToCopy, Byte[] buffer, CommandQueue commandQueue)
        {
            Write(stream, bufferOffset, bytesToCopy, buffer, commandQueue, null);
        }
        public void Write(Stream stream, Int64 bufferOffset, Int64 bytesToCopy, Byte[] buffer, Events eventWaitList)
        {
            Write(stream, bufferOffset, bytesToCopy, buffer, CommandQueue.Default, eventWaitList);
        }
        public void Write(Stream stream, Int64 bufferOffset, Int64 bytesToCopy, Byte[] buffer, CommandQueue commandQueue, Events eventWaitList)
        {
            while (bytesToCopy > buffer.Length)
            {
                stream.Read(buffer, 0, buffer.Length);

                Write(buffer, 0, bufferOffset, buffer.Length, commandQueue, eventWaitList);

                bufferOffset += buffer.Length;
                bytesToCopy -= buffer.Length;
            }

            stream.Read(buffer, 0, (Int32)bytesToCopy);

            Write(buffer, 0, bufferOffset, bytesToCopy, commandQueue, eventWaitList);
        }

        ~DeviceBuffer()
        {
            if (!disposed)
            {
                OpenCLError.Validate(OpenCLDriver.clReleaseMemObject(OpenCLMem));

                disposed = true;
            }
        }
    }

    public class DeviceBuffer<BufferType> : DeviceBuffer
        where BufferType : DeviceBuffer, new()
    {
        internal static MemFlags GetMemFlags(DeviceBufferAccess access)
        {
            if (access == DeviceBufferAccess.ReadWrite)
            {
                return MemFlags.ReadWrite;
            }
            else if (access == DeviceBufferAccess.Read)
            {
                return MemFlags.ReadOnly;
            }
            else if (access == DeviceBufferAccess.Write)
            {
                return MemFlags.WriteOnly;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        internal static BufferType CreateInternal<T>(T data, IntPtr dataSize, MemFlags memFlags, Context context, DeviceBufferAccess access)
        {
            Error error;

            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);

            try
            {
                OpenCLMem mem = OpenCLDriver.clCreateBuffer(context.OpenCLContext, memFlags, dataSize, handle.AddrOfPinnedObject(), out error);
                OpenCLError.Validate(error);

                BufferType result = new BufferType();
                
                result.InitializeInternal(mem, dataSize, context, access);

                return result;
            }
            finally
            {
                handle.Free();
            }
        }
    }
}
