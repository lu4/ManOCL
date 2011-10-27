using System;
using System.Collections.Generic;
using System.Text;
using ManOCL.Internal.OpenCL;
using System.Runtime.InteropServices;
using ManOCL.Internal;


namespace ManOCL
{
    public partial class Context
    {
        private Boolean disposed;
				
        private Context(CLContext openclContext, Platforms platforms, Devices devices)
        {			
            this.Devices = devices;
            this.Platforms = platforms;
            this.CLContext = openclContext;
        }

        private static IntPtr[] GetContextProperties(Platforms platforms)
        {
            Int32 count = platforms.Count;
            IntPtr[] properties = new IntPtr[2 * platforms.Count + 1];

            for (int i = 0; i < count; i++)
            {
                properties[2 * i] = new IntPtr((Int32)CLContextProperties.Platform);
                properties[2 * i + 1] = platforms[i].CLPlatformID.Value;
            }
            return properties;
        }

        internal CLContext CLContext { get; private set; }

        public static Context Create()
        {
            return Create(Context.Default.Platforms, Context.Default.Devices);
        }
        public static Context Create(Devices devices)
        {
            return Create(Context.Default.Platforms, devices);
        }
        public static Context Create(Platforms platforms)
        {
            return Create(platforms, Devices.Create(Device.DefaultDeviceType, platforms));
        }
        public static Context Create(Platforms platforms, Devices devices)
        {
            CLError error = CLError.None;

            // TODO: Add parameter pfn_notify (logging function)
            CLContext openclContext = OpenCLDriver.clCreateContext(GetContextProperties(platforms), devices.Count, devices.OpenCLDeviceArray, null, IntPtr.Zero, ref error);

            OpenCLError.Validate(error);

            return new Context(openclContext, platforms, devices);
        }

        public static Context ShareWithCGL(IntPtr cglShareGroup)
        {
            IntPtr[] properties = 
			{
				new IntPtr(0x10000000), // CL_CONTEXT_PROPERTY_USE_CGL_SHAREGROUP_APPLE
				cglShareGroup,
				new IntPtr(0)
			};

            CLError error = CLError.None;

            // TODO: Add parameter pfn_notify (logging function)
            CLContext openclContext = OpenCLDriver.clCreateContext(properties, 0, null, null, IntPtr.Zero, ref error);

            OpenCLError.Validate(error);

            SizeT devicesSize = SizeT.Zero;

            OpenCLError.Validate(OpenCLDriver.clGetContextInfo(openclContext, CLContextInfo.Devices, SizeT.Zero, IntPtr.Zero, ref devicesSize));

            CLDeviceID[] devices = new CLDeviceID[((Int64)(devicesSize)) / IntPtr.Size];

            GCHandle devicesHandle = GCHandle.Alloc(devices, GCHandleType.Pinned);

            try
            {
                OpenCLError.Validate(OpenCLDriver.clGetContextInfo(openclContext, CLContextInfo.Devices, devicesSize, devicesHandle.AddrOfPinnedObject(), ref devicesSize));

                Dictionary<CLPlatformID, CLPlatformID> platformsDictionary = new Dictionary<CLPlatformID, CLPlatformID>();

                CLPlatformID[] platforms = null;

                foreach (CLDeviceID device in devices)
                {
                    SizeT platformsSize = SizeT.Zero;

                    OpenCLError.Validate(OpenCLDriver.clGetDeviceInfo(device, CLDeviceInfo.Platform, SizeT.Zero, platforms, ref platformsSize));

                    platforms = new CLPlatformID[((Int64)(platformsSize)) / IntPtr.Size];

                    OpenCLError.Validate(OpenCLDriver.clGetDeviceInfo(device, CLDeviceInfo.Platform, platformsSize, platforms, ref platformsSize));

                    foreach (CLPlatformID platform in platforms)
                    {
                        if (!platformsDictionary.ContainsKey(platform))
                        {
                            platformsDictionary.Add(platform, platform);
                        }
                    }
                }

                platforms = new CLPlatformID[platformsDictionary.Count];

                Int32 index = 0;

                foreach (var platform in platformsDictionary.Keys)
                {
                    platforms[index++] = platform;
                }

                return new Context(openclContext, new Platforms(platforms), new Devices(devices));
            }
            finally
            {
                devicesHandle.Free();
            }
        }
        public Devices Devices { get; private set; }
        
        public Platforms Platforms { get; private set; }

        #region public static Context Default { get; } /* Singleton */
        private static Context _Default;
        public static Context Default
        {
            get
            {
                if (_Default == null)
                {
					Platforms platforms = Platforms.Create();
                    Devices devices = Devices.Create(CLDeviceType.All, platforms);
						
					_Default = Create(platforms, devices);
                }

                return _Default;
            }
            set
            {
                _Default = value;
            }
        }
        #endregion
				
		internal String ToIndentedString(Int32 ident, Int32 identSize)
		{
			String identation = new String(' ', identSize * ident);
			
			StringBuilder sb = new StringBuilder();
			
			sb.AppendLine(identation + "Context");
			sb.AppendLine(identation + "{");
			sb.AppendLine(Platforms.ToIdentedString(ident + 1, identSize));
			sb.AppendLine(Devices.ToIdentedString(ident + 1, identSize));			
			sb.AppendLine(identation + "}");
			
			return sb.ToString();			
		}
		
 		public override string ToString ()
		{
			return ToIndentedString(0, Globals.IdentSize);
		}

		~Context()
        {
            if (!disposed)
            {
                OpenCLError.Validate(OpenCLDriver.clReleaseContext(CLContext));

                disposed = true;
            }
        }
    }
}
