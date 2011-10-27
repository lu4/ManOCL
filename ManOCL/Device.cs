using System;
using System.Runtime.InteropServices;
using ManOCL.Internal;
using ManOCL.Internal.OpenCL;


namespace ManOCL
{
    public class Device
    {
        public const CLDeviceType DefaultDeviceType = CLDeviceType.GPU;

        internal Device(CLDeviceID id)
        {
            this.CLDeviceID = id;

            this.PlatformID = GetDeviceInfo<CLPlatformID>(this, CLDeviceInfo.Platform);

            this.AddressBits = GetDeviceInfo<Int32>(this, CLDeviceInfo.AddressBits);
            this.Available = GetDeviceInfo<Boolean>(this, CLDeviceInfo.Available);
            this.CompilerAvailable = GetDeviceInfo<Boolean>(this, CLDeviceInfo.CompilerAvailable);
            this.DriverVersion = GetDeviceInfoString(this, CLDeviceInfo.DriverVersion);
            this.EndianLittle = GetDeviceInfo<Boolean>(this, CLDeviceInfo.EndianLittle);
            this.ErrorCorrectionSupport = GetDeviceInfo<Boolean>(this, CLDeviceInfo.ErrorCorrectionSupport);
            this.ExecutionCapabilities = (DeviceExecCapabilities)GetDeviceInfo<ulong>(this, CLDeviceInfo.ExecutionCapabilities);

            this.Extensions = GetDeviceInfoString(this, CLDeviceInfo.Extensions);

            this.GlobalMemCacheLineSize = GetDeviceInfo<Int32>(this, CLDeviceInfo.GlobalMemCacheLineSize);
            this.GlobalMemCacheSize = GetDeviceInfo<Int64>(this, CLDeviceInfo.GlobalMemCacheSize);
            this.GlobalMemCacheType = (DeviceMemCacheType)GetDeviceInfo<uint>(this, CLDeviceInfo.GlobalMemCacheType);
            this.GlobalMemSize = GetDeviceInfo<Int64>(this, CLDeviceInfo.GlobalMemSize);
            this.Image2DMaxHeight = GetDeviceInfo<SizeT>(this, CLDeviceInfo.Image2DMaxHeight);
            this.Image2DMaxWidth = GetDeviceInfo<SizeT>(this, CLDeviceInfo.Image2DMaxWidth);
            this.Image3DMaxDepth = GetDeviceInfo<SizeT>(this, CLDeviceInfo.Image3DMaxDepth);
            this.Image3DMaxHeight = GetDeviceInfo<SizeT>(this, CLDeviceInfo.Image3DMaxHeight);
            this.Image3DMaxWidth = GetDeviceInfo<SizeT>(this, CLDeviceInfo.Image3DMaxWidth);
            this.ImageSupport = GetDeviceInfo<Boolean>(this, CLDeviceInfo.ImageSupport);
            this.LocalMemSize = GetDeviceInfo<Int64>(this, CLDeviceInfo.LocalMemSize);
            this.LocalMemType = (DeviceLocalMemType)GetDeviceInfo<uint>(this, CLDeviceInfo.LocalMemType);
            this.MaxClockFrequency = GetDeviceInfo<Int32>(this, CLDeviceInfo.MaxClockFrequency);
            this.MaxComputeUnits = GetDeviceInfo<Int32>(this, CLDeviceInfo.MaxComputeUnits);
            this.MaxConstantArgs = GetDeviceInfo<Int32>(this, CLDeviceInfo.MaxConstantArgs);
            this.MaxConstantBufferSize = GetDeviceInfo<Int64>(this, CLDeviceInfo.MaxConstantBufferSize);
            this.MaxMemAllocSize = GetDeviceInfo<Int64>(this, CLDeviceInfo.MaxMemAllocSize);
            this.MaxParameterSize = GetDeviceInfo<SizeT>(this, CLDeviceInfo.MaxParameterSize);
            this.MaxReadImageArgs = GetDeviceInfo<Int32>(this, CLDeviceInfo.MaxReadImageArgs);
            this.MaxSamplers = GetDeviceInfo<Int32>(this, CLDeviceInfo.MaxSamplers);
            this.MaxWorkGroupSize = GetDeviceInfo<SizeT>(this, CLDeviceInfo.MaxWorkGroupSize);
            this.MaxWorkItemDimensions = GetDeviceInfo<Int32>(this, CLDeviceInfo.MaxWorkItemDimensions);
            this.MaxWorkItemSizes = new SizeT[this.MaxWorkItemDimensions];

            GCHandle bufferHandle = GCHandle.Alloc(this.MaxWorkItemSizes, GCHandleType.Pinned);

            try
            {
                SizeT param_value_size_ret = SizeT.Zero;

                OpenCLError.Validate(OpenCLDriver.clGetDeviceInfo(CLDeviceID, CLDeviceInfo.MaxWorkItemSizes, new SizeT(MaxWorkItemSizes.Length * IntPtr.Size), bufferHandle.AddrOfPinnedObject(), ref param_value_size_ret));
            }
            finally
            {
                bufferHandle.Free();
            }

            this.MaxWriteImageArgs = GetDeviceInfo<Int32>(this, CLDeviceInfo.MaxWriteImageArgs);
            this.MemBaseAddrAlign = GetDeviceInfo<Int32>(this, CLDeviceInfo.MemBaseAddrAlign);
            this.MinDataTypeAlignSize = GetDeviceInfo<Int32>(this, CLDeviceInfo.MinDataTypeAlignSize);
            this.Name = GetDeviceInfoString(this, CLDeviceInfo.Name);
            this.PreferredVectorWidthChar = GetDeviceInfo<Int32>(this, CLDeviceInfo.PreferredVectorWidthChar);
            this.PreferredVectorWidthDouble = GetDeviceInfo<Int32>(this, CLDeviceInfo.PreferredVectorWidthDouble);
            this.PreferredVectorWidthFloat = GetDeviceInfo<Int32>(this, CLDeviceInfo.PreferredVectorWidthFloat);
            this.PreferredVectorWidthInt = GetDeviceInfo<Int32>(this, CLDeviceInfo.PreferredVectorWidthInt);
            this.PreferredVectorWidthLong = GetDeviceInfo<Int32>(this, CLDeviceInfo.PreferredVectorWidthLong);
            this.PreferredVectorWidthShort = GetDeviceInfo<Int32>(this, CLDeviceInfo.PreferredVectorWidthShort);
            this.Profile = GetDeviceInfoString(this, CLDeviceInfo.Profile);
            this.ProfilingTimerResolution = GetDeviceInfo<SizeT>(this, CLDeviceInfo.ProfilingTimerResolution);
            this.QueueProperties = GetDeviceInfo<Int64>(this, CLDeviceInfo.QueueProperties);
            this.SingleFPConfig = (DeviceFPConfig)GetDeviceInfo<ulong>(this, CLDeviceInfo.SingleFPConfig);
            this.CLDeviceType = (CLDeviceType)GetDeviceInfo<ulong>(this, CLDeviceInfo.Type);
            this.Vendor = GetDeviceInfoString(this, CLDeviceInfo.Vendor);
            this.VendorID = GetDeviceInfo<Int32>(this, CLDeviceInfo.VendorID);
            this.Version = GetDeviceInfoString(this, CLDeviceInfo.Version);
        }
        internal CLDeviceID CLDeviceID { get; private set; }

        private static T GetDeviceInfo<T>(Device device, CLDeviceInfo deviceInfo) where T : struct
        {
            Byte[] buffer = GetDeviceInfoBuffer(device, deviceInfo);

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
        private static Byte[] GetDeviceInfoBuffer(Device device, CLDeviceInfo deviceInfo)
        {
            SizeT bufferSize = SizeT.Zero;

            OpenCLError.Validate(OpenCLDriver.clGetDeviceInfo(device.CLDeviceID, deviceInfo, SizeT.Zero, IntPtr.Zero, ref bufferSize));

            Byte[] buffer = new Byte[(Int64)bufferSize];

            OpenCLError.Validate(OpenCLDriver.clGetDeviceInfo(device.CLDeviceID, deviceInfo, bufferSize, buffer, ref bufferSize));

            return buffer;
        }
        private static String GetDeviceInfoString(Device device, CLDeviceInfo deviceInfo)
        {
            byte[] buffer = GetDeviceInfoBuffer(device, deviceInfo);

            Int32 count = Array.IndexOf<byte>(buffer, 0);

            return System.Text.ASCIIEncoding.ASCII.GetString(buffer, 0, count < 0 ? buffer.Length : count).Trim();
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
        internal CLPlatformID PlatformID { get; private set; }
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
        public CLDeviceType CLDeviceType { get; private set; }
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
                    Device defaultDevice = null;

                    foreach (Device device in Context.Default.Devices)
                    {
                        if
                        (
                            (defaultDevice == null)
                            || (defaultDevice.CLDeviceType != CLDeviceType.GPU && device.CLDeviceType == CLDeviceType.GPU)
                            || (defaultDevice.MaxClockFrequency * defaultDevice.MaxComputeUnits < device.MaxClockFrequency * device.MaxComputeUnits)
                            || (defaultDevice.GlobalMemSize < device.GlobalMemSize)
                        )
                        {
                            defaultDevice = device;
                        }
                    }

                    if (defaultDevice == null)
                    {
                        throw new InvalidOperationException("No devices found.");
                    }

                    _Default = defaultDevice;
                }

                return _Default;
            }
            set
            {
                _Default = value;
            }
        }
        #endregion

        #region public override string ToString() { ... }

        internal String ToIdentedString(Int32 indent, Int32 indentationSize)
        {
            String identation = new String(' ', indentationSize * indent);
            String additionalIdentation = new String(' ', indentationSize);

            Int32 count = MaxWorkItemSizes.Length;

            String[] maxWorkItemSizes = new String[count];

            for (int i = 0; i < count; i++)
            {
                maxWorkItemSizes[i] = MaxWorkItemSizes[i].ToString();
            }

            return String.Format
            (
@"{49}Device '{34}'
{49}{51}
{49}{50}AddressBits                   = '{0}'
{49}{50}Available                     = '{1}'
{49}{50}CompilerAvailable             = '{2}'
{49}{50}DriverVersion                 = '{3}'
{49}{50}EndianLittle                  = '{4}'
{49}{50}ErrorCorrectionSupport        = '{5}'
{49}{50}ExecutionCapabilities         = '{6}'
{49}{50}Extensions                    = '{7}'
{49}{50}GlobalMemCacheLineSize        = '{8}'
{49}{50}GlobalMemCacheSize            = '{9}'
{49}{50}GlobalMemCacheType            = '{10}'
{49}{50}GlobalMemSize                 = '{11}'
{49}{50}Image2DMaxHeight              = '{12}'
{49}{50}Image2DMaxWidth               = '{13}'
{49}{50}Image3DMaxDepth               = '{14}'
{49}{50}Image3DMaxHeight              = '{15}'
{49}{50}Image3DMaxWidth               = '{16}'
{49}{50}ImageSupport                  = '{17}'
{49}{50}LocalMemSize                  = '{18}'
{49}{50}LocalMemType                  = '{19}'
{49}{50}MaxClockFrequency             = '{20}'
{49}{50}MaxComputeUnits               = '{21}'
{49}{50}MaxConstantArgs               = '{22}'
{49}{50}MaxConstantBufferSize         = '{23}'
{49}{50}MaxMemAllocSize               = '{24}'
{49}{50}MaxParameterSize              = '{25}'
{49}{50}MaxReadImageArgs              = '{26}'
{49}{50}MaxSamplers                   = '{27}'
{49}{50}MaxWorkGroupSize              = '{28}'
{49}{50}MaxWorkItemDimensions         = '{29}'
{49}{50}MaxWorkItemSizes              = '{30}'
{49}{50}MaxWriteImageArgs             = '{31}'
{49}{50}MemBaseAddrAlign              = '{32}'
{49}{50}MinDataTypeAlignSize          = '{33}'
{49}{50}Name                          = '{34}'
{49}{50}PreferredVectorWidthChar      = '{35}'
{49}{50}PreferredVectorWidthDouble    = '{36}'
{49}{50}PreferredVectorWidthFloat     = '{37}'
{49}{50}PreferredVectorWidthInt       = '{38}'
{49}{50}PreferredVectorWidthLong      = '{39}'
{49}{50}PreferredVectorWidthShort     = '{40}'
{49}{50}Profile                       = '{41}'
{49}{50}ProfilingTimerResolution      = '{42}'
{49}{50}QueueProperties               = '{43}'
{49}{50}SingleFPConfig                = '{44}'
{49}{50}Type                          = '{45}'
{49}{50}Vendor                        = '{46}'
{49}{50}VendorID                      = '{47}'
{49}{50}Version                       = '{48}'
{49}{52}",

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
                CLDeviceType,
                Vendor,
                VendorID,
                Version,
                identation,
                additionalIdentation,
                '{',
                '}'
             );

        }

        public override string ToString()
        {
            return ToIdentedString(0, Globals.IdentSize);
        }
        #endregion
    }
}