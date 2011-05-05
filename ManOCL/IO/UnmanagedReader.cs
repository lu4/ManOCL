using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace ManOCL.IO
{
    public class UnmanagedReader
    {
        public const Int32 DefaultBufferSize = 65536;

        private void ReadBytes(Array array, Int32 arrayOffset, Int32 arraySize, Int32 countOffset)
        {
            if (arraySize < arrayOffset + countOffset) throw new ArgumentException(Resources.Array_out_of_bounds);
            if (Stream.Length < Stream.Position + countOffset) throw new ArgumentException(Resources.Stream_out_of_bounds);

            GCHandle arrayHandle = GCHandle.Alloc(array, GCHandleType.Pinned);

            unsafe
            {
                IntPtr arrayPtr = new IntPtr((Byte*)(arrayHandle.AddrOfPinnedObject().ToPointer()) + arrayOffset);

                try
                {
                    while (countOffset > 0)
                    {
                        Int32 bytesRead = Stream.Read(buffer, 0, Math.Min(buffer.Length, countOffset));

                        Marshal.Copy(buffer, 0, arrayPtr, bytesRead);

                        arrayPtr = new IntPtr(((Byte*)(arrayPtr.ToPointer())) + bytesRead);

                        countOffset -= bytesRead;
                    }
                }
                finally
                {
                    arrayHandle.Free();
                }
            }
        }
        private Byte[] buffer;
        
        public UnmanagedReader(Stream stream)
            : this(stream, new Byte[DefaultBufferSize])
        {
        }

        public UnmanagedReader(Stream stream, Int32 bufferSize)
            : this(stream, new Byte[bufferSize])
        {
        }

        public UnmanagedReader(Stream stream, Byte[] buffer)
        {
            this.Stream = stream;
            this.buffer = buffer;
        }

        public Stream Stream { get; private set; }

        public void Read(Array array)
        {
            Int32 arraySize = array.Length * Marshal.SizeOf(array.GetType().GetElementType());

            ReadBytes(array, 0, arraySize, arraySize);
        }
        public void Read(Array array, Int32 arrayOffset)
        {
            Int32 elementSize = Marshal.SizeOf(array.GetType().GetElementType());
            Int32 arraySize = array.Length * elementSize;

            ReadBytes(array, arrayOffset * elementSize, arraySize, arraySize);
        }
        public void Read(Array array, Int32 arrayOffset, Int32 countOffset)
        {
            Int32 elementSize = Marshal.SizeOf(array.GetType().GetElementType());

            ReadBytes(array, arrayOffset * elementSize, array.Length * elementSize, countOffset);
        }

        public T Read<T>() where T : struct
        {
            Int32 size = Marshal.SizeOf(typeof(T));

            if (Stream.Position + size > Stream.Length) throw new InvalidOperationException(Resources.Stream_out_of_bounds);

            Byte[] buffer = new Byte[size];

            Int32 bytesRead = 0;

            while (bytesRead < size) bytesRead += Stream.Read(buffer, bytesRead, size - bytesRead);

            GCHandle bufferHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);

            try
            {
                return (T)Marshal.PtrToStructure(bufferHandle.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                bufferHandle.Free();
            }
        }

        public void Close()
        {
            Stream.Close();
        }
    }
}