using System;
using ManOCL.Native;

namespace ManOCL
{
    public partial class Platform
    {
        public const Int32 DefaultInfoBufferSize = 256;

        private Platform()
        {
            this.Name = "None";
            this.Vendor = "None";
            this.Profile = "None";
            this.Version = "None";
            this.Extensions = "None";
        }

        internal Platform(OpenCLPlatform openclPlatform, Int32 platformInfoBufferSize)
        {
            this.OpenCLPlatform = openclPlatform;

            this.Name = GetPlatformInfo(this, PlatformInfo.Name, platformInfoBufferSize);
            this.Vendor = GetPlatformInfo(this, PlatformInfo.Vender, platformInfoBufferSize);
            this.Profile = GetPlatformInfo(this, PlatformInfo.Profile, platformInfoBufferSize);
            this.Version = GetPlatformInfo(this, PlatformInfo.Version, platformInfoBufferSize);
            this.Extensions = GetPlatformInfo(this, PlatformInfo.Extensions, platformInfoBufferSize);
        }

        internal OpenCLPlatform OpenCLPlatform { get; private set; }

        public String Name { get; private set; }
        public String Vendor { get; private set; }
        public String Profile { get; private set; }
        public String Version { get; private set; }
        public String Extensions { get; private set; }

        #region public static Platform Default { get; } /* Singleton */
        private static Platform _Default;
        public static Platform Default
        {
            get
            {
                if (_Default == default(Platform))
                {
                    _Default = Platforms.Default[0];
                }

                return _Default;
            }
        }
        #endregion

        private static String GetPlatformInfo(Platform platform, PlatformInfo platformInfo, Int32 queryBufferSize)
        {
            if (platform.OpenCLPlatform.Value == IntPtr.Zero)
            {
                return "None";
            }
            else
            {
                IntPtr buffer_size = IntPtr.Zero;

                byte[] buffer = new byte[queryBufferSize];

                OpenCLError.Validate(OpenCLDriver.clGetPlatformInfo(platform.OpenCLPlatform, platformInfo, new IntPtr(queryBufferSize), buffer, buffer_size));

                Int32 count = Array.IndexOf(buffer, 0);

                return System.Text.Encoding.ASCII.GetString(buffer, 0, count < 0 ? buffer.Length : count);
            }
        }

        public override String ToString()
        {
            return String.Format("Platform ('{0}'):\r\n\tName = '{0}'\r\n\tProfile = '{1}'\r\n\tVendor = '{2}'\r\n\tVersion = '{3}'\r\n\tExtensions = '{4}'", Name, Profile, Vendor, Version, Extensions);
        }

        public override Int32 GetHashCode()
        {
            return OpenCLPlatform.GetHashCode();
        }
        public override Boolean Equals(object obj)
        {
            return obj is Platform && Object.Equals(((Platform)(obj)).OpenCLPlatform, OpenCLPlatform);
        }

        public static Boolean operator ==(Platform platformA, Platform platformB)
        {
            if (Object.Equals(platformA, null) || Object.Equals(platformB, null))
            {
                return Object.Equals(platformA, platformB);
            }
            else
            {
                return Object.Equals(platformA.OpenCLPlatform, platformB.OpenCLPlatform);
            }
        }
        public static Boolean operator !=(Platform platformA, Platform platformB)
        {
            if (Object.Equals(platformA, null) || Object.Equals(platformB, null))
            {
                return !Object.Equals(platformA, platformB);
            }
            else
            {
                return !Object.Equals(platformA.OpenCLPlatform, platformB.OpenCLPlatform);
            }
        }
    }
}