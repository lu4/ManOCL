using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace ManOCL.IO
{
    public class UnmanagedWriter
    {
        public const Int32 DefaultBufferSize = 65536;

        private Byte[] buffer;

        private void WriteBytesInternal(Array array, Int32 arrayOffset, Int32 arraySize, Int32 countOffset)
        {
            if (arraySize < arrayOffset + countOffset) throw new ArgumentException(Resources.Array_out_of_bounds);
            if (Stream.Position + countOffset > Stream.Length) throw new ArgumentOutOfRangeException(Resources.Stream_out_of_bounds);

            GCHandle arrayHandle = GCHandle.Alloc(array, GCHandleType.Pinned);

            unsafe
            {
                IntPtr arrayPtr = new IntPtr(((Byte*)(arrayHandle.AddrOfPinnedObject().ToPointer())) + arrayOffset);

                try
                {
                    while (countOffset > 0)
                    {
                        Int32 bytesToCopy = Math.Min(countOffset, buffer.Length);

                        Marshal.Copy(arrayPtr, buffer, 0, bytesToCopy);

                        Stream.Write(buffer, arrayOffset, bytesToCopy);

                        arrayPtr = new IntPtr(((Byte*)(arrayPtr.ToPointer())) + bytesToCopy);

                        countOffset -= bytesToCopy;
                    }
                }
                finally
                {
                    arrayHandle.Free();
                }
            }
        }

        public UnmanagedWriter(Stream stream)
            : this(stream, new Byte[DefaultBufferSize])
        {
        }
        public UnmanagedWriter(Stream stream, Int32 bufferSize)
            : this(stream, new Byte[bufferSize])
        {
        }
        public UnmanagedWriter(Stream stream, Byte[] buffer)
        {
            this.Stream = stream;
            this.buffer = buffer;
        }

        public Stream Stream { get; private set; }

        public void Write(Array array)
        {
            Int32 arraySize = array.Length * Marshal.SizeOf(array.GetType().GetElementType());

            WriteBytesInternal(array, 0, arraySize, arraySize);
        }
        public void Write(Array array, Int32 arrayOffset)
        {
            Int32 elementSize = Marshal.SizeOf(array.GetType().GetElementType());
            
            Int32 arraySize = array.Length * elementSize;

            WriteBytesInternal(array, arrayOffset * elementSize, arraySize, arraySize);
        }
        public void Write(Array array, Int32 arrayOffset, Int32 countOffset)
        {
            Int32 elementSize = Marshal.SizeOf(array.GetType().GetElementType());

            WriteBytesInternal(array, arrayOffset, array.Length * elementSize, countOffset * elementSize);
        }

        /// <summary>
        /// Writes value to underlying stream, this method is slow, write array of structs when possible
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        public void Write<T>(T value) where T : struct
        {
            Int32 size = Marshal.SizeOf(typeof(T));

            GCHandle valueHandle = GCHandle.Alloc(value, GCHandleType.Pinned);

            byte[] buffer = new byte[size];

            try
            {
                Marshal.Copy(valueHandle.AddrOfPinnedObject(), buffer, 0, size);
            }
            finally
            {
                valueHandle.Free();
            }

            Stream.Write(buffer, 0, size);
        }

        public void Close()
        {
            Stream.Close();
        }
    }
}
