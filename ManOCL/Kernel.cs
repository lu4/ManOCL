using System;
using ManOCL.Native;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace ManOCL
{
    public partial class Kernel
    {
        /* Constants */
        public const Int32 DefaultInfoBufferSize = 256;

        /* Private members */
        private bool disposed;

        /* Internal members */
        internal OpenCLKernel OpenCLKernel { get; private set; }

        internal Kernel(OpenCLKernel openclKernel, Program program, CommandQueue commandQueue, Int32 kernelInfoBufferSize)
            : this(openclKernel, program, commandQueue, GetKernelInfoString(openclKernel, KernelInfo.FunctionName, kernelInfoBufferSize))

        {
        }
        internal Kernel(OpenCLKernel openclKernel, Program program, CommandQueue commandQueue, String name)
        {
            this.OpenCLKernel = openclKernel;

            this.Program = program;
            this.Context = program.Context;
            this.CommandQueue = commandQueue;

            this.Name = name;
        }

        internal void InitializeArguments(Argument[] arguments)
        {
            Int32 numArgs = GetKernelInfo<Int32>(OpenCLKernel, KernelInfo.NumArgs);

            if (arguments == null) throw new ArgumentException(String.Format(Resources.No_arguments_specified_for_kernel, this.Name));
            if (numArgs != arguments.Length) throw new ArgumentException(String.Format(Resources.Amount_of_arguments_supplied_is_not_equal_to_actual_amount_of_arguments_for_kernel, this.Name));

            for (Int32 i = 0; i < arguments.Length; i++)
            {
                Argument argument = arguments[i];

                IntPtr argumentIntPtr = argument.IntPtr;


                GCHandle argumentIntPtrHandle = GCHandle.Alloc(argumentIntPtr, GCHandleType.Pinned);

                try
                {
                    OpenCLError.Validate(OpenCLDriver.clSetKernelArg(OpenCLKernel, i, argument.IntPtrSize, argumentIntPtrHandle.AddrOfPinnedObject()));
                }
                finally
                {
                    argumentIntPtrHandle.Free();
                }
            }

            this.Arguments = new ReadOnlyIndexer<Argument>(arguments);
        }

        internal Event ExecuteInternal(IntPtr[] globalWorkSize)
        {
            return ExecuteInternal(globalWorkSize, null, null, null);
        }
        internal Event ExecuteInternal(IntPtr[] globalWorkSize, IntPtr[] localWorkSize)
        {
            return ExecuteInternal(globalWorkSize, localWorkSize, null, null);
        }
        internal Event ExecuteInternal(IntPtr[] globalWorkSize, IntPtr[] localWorkSize, Event[] eventWaitList)
        {
            return ExecuteInternal(globalWorkSize, localWorkSize, eventWaitList, null);
        }
        internal Event ExecuteInternal(IntPtr[] globalWorkSize, IntPtr[] localWorkSize, Event[] eventWaitList, IntPtr[] globalWorkOffset)
        {
            if (localWorkSize == null || globalWorkSize.Length == localWorkSize.Length)
            {
                Int32 openclEventWaitListLength;
                OpenCLEvent[] openclEventWaitList;

                if (eventWaitList == null)
                {
                    openclEventWaitList = null;
                    openclEventWaitListLength = 0;
                }
                else
                {
                    openclEventWaitList = new OpenCLEvent[eventWaitList.Length];
                    openclEventWaitListLength = eventWaitList.Length;
                }

                OpenCLEvent e;

                OpenCLError.Validate(OpenCLDriver.clEnqueueNDRangeKernel(CommandQueue.OpenCLCommandQueue, OpenCLKernel, globalWorkSize.Length, globalWorkOffset, globalWorkSize, localWorkSize, openclEventWaitListLength, openclEventWaitList, out e));

                return new Event(e);
            }
            else
            {
                throw new ArgumentException(Resources.LocalWorkSize_and_GlobalWorkSize_dimensions_do_not_agree);
            }
        }

        /* Public members */
        public Event Execute(Int32 globalWorkSize)
        {
            return Execute(new Int32[] { globalWorkSize });
        }
        public Event Execute(Int32 globalWorkSize, Int32 localWorkSize)
        {
            return Execute(new Int32[] { globalWorkSize }, new Int32[] { localWorkSize });
        }
        public Event Execute(Int32[] globalWorkSize)
        {
            return ExecuteInternal(Convert(globalWorkSize));
        }
        public Event Execute(Int32[] globalWorkSize, Int32[] localWorkSize)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize));
        }
        public Event Execute(Int32[] globalWorkSize, Int32[] localWorkSize, Int32[] globalWorkOffset)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), null, Convert(globalWorkOffset));
        }
        public Event Execute(Int32[] globalWorkSize, Int32[] localWorkSize, Int32[] globalWorkOffset, Event[] eventWaitList)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, Convert(globalWorkOffset));
        }
        public Event Execute(Int32[] globalWorkSize, Int32[] localWorkSize, Event[] eventWaitList)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, null);
        }
        public Event Execute(Int32[] globalWorkSize, Int32[] localWorkSize, Event[] eventWaitList, Int32[] globalWorkOffset)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, Convert(globalWorkOffset));
        }

        public Event Execute(UInt32 globalWorkSize)
        {
            return Execute(new UInt32[] { globalWorkSize });
        }
        public Event Execute(UInt32 globalWorkSize, UInt32 localWorkSize)
        {
            return Execute(new UInt32[] { globalWorkSize }, new UInt32[] { localWorkSize });
        }
        public Event Execute(UInt32[] globalWorkSize)
        {
            return ExecuteInternal(Convert(globalWorkSize));
        }
        public Event Execute(UInt32[] globalWorkSize, UInt32[] localWorkSize)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize));
        }
        public Event Execute(UInt32[] globalWorkSize, UInt32[] localWorkSize, UInt32[] globalWorkOffset)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), null, Convert(globalWorkOffset));
        }
        public Event Execute(UInt32[] globalWorkSize, UInt32[] localWorkSize, UInt32[] globalWorkOffset, Event[] eventWaitList)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, Convert(globalWorkOffset));
        }
        public Event Execute(UInt32[] globalWorkSize, UInt32[] localWorkSize, Event[] eventWaitList)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, null);
        }
        public Event Execute(UInt32[] globalWorkSize, UInt32[] localWorkSize, Event[] eventWaitList, UInt32[] globalWorkOffset)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, Convert(globalWorkOffset));
        }

        public Event Execute(Int64 globalWorkSize)
        {
            return Execute(new Int64[] { globalWorkSize });
        }
        public Event Execute(Int64 globalWorkSize, Int64 localWorkSize)
        {
            return Execute(new Int64[] { globalWorkSize }, new Int64[] { localWorkSize });
        }
        public Event Execute(Int64[] globalWorkSize)
        {
            return ExecuteInternal(Convert(globalWorkSize));
        }
        public Event Execute(Int64[] globalWorkSize, Int64[] localWorkSize)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize));
        }
        public Event Execute(Int64[] globalWorkSize, Int64[] localWorkSize, Int64[] globalWorkOffset)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), null, Convert(globalWorkOffset));
        }
        public Event Execute(Int64[] globalWorkSize, Int64[] localWorkSize, Int64[] globalWorkOffset, Event[] eventWaitList)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, Convert(globalWorkOffset));
        }
        public Event Execute(Int64[] globalWorkSize, Int64[] localWorkSize, Event[] eventWaitList)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, null);
        }
        public Event Execute(Int64[] globalWorkSize, Int64[] localWorkSize, Event[] eventWaitList, Int64[] globalWorkOffset)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, Convert(globalWorkOffset));
        }

        public Event Execute(UInt64 globalWorkSize)
        {
            return Execute(new UInt64[] { globalWorkSize });
        }
        public Event Execute(UInt64 globalWorkSize, UInt64 localWorkSize)
        {
            return Execute(new UInt64[] { globalWorkSize }, new UInt64[] { localWorkSize });
        }
        public Event Execute(UInt64[] globalWorkSize)
        {
            return ExecuteInternal(Convert(globalWorkSize));
        }
        public Event Execute(UInt64[] globalWorkSize, UInt64[] localWorkSize)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize));
        }
        public Event Execute(UInt64[] globalWorkSize, UInt64[] localWorkSize, UInt64[] globalWorkOffset)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), null, Convert(globalWorkOffset));
        }
        public Event Execute(UInt64[] globalWorkSize, UInt64[] localWorkSize, UInt64[] globalWorkOffset, Event[] eventWaitList)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, Convert(globalWorkOffset));
        }
        public Event Execute(UInt64[] globalWorkSize, UInt64[] localWorkSize, Event[] eventWaitList)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, null);
        }
        public Event Execute(UInt64[] globalWorkSize, UInt64[] localWorkSize, Event[] eventWaitList, UInt64[] globalWorkOffset)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, Convert(globalWorkOffset));
        }

        public String Name { get; private set; }
        public Context Context { get; private set; }
        public Program Program { get; private set; }
        public CommandQueue CommandQueue { get; private set; }
        public ReadOnlyIndexer<Argument> Arguments { get; private set; }

        /* Static members */
        private static IntPtr[] Convert<T>(T[] data)
        {
            if (data == null)
            {
                return null;
            }
            else
            {
                Int32 structureSize = Marshal.SizeOf(typeof(T));

                IntPtr[] result = new IntPtr[data.Length];

                GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);

                IntPtr handlePtr = handle.AddrOfPinnedObject();

                if (structureSize < IntPtr.Size)
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        byte[] bytes = new byte[4];

                        for (int j = 0; j < structureSize; j++)
                        {
                            bytes[j] = Marshal.ReadByte(handlePtr, i * structureSize + j);
                        }

                        result[i] = new IntPtr(BitConverter.ToInt32(bytes, 0));
                    }
                }
                else
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        result[i] = Marshal.ReadIntPtr(handlePtr, structureSize * i);
                    }
                }

                return result;
            }
        }

        private static T GetKernelInfo<T>(OpenCLKernel openclKernel, KernelInfo kernelInfo)
        {
            Byte[] buffer = GetKernelInfoBuffer(openclKernel, kernelInfo, Marshal.SizeOf(typeof(T)));

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

        private static String GetKernelInfoString(OpenCLKernel openclKernel, KernelInfo kernelInfo, Int32 kernelInfoBufferSize)
        {
            byte[] buffer = GetKernelInfoBuffer(openclKernel, kernelInfo, kernelInfoBufferSize);

            Int32 count = Array.IndexOf<Byte>(buffer, 0, 0);

            return System.Text.ASCIIEncoding.ASCII.GetString(buffer, 0, count < 0 ? buffer.Length : count);
        }
        private static Byte[] GetKernelInfoBuffer(OpenCLKernel openclKernel, KernelInfo kernelInfo, Int32 kernelInfoBufferSize)
        {
            IntPtr bufferSize = IntPtr.Zero;

            Byte[] buffer = new Byte[kernelInfoBufferSize];

            GCHandle bufferHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);

            IntPtr bufferPtr = bufferHandle.AddrOfPinnedObject();

            try
            {
                OpenCLError.Validate(OpenCLDriver.clGetKernelInfo(openclKernel, kernelInfo, new IntPtr(buffer.Length), bufferPtr, out bufferSize));
            }
            finally
            {
                bufferHandle.Free();
            }

            Array.Resize(ref buffer, bufferSize.ToInt32());

            return buffer;
        }

        public static Kernel Create(String name, String source, params Argument[] arguments)
        {
            return Create(name, new String[] { source }, Program.DefaultBuildOptions, arguments);
        }
        public static Kernel Create(String name, String source, String programBuildOptions, params Argument[] arguments)
        {
            return Create(name, new String[] { source }, programBuildOptions, arguments);
        }

        public static Kernel Create(String name, String[] sources, params Argument[] arguments)
        {
            return Create(name, CommandQueue.Default, Program.Create(sources, Context.Default, Devices.Default, Program.DefaultBuildOptions), arguments);
        }
        public static Kernel Create(String name, String[] sources, String programBuildOptions, params Argument[] arguments)
        {
            return Create(name, CommandQueue.Default, Program.Create(sources, Context.Default, Devices.Default, programBuildOptions), arguments);
        }
        
        public static Kernel Create(String name, CommandQueue commandQueue, Program program, params Argument[] arguments)
        {
            Error error;

            OpenCLKernel openclKernel = OpenCLDriver.clCreateKernel(program.OpenCLProgram, name, out error);

            Kernel result = new Kernel(openclKernel, program, commandQueue, name.Length + 1);

            result.InitializeArguments(arguments);

            return result;
        }

        /* Destructor */
        ~Kernel()
        {
            if (!disposed)
            {
                OpenCLError.Validate(OpenCLDriver.clReleaseKernel(OpenCLKernel));

                disposed = false;
            }
        }

        /* Operators & miscellaneous members */
        public override Int32 GetHashCode()
        {
            return OpenCLKernel.GetHashCode();
        }
        public override Boolean Equals(object obj)
        {
            return obj is Kernel && Object.Equals(((Kernel)(obj)).OpenCLKernel, OpenCLKernel);
        }

        public static Boolean operator ==(Kernel kernelA, Kernel kernelB)
        {
            if (Object.Equals(kernelA, null) || Object.Equals(kernelB, null))
            {
                return Object.Equals(kernelA, kernelB);
            }
            else
            {
                return Object.Equals(kernelA.OpenCLKernel, kernelB.OpenCLKernel);
            }
        }
        public static Boolean operator !=(Kernel kernelA, Kernel kernelB)
        {
            if (Object.Equals(kernelA, null) || Object.Equals(kernelB, null))
            {
                return !Object.Equals(kernelA, kernelB);
            }
            else
            {
                return !Object.Equals(kernelA.OpenCLKernel, kernelB.OpenCLKernel);
            }
        }
    }
}