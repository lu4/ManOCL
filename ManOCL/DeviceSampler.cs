using System;

using ManOCL.Internal.OpenCL;
using ManOCL.Internal;


namespace ManOCL
{
	public class DeviceSampler : Argument
	{
		CLSampler openCLSampler;
		
		public const Boolean DefaultNormalizedCoords = false;
		public const FilterMode DefaultFilterMode = FilterMode.Nearest;
		public const AddressingMode DefaultAddressingMode = AddressingMode.ClampToEdge;
		
		public static DeviceSampler Create(Boolean normalizedCoords, AddressingMode addressingMode, FilterMode filterMode, Context context)
		{
			CLError error = new CLError();
			
			CLSampler sampler = OpenCLDriver.clCreateSampler(context.CLContext, normalizedCoords ? CLBool.True : CLBool.False, (CLAddressingMode)addressingMode, (CLFilterMode)filterMode, ref error);
			
			OpenCLError.Validate(error);
			
			return new DeviceSampler()
			{
				openCLSampler = sampler
			};
		}
		
		public static DeviceSampler Create(Boolean normalizedCoords, AddressingMode addressingMode, FilterMode filterMode)
		{
			return Create(normalizedCoords, addressingMode, filterMode, Context.Default);
		}
		
		public static DeviceSampler Create(Boolean normalizedCoords, AddressingMode addressingMode)
		{
			return Create(normalizedCoords, addressingMode, DefaultFilterMode, Context.Default);
		}
		
		public static DeviceSampler Create(Boolean normalizedCoords, FilterMode filterMode)
		{
			return Create(normalizedCoords, DefaultAddressingMode, filterMode, Context.Default);
		}
		
		public static DeviceSampler Create(AddressingMode addressingMode, FilterMode filterMode)
		{
			return Create(false, addressingMode, filterMode, Context.Default);
		}
		
		public static DeviceSampler Create(Boolean normalizedCoords)
		{
			return Create(normalizedCoords, DefaultAddressingMode, DefaultFilterMode, Context.Default);
		}
		
		public static DeviceSampler Create(FilterMode filterMode)
		{
			return Create(DefaultNormalizedCoords, DefaultAddressingMode, filterMode, Context.Default);
		}
		
		public static DeviceSampler Create(AddressingMode addressingMode)
		{
			return Create(DefaultNormalizedCoords, addressingMode, DefaultFilterMode, Context.Default);
		}
						
		public static DeviceSampler Create(Boolean normalizedCoords, AddressingMode addressingMode, Context context)
		{
			return Create(normalizedCoords, addressingMode, DefaultFilterMode, context);
		}
		
		public static DeviceSampler Create(Boolean normalizedCoords, FilterMode filterMode, Context context)
		{
			return Create(normalizedCoords, DefaultAddressingMode, filterMode);
		}
		
		public static DeviceSampler Create(AddressingMode addressingMode, FilterMode filterMode, Context context)
		{
			return Create(false, addressingMode, filterMode, context);
		}
		
		public static DeviceSampler Create(Boolean normalizedCoords, Context context)
		{
			return Create(normalizedCoords, DefaultAddressingMode, DefaultFilterMode, context);
		}
		
		public static DeviceSampler Create(FilterMode filterMode, Context context)
		{
			return Create(DefaultNormalizedCoords, DefaultAddressingMode, filterMode, context);
		}
		
		public static DeviceSampler Create(AddressingMode addressingMode, Context context)
		{
			return Create(DefaultNormalizedCoords, addressingMode, DefaultFilterMode, context);
		}
		
		public static DeviceSampler Create(Context context)
		{
			return Create(DefaultNormalizedCoords, DefaultAddressingMode, DefaultFilterMode, context);
		}
		
		public static DeviceSampler Create()
		{
			return Create(DefaultNormalizedCoords, DefaultAddressingMode, DefaultFilterMode, Context.Default);
		}
		
		internal override void SetAsKernelArgument(CLKernel kernel, int index)
		{
            var clMem = new CLMem
            {
                Value = openCLSampler.Value
            };

            OpenCLError.Validate(OpenCLDriver.clSetKernelArg(kernel, index, new SizeT(IntPtr.Size), ref clMem));
		}
	
	}
}

