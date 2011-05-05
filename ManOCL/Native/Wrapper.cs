using System;
using System.Collections;
using System.Collections.Generic;

namespace ManOCL.Native.Wrapper
{
	public class OpenCLException : Exception
	{
		public OpenCLException()
		{
		}

		public OpenCLException(String message) : base (message)
		{
		}
	}
	
	internal class OpenCLError : OpenCLException
	{
		internal Error ErrorCode { get; private set; }
		
		internal OpenCLError(Error errorCode)
		{
			this.ErrorCode = errorCode;
		}
		
		public override String ToString()
		{
			return String.Format("OpenCL error occured, ErrorCode = '{0}', additional info:\r\n{1}", ErrorCode, base.ToString());
		}
		
		internal static void Validate(Error error)
		{
			if (error != Error.None) throw new OpenCLError(error);
		}

		internal static void Validate(Int32 error)
		{
			if ((Error)error != Error.None) throw new OpenCLError((Error)error);
		}
	}
		
	public class Context
	{
		internal OpenCLContext ID;

        private Device[] CreateDevices()
        {
            IntPtr nContextDescriptorSize;

            OpenCLDriver.clGetContextInfo(ID, ContextInfo.Devices, IntPtr.Zero, IntPtr.Zero, out nContextDescriptorSize);

            OpenCLDevice[] deviceIDs = new OpenCLDevice[nContextDescriptorSize.ToInt32() / IntPtr.Size];

            OpenCLError.Validate(OpenCLDriver.clGetContextInfo(ID, ContextInfo.Devices, nContextDescriptorSize, deviceIDs, IntPtr.Zero));

            Device[] devices = new Device[deviceIDs.Length];

            for (int i = 0; i < devices.Length; i++)
            {
                devices[i] = new Device(this, deviceIDs[i]);
            }

            return devices;
        }

		public Context(DeviceType deviceType)
		{
            Error error;

            ID = OpenCLDriver.clCreateContextFromType(IntPtr.Zero, deviceType, null, IntPtr.Zero, out error);

			OpenCLError.Validate(error);
		}

        #region public Device[] GetDevices() { ... }
        private Device[] vvDevices;
        public Device[] GetDevices()
		{
            if (vvDevices == null)
            {
                vvDevices = CreateDevices();
            }

            return (Device[])vvDevices.Clone();
        }
        #endregion

        public Program CreateProgram(params Object[] sourceCode)
        {
            throw new NotImplementedException();
        }
    }
	
	public class Device
	{
		internal OpenCLDevice ID;
		
		public Device(Context context, OpenCLDevice id)
		{
			this.ID = id;
			this.Context = context;
		}
		
		public CommandQueue CreateCommandQueue()
		{
			return new CommandQueue(this);
		}
		
		public Context Context { get; private set; }
	}
	
	public class CommandQueue
	{
		internal OpenCLCommandQueue ID;
		
		internal CommandQueue(Device device)
			: this(device, CommandQueueProperties.None)
		{
		}

		public CommandQueue(Device device, CommandQueueProperties commandQueueProperties)
		{
			Error error;
			
            ID = OpenCLDriver.clCreateCommandQueue(device.Context.ID, device.ID, commandQueueProperties, out error);
			
			OpenCLError.Validate(error);
		}

		public void Write(Buffer buffer, Boolean block, IntPtr offset, IntPtr size, IntPtr target)
		{
	        OpenCLError.Validate(OpenCLDriver.clEnqueueWriteBuffer(ID, buffer.ID, block, offset, size, target, 0, null, new OpenCLEvent() { Value = IntPtr.Zero }));
		}
		
		public void Read(Buffer buffer, Boolean block, IntPtr offset, IntPtr size, IntPtr target)
		{
			OpenCLError.Validate(OpenCLDriver.clEnqueueReadBuffer(ID, buffer.ID, block, offset, size, target, 0, null, new OpenCLEvent() { Value = IntPtr.Zero }));
		}
		
		public void Copy(Buffer src, Buffer dst, IntPtr srcOffset, IntPtr dstOffset, IntPtr size)
		{
			OpenCLError.Validate(OpenCLDriver.clEnqueueCopyBuffer(ID, src.ID, dst.ID, srcOffset, dstOffset, size, 0, null, new OpenCLEvent() { Value = IntPtr.Zero }));
		}
		
		public void Call(Kernel kernel, IntPtr[] globalWorkSize, IntPtr[] localWorkSize)
		{
			OpenCLError.Validate(OpenCLDriver.clEnqueueNDRangeKernel(ID, kernel.ID, globalWorkSize.Length, null, globalWorkSize, localWorkSize, 0, null, new OpenCLEvent() { Value = IntPtr.Zero }));
		}
		
		public Profile Profile(Kernel kernel, IntPtr[] globalWorkSize, IntPtr[] localWorkSize)
		{
			OpenCLEvent timer;
			
			OpenCLError.Validate(OpenCLDriver.clEnqueueNDRangeKernel(ID, kernel.ID, globalWorkSize.Length, null, globalWorkSize, localWorkSize, 0, null, out timer));
			
			return new Profile(timer);
		}
		
		public void Finish()
		{
			OpenCLDriver.clFinish(ID);
		}
	}

	public class Profile
	{
		internal OpenCLEvent ID;
		
		internal Profile(OpenCLEvent id)
		{
			this.ID = id;
			
			OpenCLDriver.clWaitForEvents(1, ref id);
			
			IntPtr param_value_size_ret = IntPtr.Zero;

            Byte[] bytes = new Byte[8];

            OpenCLError.Validate(OpenCLDriver.clGetEventProfilingInfo(ID, ProfilingInfo.End, new IntPtr(sizeof(UInt64)), bytes, out param_value_size_ret));
			EndTicks = BitConverter.ToUInt64(bytes, 0);
			
			OpenCLError.Validate(OpenCLDriver.clGetEventProfilingInfo(ID, ProfilingInfo.Start, new IntPtr(sizeof(UInt64)), bytes, out param_value_size_ret));
			StartTicks = BitConverter.ToUInt64(bytes, 0);
						
			Seconds = ((double)1.0e-9*(EndTicks - StartTicks));
		}
		
		public UInt64 StartTicks { get; private set; }
		public UInt64 EndTicks { get; private set; }
		
		public Double Seconds { get; private set; }
		
		public override string ToString ()
		{
			return string.Format ("[Profiler: StartTicks='{0}', EndTicks='{1}', Seconds='{2:0.0000000000}']", StartTicks, EndTicks, Seconds);
		}
	}
	
	public class Program
	{
        private static String[] GetStrings(Object[] sources)
        {
            String[] result = new String[sources.Length];

            for (int i = 0; i < sources.Length; i++)
            {
                result[i] = sources[i].ToString();
            }

            return result;
        }

        internal OpenCLProgram ID;

        private String[] sources;

        public Program(DeviceType deviceType, params Object[] sources)
            : this(new Context(deviceType), sources)
        {
        }

        public Program(DeviceType deviceType, params String[] sources)
            : this(new Context(deviceType), sources)
        {
        }

        public Program(Context context, params Object[] sources)
            : this(context, GetStrings(sources))
        {

        }

		public Program(Context context, params String[] sources)
		{
            Error error;

            ID = OpenCLDriver.clCreateProgramWithSource(context.ID, sources.Length, sources, null, out error);
		
			OpenCLError.Validate(error);
			
            this.sources = sources;
        }

        public void Build()
        {
            OpenCLError.Validate(OpenCLDriver.clBuildProgram(ID, 0, null, null, null, IntPtr.Zero));
        }

        public Context Context { get; private set; }

        public String[] GetSources()
        {
            return (String[])sources.Clone();
        }
	}
	
	public class Kernel
	{
		#region private class ArgumentList { ... }
		private class ArgumentList : IList<Buffer>, ICollection<Buffer>, IEnumerable
		{
			private List<Buffer> data = new List<Buffer>();
			
			private Kernel Kernel { get; set; }
						
			private void SetKernelArg(Int32 index, Buffer buffer)
			{
		        OpenCLError.Validate(OpenCLDriver.clSetKernelArg(Kernel.ID, index, new IntPtr(IntPtr.Size), ref buffer.ID));
			}
			
			public ArgumentList(Kernel kernel)
			{
				this.Kernel = kernel;
			}
			
			public Int32 IndexOf(Buffer item)
			{
				return data.IndexOf(item);
			}

			public void Insert(int index, Buffer item)
			{
				data.Insert(index, item);
				
				for (int i = index; i < data.Count; i++)
				{
					SetKernelArg(i, data[i]);
				}
			}

			public void RemoveAt(int index)
			{
				throw new NotSupportedException("RemoveAt operation not supported");
			}

			public Buffer this[int index]
			{
				get
				{
					return data[index];
				}
				set
				{
					if(data[index] != value) SetKernelArg(index, data[index] = value);
				}
			}

			public void Add(Buffer item)
			{
				Int32 index = data.Count;
				
				data.Add(item);
				
				SetKernelArg(index, item);
			}

			public void Clear()
			{
				throw new NotSupportedException("Clear operation not supported");
			}

			public bool Contains(Buffer item)
			{
				return data.Contains(item);
			}

			public void CopyTo(Buffer[] array, int arrayIndex)
			{
				data.CopyTo(array, arrayIndex);
			}

			public bool Remove(Buffer item)
			{
				throw new NotSupportedException("Remove operation not supported");
			}

			public int Count
			{
				get
				{
					return data.Count;
				}
			}

			public bool IsReadOnly
			{
				get
				{
					return ((IList<Buffer>)(data)).IsReadOnly;
				}
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				foreach (Buffer buffer in data)
				{
					yield return buffer;
				}
			}
			
			public IEnumerator<Buffer> GetEnumerator()
			{
				foreach (Buffer buffer in data)
				{
					yield return buffer;
				}
			}
		}
		#endregion

		internal OpenCLKernel ID;

		public Kernel(Program program, String name)
		{
			Error error;
			
			ID = OpenCLDriver.clCreateKernel(program.ID, this.Name = name, out error);

			OpenCLError.Validate(error);

			Arguments = new ArgumentList(this);
		}

		public String Name { get; private set; }

		public IList<Buffer> Arguments { get; private set; }
	}
		
	public class Buffer
	{
		internal OpenCLMem ID;
		
		public Buffer(Context context, MemFlags memFlags, IntPtr size, IntPtr dataPtr)
		{
			Error error;
			
			this.Size = size;
			this.Context = context;

            this.ID = OpenCLDriver.clCreateBuffer(Context.ID, memFlags, size, dataPtr, out error);
			
			OpenCLError.Validate(error);
		}
				
		public IntPtr Size { get; private set; }

		public Context Context { get; private set; }
		
		~Buffer()
		{
	        OpenCLDriver.clReleaseMemObject(ID);
		}
	}
}