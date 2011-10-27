using System;
using System.Collections.Generic;
using System.Text;
using ManOCL.Internal.OpenCL;
using System.Runtime.InteropServices;
using System.IO;
using ManOCL.Internal;


namespace ManOCL
{
    public abstract class DeviceBuffer : Argument
    {
        private Boolean disposed;

        private delegate CLError WriteOperation(CLCommandQueue command_queue, CLMem buffer, CLBool blocking_read, SizeT offset, SizeT cb, IntPtr ptr, int num_events_in_wait_list, [In] CLEvent[] event_wait_list, ref CLEvent e);

        private static Event WriteBytesInternal(CLMem openCLMem, CommandQueue commandQueue, Array array, Int64 bytesToCopy, Int64 arrayOffset, Int64 arraySize, Int64 bufferOffset, Int64 bufferSize, Events eventWaitList, WriteOperation writeDelegate)
        {
            if (bufferSize < bufferOffset + bytesToCopy) throw new ArgumentException(Resources.Buffer_out_of_bounds);
            if (arraySize < arrayOffset + bytesToCopy) throw new ArgumentException(Resources.Array_out_of_bounds);

            GCHandle valueHandle = GCHandle.Alloc(array, GCHandleType.Pinned);

            try
            {
                CLEvent e = new CLEvent();

                unsafe
                {
                    IntPtr valuePtr = new IntPtr((Byte*)(valueHandle.AddrOfPinnedObject().ToPointer()) + arrayOffset);

                    OpenCLError.Validate
                    (
                        writeDelegate
                        (
                            commandQueue.CLCommandQueue,
                            openCLMem,
                            CLBool.True,
                            new SizeT(bufferOffset),
                            new SizeT(bytesToCopy),
                            valuePtr,
                            eventWaitList == null ? 0 : eventWaitList.Count,
                            eventWaitList == null ? null : eventWaitList.OpenCLEventArray,
                            ref e
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

        private CLMem openCLMem;
        private SizeT openCLMemSize;

        internal DeviceBuffer()
        {
        }

        internal void InitializeInternal(CLMem openclMem, SizeT sizeInternal, Context context, DeviceBufferAccess access)
        {
            this.Access = access;
            this.Context = context;
            this.openCLMem = openclMem;
            this.openCLMemSize = sizeInternal;
        }
		
		internal override void SetAsKernelArgument (CLKernel kernel, int index)
		{
            OpenCLError.Validate(OpenCLDriver.clSetKernelArg(kernel, index, new SizeT(IntPtr.Size), ref openCLMem));
		}
		
        public Int64 Size
        {
            get
            {
                return (Int64)openCLMemSize;
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

            return WriteBytesInternal(openCLMem, commandQueue, array, bytesToCopy, arrayOffset, arraySize, bufferOffset, (long)openCLMemSize, null, OpenCLDriver.clEnqueueReadBuffer);
        }
        public Event Read(Array array, Int64 arrayOffset, Int64 bufferOffset, Int64 bytesToCopy, CommandQueue commandQueue, Events eventWaitList)
        {
            Int64 arraySize = array.Length * Marshal.SizeOf(array.GetType().GetElementType());

            return WriteBytesInternal(openCLMem, commandQueue, array, bytesToCopy, arrayOffset, arraySize, bufferOffset, (long)openCLMemSize, eventWaitList, OpenCLDriver.clEnqueueReadBuffer);
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

            return WriteBytesInternal(openCLMem, commandQueue, array, bytesToCopy, arrayOffset, arraySize, bufferOffset, (long)openCLMemSize, null, OpenCLDriver.clEnqueueWriteBuffer);
        }
        public Event Write(Array array, Int64 arrayOffset, Int64 bufferOffset, Int64 bytesToCopy, CommandQueue commandQueue, Events eventWaitList)
        {
            Int64 arraySize = array.Length * Marshal.SizeOf(array.GetType().GetElementType());

            return WriteBytesInternal(openCLMem, commandQueue, array, bytesToCopy, arrayOffset, arraySize, bufferOffset, (long)openCLMemSize, eventWaitList, OpenCLDriver.clEnqueueWriteBuffer);
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
                OpenCLError.Validate(OpenCLDriver.clReleaseMemObject(openCLMem));

                disposed = true;
            }
        }
    }

    public class DeviceBuffer<BufferType> : DeviceBuffer
        where BufferType : DeviceBuffer, new()
    {
        internal static BufferType CreateInternal<T>(T data, SizeT dataSize, CLMemFlags memFlags, Context context, DeviceBufferAccess access)
        {
            CLError error = CLError.None;

            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);

            try
            {
                CLMem mem = OpenCLDriver.clCreateBuffer(context.CLContext, memFlags, dataSize, handle.AddrOfPinnedObject(), ref error);
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
