using System;
using System.Collections.Generic;
using System.Text;
using ManOCL.Native;
using System.Runtime.InteropServices;

namespace ManOCL
{
    public partial class Context
    {
        private Boolean disposed;

        private Context(OpenCLContext openclContext, Platforms platforms, Devices devices)
        {
            this.Devices = devices;
            this.Platforms = platforms;
            this.OpenCLContext = openclContext;
        }

        private static IntPtr[] GetContextProperties(Platforms platforms)
        {
            Int32 count = platforms.Count;
            IntPtr[] properties = new IntPtr[2 * platforms.Count + 1];

            for (int i = 0; i < count; i++)
            {
                properties[2 * i] = new IntPtr((Int32)ContextProperties.Platform);
                properties[2 * i + 1] = platforms[i].OpenCLPlatform.Value;
            }
            return properties;
        }

        internal OpenCLContext OpenCLContext { get; private set; }

        public static Context Create()
        {
            return Create(Platforms.Default, Devices.Default);
        }
        public static Context Create(Devices devices)
        {
            return Create(Platforms.Default, devices);
        }
        public static Context Create(Platforms platforms)
        {
            return Create(platforms, Devices.Default);
        }
        public static Context Create(Platforms platforms, Devices devices)
        {
            IntPtr[] properties = GetContextProperties(platforms);

            GCHandle propertiesHandle = GCHandle.Alloc(properties, GCHandleType.Pinned);

            try
            {
                Error error;

                // TODO: Add parameter pfn_notify (logging function)
                OpenCLContext openclContext = OpenCLDriver.clCreateContext(propertiesHandle.AddrOfPinnedObject(), devices.Count, devices.OpenCLDeviceArray, null, IntPtr.Zero, out error);

                OpenCLError.Validate(error);

                return new Context(openclContext, platforms, devices);
            }
            finally
            {
                propertiesHandle.Free();
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
                if (_Default == default(Context))
                {
                    _Default = Create();
                }

                return _Default;
            }
        }
        #endregion

        ~Context()
        {
            if (!disposed)
            {
                OpenCLError.Validate(OpenCLDriver.clReleaseContext(OpenCLContext));

                disposed = true;
            }
        }
    }
}
