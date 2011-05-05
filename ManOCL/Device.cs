using System;
using ManOCL.Native;
using System.Runtime.InteropServices;

namespace ManOCL
{
	public class Device
	{
        public const Int32 DefaultInfoBufferSize = 1024;
        public const DeviceType DefaultDeviceType = DeviceType.GPU;

        internal Device(OpenCLDevice id, Int32 deviceInfoBufferSize)
	    {
	        this.OpenCLDevice = id;

            this.PlatformID = GetDeviceInfo<OpenCLPlatform>(this, DeviceInfo.Platform);

            this.AddressBits                = GetDeviceInfo<Int32>(this, DeviceInfo.AddressBits);
            this.Available                  = GetDeviceInfo<Boolean>(this, DeviceInfo.Available);
            this.CompilerAvailable          = GetDeviceInfo<Boolean>(this, DeviceInfo.CompilerAvailable);
            this.DriverVersion              = GetDeviceInfoString(this, DeviceInfo.DriverVersion, deviceInfoBufferSize);
            this.EndianLittle               = GetDeviceInfo<Boolean>(this, DeviceInfo.EndianLittle);
            this.ErrorCorrectionSupport     = GetDeviceInfo<Boolean>(this, DeviceInfo.ErrorCorrectionSupport);
            this.ExecutionCapabilities      = (DeviceExecCapabilities)GetDeviceInfo<ulong>(this, DeviceInfo.ExecutionCapabilities);
            this.Extensions                 = GetDeviceInfoString(this, DeviceInfo.Extensions, deviceInfoBufferSize);
            this.GlobalMemCacheLineSize     = GetDeviceInfo<Int32>(this, DeviceInfo.GlobalMemCacheLineSize);
            this.GlobalMemCacheSize         = GetDeviceInfo<Int64>(this, DeviceInfo.GlobalMemCacheSize);
            this.GlobalMemCacheType         = (DeviceMemCacheType)GetDeviceInfo<uint>(this, DeviceInfo.GlobalMemCacheType);
            this.GlobalMemSize              = GetDeviceInfo<Int64>(this, DeviceInfo.GlobalMemSize);
            this.Image2DMaxHeight           = GetDeviceInfo<SizeT>(this, DeviceInfo.Image2DMaxHeight);
            this.Image2DMaxWidth            = GetDeviceInfo<SizeT>(this, DeviceInfo.Image2DMaxWidth);
            this.Image3DMaxDepth            = GetDeviceInfo<SizeT>(this, DeviceInfo.Image3DMaxDepth);
            this.Image3DMaxHeight           = GetDeviceInfo<SizeT>(this, DeviceInfo.Image3DMaxHeight);
            this.Image3DMaxWidth            = GetDeviceInfo<SizeT>(this, DeviceInfo.Image3DMaxWidth);
            this.ImageSupport               = GetDeviceInfo<Boolean>(this, DeviceInfo.ImageSupport);
            this.LocalMemSize               = GetDeviceInfo<Int64>(this, DeviceInfo.LocalMemSize);
            this.LocalMemType               = (DeviceLocalMemType)GetDeviceInfo<uint>(this, DeviceInfo.LocalMemType);
            this.MaxClockFrequency          = GetDeviceInfo<Int32>(this, DeviceInfo.MaxClockFrequency);
            this.MaxComputeUnits            = GetDeviceInfo<Int32>(this, DeviceInfo.MaxComputeUnits);
            this.MaxConstantArgs            = GetDeviceInfo<Int32>(this, DeviceInfo.MaxConstantArgs);
            this.MaxConstantBufferSize      = GetDeviceInfo<Int64>(this, DeviceInfo.MaxConstantBufferSize);
            this.MaxMemAllocSize            = GetDeviceInfo<Int64>(this, DeviceInfo.MaxMemAllocSize);
            this.MaxParameterSize           = GetDeviceInfo<SizeT>(this, DeviceInfo.MaxParameterSize);
            this.MaxReadImageArgs           = GetDeviceInfo<Int32>(this, DeviceInfo.MaxReadImageArgs);
            this.MaxSamplers                = GetDeviceInfo<Int32>(this, DeviceInfo.MaxSamplers);
            this.MaxWorkGroupSize           = GetDeviceInfo<SizeT>(this, DeviceInfo.MaxWorkGroupSize);
            this.MaxWorkItemDimensions      = GetDeviceInfo<Int32>(this, DeviceInfo.MaxWorkItemDimensions);
            this.MaxWorkItemSizes           = new SizeT[this.MaxWorkItemDimensions];

            GCHandle bufferHandle = GCHandle.Alloc(this.MaxWorkItemSizes, GCHandleType.Pinned);

            try
            {
                OpenCLError.Validate(OpenCLDriver.clGetDeviceInfo(OpenCLDevice, DeviceInfo.MaxWorkItemSizes, new IntPtr(MaxWorkItemSizes.Length * IntPtr.Size), bufferHandle.AddrOfPinnedObject(), IntPtr.Zero));
            }
            finally
            {
                bufferHandle.Free();
            }

            this.MaxWriteImageArgs          = GetDeviceInfo<Int32>(this, DeviceInfo.MaxWriteImageArgs);
            this.MemBaseAddrAlign           = GetDeviceInfo<Int32>(this, DeviceInfo.MemBaseAddrAlign);
            this.MinDataTypeAlignSize       = GetDeviceInfo<Int32>(this, DeviceInfo.MinDataTypeAlignSize);
            this.Name                       = GetDeviceInfoString(this, DeviceInfo.Name, deviceInfoBufferSize);
            this.PreferredVectorWidthChar   = GetDeviceInfo<Int32>(this, DeviceInfo.PreferredVectorWidthChar);
            this.PreferredVectorWidthDouble = GetDeviceInfo<Int32>(this, DeviceInfo.PreferredVectorWidthDouble);
            this.PreferredVectorWidthFloat  = GetDeviceInfo<Int32>(this, DeviceInfo.PreferredVectorWidthFloat);
            this.PreferredVectorWidthInt    = GetDeviceInfo<Int32>(this, DeviceInfo.PreferredVectorWidthInt);
            this.PreferredVectorWidthLong   = GetDeviceInfo<Int32>(this, DeviceInfo.PreferredVectorWidthLong);
            this.PreferredVectorWidthShort  = GetDeviceInfo<Int32>(this, DeviceInfo.PreferredVectorWidthShort);
            this.Profile                    = GetDeviceInfoString(this, DeviceInfo.Profile, deviceInfoBufferSize);
            this.ProfilingTimerResolution   = GetDeviceInfo<SizeT>(this, DeviceInfo.ProfilingTimerResolution);
            this.QueueProperties            = GetDeviceInfo<Int64>(this, DeviceInfo.QueueProperties);
            this.SingleFPConfig             = (DeviceFPConfig)GetDeviceInfo<ulong>(this, DeviceInfo.SingleFPConfig);
            this.Type                       = (DeviceType)GetDeviceInfo<ulong>(this, DeviceInfo.Type);
            this.Vendor                     = GetDeviceInfoString(this, DeviceInfo.Vendor, deviceInfoBufferSize);
            this.VendorID                   = GetDeviceInfo<Int32>(this, DeviceInfo.VendorID);
            this.Version                    = GetDeviceInfoString(this, DeviceInfo.Version, deviceInfoBufferSize);
		}
        internal OpenCLDevice OpenCLDevice { get; private set; }

        private static T GetDeviceInfo<T>(Device device, DeviceInfo deviceInfo)
        {
            Byte[] buffer = GetDeviceInfoBuffer(device, deviceInfo, Marshal.SizeOf(typeof(T)));

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
        private static Byte[] GetDeviceInfoBuffer(Device device, DeviceInfo deviceInfo, Int32 infoBufferSize)
        {
            IntPtr bufferSize = IntPtr.Zero;

            Byte[] buffer = new Byte[infoBufferSize];

            GCHandle bufferHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);

            IntPtr bufferPtr = bufferHandle.AddrOfPinnedObject();

            try
            {
                OpenCLError.Validate(OpenCLDriver.clGetDeviceInfo(device.OpenCLDevice, deviceInfo, new IntPtr(buffer.Length), bufferPtr, out bufferSize));
            }
            finally
            {
                bufferHandle.Free();
            }

            Array.Resize(ref buffer, bufferSize.ToInt32());

            return buffer;
        }
        private static String GetDeviceInfoString(Device device, DeviceInfo deviceInfo, Int32 infoBufferSize)
        {
            byte[] buffer = GetDeviceInfoBuffer(device, deviceInfo, infoBufferSize);
            
            Int32 count = Array.IndexOf<byte>(buffer, 0);

            return System.Text.ASCIIEncoding.ASCII.GetString(buffer, 0, count < 0 ? buffer.Length : count);
        }

        #region Device properties
        public Int32 AddressBits { get; private set; }
        public Boolean Available { get; private set; }
        public Boolean CompilerAvailable { get; private set; }
        public String DriverVersion { get; private set; }
        public Boolean EndianLittle { get; private set; }
        public Boolean ErrorCorrectionSupport { get; private set; }
        public DeviceExecCapabilities ExecutionCapabilities { get; private set; }
        public String Extensions { get; private set; }
        public Int32 GlobalMemCacheLineSize { get; private set; }
        public Int64 GlobalMemCacheSize { get; private set; }
        public DeviceMemCacheType GlobalMemCacheType { get; private set; }
        public Int64 GlobalMemSize { get; private set; }
        public SizeT Image2DMaxHeight { get; private set; }
        public SizeT Image2DMaxWidth { get; private set; }
        public SizeT Image3DMaxDepth { get; private set; }
        public SizeT Image3DMaxHeight { get; private set; }
        public SizeT Image3DMaxWidth { get; private set; }
        public Boolean ImageSupport { get; private set; }
        public Int64 LocalMemSize { get; private set; }
        public DeviceLocalMemType LocalMemType { get; private set; }
        public Int32 MaxClockFrequency { get; private set; }
        public Int32 MaxComputeUnits { get; private set; }
        public Int32 MaxConstantArgs { get; private set; }
        public Int64 MaxConstantBufferSize { get; private set; }
        public Int64 MaxMemAllocSize { get; private set; }
        public SizeT MaxParameterSize { get; private set; }
        public Int32 MaxReadImageArgs { get; private set; }
        public Int32 MaxSamplers { get; private set; }
        public SizeT MaxWorkGroupSize { get; private set; }
        public Int32 MaxWorkItemDimensions { get; private set; }
        public SizeT[] MaxWorkItemSizes { get; private set; }
        public Int32 MaxWriteImageArgs { get; private set; }
        public Int32 MemBaseAddrAlign { get; private set; }
        public Int32 MinDataTypeAlignSize { get; private set; }
        public String Name { get; private set; }
        internal OpenCLPlatform PlatformID { get; private set; }
        public Int32 PreferredVectorWidthChar { get; private set; }
        public Int32 PreferredVectorWidthDouble { get; private set; }
        public Int32 PreferredVectorWidthFloat { get; private set; }
        public Int32 PreferredVectorWidthInt { get; private set; }
        public Int32 PreferredVectorWidthLong { get; private set; }
        public Int32 PreferredVectorWidthShort { get; private set; }
        public String Profile { get; private set; }
        public SizeT ProfilingTimerResolution { get; private set; }
        public Int64 QueueProperties { get; private set; }
        public DeviceFPConfig SingleFPConfig { get; private set; }
        public DeviceType Type { get; private set; }
        public String Vendor { get; private set; }
        public Int32 VendorID { get; private set; }
        public String Version { get; private set; }
        #endregion

        #region public static Device Default { get; } /* Singleton */
        private static Device _Default;
        public static Device Default
        {
            get
            {
                if (_Default == default(Device))
                {
                    _Default = Devices.Default[0];
                }

                return _Default;
            }
        }
        #endregion

        #region public override string ToString() { ... }
        public override string ToString()
        {
            Int32 count = MaxWorkItemSizes.Length;

            String[] maxWorkItemSizes = new String[count];

            for (int i = 0; i < count; i++)
            {
                maxWorkItemSizes[i] = MaxWorkItemSizes[i].ToString();
            }

            return String.Format
            (
@"Device ('{34}'):
	AddressBits					= '{0}'
	Available					= '{1}'
	CompilerAvailable			= '{2}'
	DriverVersion				= '{3}'
	EndianLittle				= '{4}'
	ErrorCorrectionSupport		= '{5}'
	ExecutionCapabilities		= '{6}'
	Extensions					= '{7}'
	GlobalMemCacheLineSize		= '{8}'
	GlobalMemCacheSize			= '{9}'
	GlobalMemCacheType			= '{10}'
	GlobalMemSize				= '{11}'
	Image2DMaxHeight			= '{12}'
	Image2DMaxWidth				= '{13}'
	Image3DMaxDepth				= '{14}'
	Image3DMaxHeight			= '{15}'
	Image3DMaxWidth				= '{16}'
	ImageSupport				= '{17}'
	LocalMemSize				= '{18}'
	LocalMemType				= '{19}'
	MaxClockFrequency			= '{20}'
	MaxComputeUnits				= '{21}'
	MaxConstantArgs				= '{22}'
	MaxConstantBufferSize		= '{23}'
	MaxMemAllocSize				= '{24}'
	MaxParameterSize			= '{25}'
	MaxReadImageArgs			= '{26}'
	MaxSamplers					= '{27}'
	MaxWorkGroupSize			= '{28}'
	MaxWorkItemDimensions		= '{29}'
	MaxWorkItemSizes			= '{30}'
	MaxWriteImageArgs			= '{31}'
	MemBaseAddrAlign			= '{32}'
	MinDataTypeAlignSize		= '{33}'
	Name						= '{34}'
	PreferredVectorWidthChar	= '{35}'
	PreferredVectorWidthDouble	= '{36}'
	PreferredVectorWidthFloat	= '{37}'
	PreferredVectorWidthInt		= '{38}'
	PreferredVectorWidthLong	= '{39}'
	PreferredVectorWidthShort	= '{40}'
	Profile						= '{41}'
	ProfilingTimerResolution	= '{42}'
	QueueProperties				= '{43}'
	SingleFPConfig				= '{44}'
	Type						= '{45}'
	Vendor						= '{46}'
	VendorID					= '{47}'
	Version						= '{48}'",
                AddressBits,
                Available,
                CompilerAvailable,
                DriverVersion,
                EndianLittle,
                ErrorCorrectionSupport,
                ExecutionCapabilities,
                Extensions,
                GlobalMemCacheLineSize,
                GlobalMemCacheSize,
                GlobalMemCacheType,
                GlobalMemSize,
                Image2DMaxHeight,
                Image2DMaxWidth,
                Image3DMaxDepth,
                Image3DMaxHeight,
                Image3DMaxWidth,
                ImageSupport,
                LocalMemSize,
                LocalMemType,
                MaxClockFrequency,
                MaxComputeUnits,
                MaxConstantArgs,
                MaxConstantBufferSize,
                MaxMemAllocSize,
                MaxParameterSize,
                MaxReadImageArgs,
                MaxSamplers,
                MaxWorkGroupSize,
                MaxWorkItemDimensions,
                String.Format("[{0}]", String.Join(",", maxWorkItemSizes)),
                MaxWriteImageArgs,
                MemBaseAddrAlign,
                MinDataTypeAlignSize,
                Name,
                PreferredVectorWidthChar,
                PreferredVectorWidthDouble,
                PreferredVectorWidthFloat,
                PreferredVectorWidthInt,
                PreferredVectorWidthLong,
                PreferredVectorWidthShort,
                Profile,
                ProfilingTimerResolution,
                QueueProperties,
                SingleFPConfig,
                Type,
                Vendor,
                VendorID,
                Version
             );
        }
        #endregion
    }
}