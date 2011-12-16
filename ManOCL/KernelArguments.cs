using System;
using System.Collections.Generic;

namespace ManOCL
{
	using Internal.OpenCL;
	
	public class KernelArguments : IEnumerable<Argument>
	{
		private Argument[] arguments;
		
		internal KernelArguments(Kernel kernel)
		{
			this.Kernel = kernel;
            this.arguments = new Argument[this.Count = Kernel.GetKernelInfo<Int32>(kernel.CLKernel, CLKernelInfo.NumArgs)];
		}
					
		public Int32 Count { get; private set; }

		public Kernel Kernel { get; private set; }

		public Argument this[Int32 index]
		{
			get
			{
				return arguments[index];
			}
			set
			{
				if (value != null)
				{
					(arguments[index] = value).SetAsKernelArgument(Kernel.CLKernel, index);
				}
				else
				{
					arguments[index] = null;
				}
			}
		}
		
		#region IEnumerable[Argument] implementation
		public IEnumerator<Argument> GetEnumerator ()
		{
			foreach (Argument argument in arguments)
			{
				yield return argument;
			}
		}
		#endregion

		#region IEnumerable implementation
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			foreach (Argument argument in arguments)
			{
				yield return argument;
			}
		}
		#endregion
	}
}

