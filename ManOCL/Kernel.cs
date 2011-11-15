using System;
using ManOCL.Internal.OpenCL;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using ManOCL.Internal;


namespace ManOCL
{
    public partial class Kernel
    {
        /* Private members */
        private bool disposed;

        /* Internal members */
        internal CLKernel CLKernel { get; private set; }

        internal Kernel(CLKernel openclKernel, Program program, CommandQueue commandQueue, Int32 kernelInfoBufferSize)
            : this(openclKernel, program, commandQueue, GetKernelInfoString(openclKernel, CLKernelInfo.FunctionName, kernelInfoBufferSize))

        {
        }
        internal Kernel(CLKernel openclKernel, Program program, CommandQueue commandQueue, String name)
        {
            this.CLKernel = openclKernel;

            this.Program = program;
            this.Context = program.Context;
            this.CommandQueue = commandQueue;

            this.Name = name;
        }

        internal void InitializeArguments(Argument[] arguments)
        {
            Int32 numArgs = GetKernelInfo<Int32>(CLKernel, CLKernelInfo.NumArgs);

            if (arguments == null) throw new ArgumentException(String.Format(Resources.No_arguments_specified_for_kernel, this.Name));
            if (numArgs != arguments.Length) throw new ArgumentException(String.Format(Resources.Amount_of_arguments_supplied_is_not_equal_to_actual_amount_of_arguments_for_kernel, this.Name));
			
            for (Int32 argumentIndex = 0; argumentIndex < arguments.Length; argumentIndex++)
            {
				arguments[argumentIndex].SetAsKernelArgument(CLKernel, argumentIndex);
            }

            this.Arguments = new ReadOnlyIndexer<Argument>(arguments);
        }

        internal Event ExecuteInternal(SizeT[] globalWorkSize)
        {
            return ExecuteInternal(globalWorkSize, null, Events.Empty, null);
        }
        internal Event ExecuteInternal(SizeT[] globalWorkSize, SizeT[] localWorkSize)
        {
            return ExecuteInternal(globalWorkSize, localWorkSize, Events.Empty, null);
        }
        internal Event ExecuteInternal(SizeT[] globalWorkSize, SizeT[] localWorkSize, Events eventWaitList)
        {
            return ExecuteInternal(globalWorkSize, localWorkSize, eventWaitList, null);
        }
        internal Event ExecuteInternal(SizeT[] globalWorkSize, SizeT[] localWorkSize, Events eventWaitList, SizeT[] globalWorkOffset)
        {
            if (localWorkSize == null || globalWorkSize.Length == localWorkSize.Length)
            {
                CLEvent e = new CLEvent();

                OpenCLError.Validate(OpenCLDriver.clEnqueueNDRangeKernel(CommandQueue.CLCommandQueue, CLKernel, globalWorkSize.Length, globalWorkOffset, globalWorkSize, localWorkSize, eventWaitList.Count, eventWaitList.OpenCLEventArray, ref e));

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
        public Event Execute(Int32[] globalWorkSize, Int32[] localWorkSize, Int32[] globalWorkOffset, Events eventWaitList)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, Convert(globalWorkOffset));
        }
        public Event Execute(Int32[] globalWorkSize, Int32[] localWorkSize, Events eventWaitList)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, null);
        }
        public Event Execute(Int32[] globalWorkSize, Int32[] localWorkSize, Events eventWaitList, Int32[] globalWorkOffset)
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
        public Event Execute(UInt32[] globalWorkSize, UInt32[] localWorkSize, UInt32[] globalWorkOffset, Events eventWaitList)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, Convert(globalWorkOffset));
        }
        public Event Execute(UInt32[] globalWorkSize, UInt32[] localWorkSize, Events eventWaitList)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, null);
        }
        public Event Execute(UInt32[] globalWorkSize, UInt32[] localWorkSize, Events eventWaitList, UInt32[] globalWorkOffset)
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
        public Event Execute(Int64[] globalWorkSize, Int64[] localWorkSize, Int64[] globalWorkOffset, Events eventWaitList)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, Convert(globalWorkOffset));
        }
        public Event Execute(Int64[] globalWorkSize, Int64[] localWorkSize, Events eventWaitList)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, null);
        }
        public Event Execute(Int64[] globalWorkSize, Int64[] localWorkSize, Events eventWaitList, Int64[] globalWorkOffset)
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
        public Event Execute(UInt64[] globalWorkSize, UInt64[] localWorkSize, UInt64[] globalWorkOffset, Events eventWaitList)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, Convert(globalWorkOffset));
        }
        public Event Execute(UInt64[] globalWorkSize, UInt64[] localWorkSize, Events eventWaitList)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, null);
        }
        public Event Execute(UInt64[] globalWorkSize, UInt64[] localWorkSize, Events eventWaitList, UInt64[] globalWorkOffset)
        {
            return ExecuteInternal(Convert(globalWorkSize), Convert(localWorkSize), eventWaitList, Convert(globalWorkOffset));
        }

        public String Name { get; private set; }
        public Context Context { get; private set; }
        public Program Program { get; private set; }
        public CommandQueue CommandQueue { get; private set; }
        public ReadOnlyIndexer<Argument> Arguments { get; private set; }

        /* Static members */
        private static SizeT[] Convert<T>(T[] data)
        {
            if (data == null)
            {
                return null;
            }
            else
            {
                Int32 structureSize = Marshal.SizeOf(typeof(T));

                SizeT[] result = new SizeT[data.Length];

                GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
				
				try
				{				
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
	
	                        result[i] = new SizeT(BitConverter.ToInt32(bytes, 0));
	                    }
	                }
	                else
	                {
	                    for (int i = 0; i < result.Length; i++)
	                    {
	                        result[i] = new SizeT(Marshal.ReadIntPtr(handlePtr, structureSize * i).ToInt64());
	                    }
	                }

					return result;
				}
				finally
				{
					handle.Free();
				}
            }
        }

        private static T GetKernelInfo<T>(CLKernel openclKernel, CLKernelInfo kernelInfo)
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

        private static String GetKernelInfoString(CLKernel openclKernel, CLKernelInfo kernelInfo, Int32 kernelInfoBufferSize)
        {
            byte[] buffer = GetKernelInfoBuffer(openclKernel, kernelInfo, kernelInfoBufferSize);

            Int32 count = Array.IndexOf<Byte>(buffer, 0, 0);

            return System.Text.ASCIIEncoding.ASCII.GetString(buffer, 0, count < 0 ? buffer.Length : count);
        }
        private static Byte[] GetKernelInfoBuffer(CLKernel openclKernel, CLKernelInfo kernelInfo, Int32 kernelInfoBufferSize)
        {
            SizeT bufferSize = SizeT.Zero;

            Byte[] buffer = new Byte[kernelInfoBufferSize];

            GCHandle bufferHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);

            IntPtr bufferPtr = bufferHandle.AddrOfPinnedObject();

            try
            {
                OpenCLError.Validate(OpenCLDriver.clGetKernelInfo(openclKernel, kernelInfo, new SizeT(buffer.Length), bufferPtr, ref bufferSize));
            }
            finally
            {
                bufferHandle.Free();
            }

            Array.Resize(ref buffer, (int)bufferSize);

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
            return Create(name, CommandQueue.Default, Program.Create(sources, Context.Default, Context.Default.Devices, Program.DefaultBuildOptions), arguments);
        }
        public static Kernel Create(String name, String[] sources, String programBuildOptions, params Argument[] arguments)
        {
            return Create(name, CommandQueue.Default, Program.Create(sources, Context.Default, Context.Default.Devices, programBuildOptions), arguments);
        }
        
        public static Kernel Create(String name, CommandQueue commandQueue, Program sources, params Argument[] arguments)
        {
            CLError error = CLError.None;

            CLKernel openclKernel = OpenCLDriver.clCreateKernel(sources.CLProgram, name, ref error);

            Kernel result = new Kernel(openclKernel, sources, commandQueue, name.Length + 1);

            result.InitializeArguments(arguments);

            return result;
        }

        /* Destructor */
        ~Kernel()
        {
            if (!disposed)
            {
                OpenCLError.Validate(OpenCLDriver.clReleaseKernel(CLKernel));

                disposed = false;
            }
        }

        /* Operators & miscellaneous members */
        public override Int32 GetHashCode()
        {
            return CLKernel.GetHashCode();
        }
        public override Boolean Equals(object obj)
        {
            return obj is Kernel && Object.Equals(((Kernel)(obj)).CLKernel, CLKernel);
        }

        public static Boolean operator ==(Kernel kernelA, Kernel kernelB)
        {
            if (Object.Equals(kernelA, null) || Object.Equals(kernelB, null))
            {
                return Object.Equals(kernelA, kernelB);
            }
            else
            {
                return Object.Equals(kernelA.CLKernel, kernelB.CLKernel);
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
                return !Object.Equals(kernelA.CLKernel, kernelB.CLKernel);
            }
        }
    }
}