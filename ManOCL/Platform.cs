using System;
using ManOCL.Internal.OpenCL;
using ManOCL.Internal;


namespace ManOCL
{
    public partial class Platform
    {
        private Platform()
        {
            this.Name = "None";
            this.Vendor = "None";
            this.Profile = "None";
            this.Version = "None";
            this.Extensions = "None";
        }

        internal Platform(CLPlatformID openclPlatform)
        {
            this.CLPlatformID = openclPlatform;

            this.Name = GetPlatformInfo(this, CLPlatformInfo.Name);
            this.Vendor = GetPlatformInfo(this, CLPlatformInfo.Vendor);
            this.Profile = GetPlatformInfo(this, CLPlatformInfo.Profile);
            this.Version = GetPlatformInfo(this, CLPlatformInfo.Version);
            this.Extensions = GetPlatformInfo(this, CLPlatformInfo.Extensions);
        }

        internal CLPlatformID CLPlatformID { get; private set; }

        public String Name { get; private set; }
        public String Vendor { get; private set; }
        public String Profile { get; private set; }
        public String Version { get; private set; }
        public String Extensions { get; private set; }

        private static String GetPlatformInfo(Platform platform, CLPlatformInfo platformInfo)
        {
            if (platform.CLPlatformID.Value == IntPtr.Zero)
            {
                return "None";
            }
            else
            {
                SizeT buffer_size = SizeT.Zero;

                OpenCLError.Validate(OpenCLDriver.clGetPlatformInfo(platform.CLPlatformID, platformInfo, SizeT.Zero, null, ref buffer_size));
                
                Byte[] buffer = new Byte[(Int64)buffer_size];

                OpenCLError.Validate(OpenCLDriver.clGetPlatformInfo(platform.CLPlatformID, platformInfo, buffer_size, buffer, ref buffer_size));

                Int32 count = Array.IndexOf<byte>(buffer, 0);

                return System.Text.Encoding.ASCII.GetString(buffer, 0, count < 0 ? buffer.Length : count);
            }
        }
		
		internal String ToIdentedString(Int32 ident, Int32 identSize)
		{
			String identation = new String(' ', identSize * ident);
			String additionalIndentation = new String(' ', identSize);

			return String.Format(
@"{5}Platform '{0}'
{5}{7}
{5}{6}Name = '{0}'
{5}{6}Profile = '{1}'
{5}{6}Vendor = '{2}'
{5}{6}Version = '{3}'
{5}{6}Extensions = '{4}'
{5}{8}",
			Name, Profile, Vendor, Version, Extensions, identation, additionalIndentation, '{', '}');
		}
		
        public override String ToString()
        {
			return ToIdentedString(0, Globals.IdentSize);
        }

        public override Int32 GetHashCode()
        {
            return CLPlatformID.GetHashCode();
        }
        public override Boolean Equals(object obj)
        {
            return obj is Platform && Object.Equals(((Platform)(obj)).CLPlatformID, CLPlatformID);
        }

        public static Boolean operator ==(Platform platformA, Platform platformB)
        {
            if (Object.Equals(platformA, null) || Object.Equals(platformB, null))
            {
                return Object.Equals(platformA, platformB);
            }
            else
            {
                return Object.Equals(platformA.CLPlatformID, platformB.CLPlatformID);
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
                return !Object.Equals(platformA.CLPlatformID, platformB.CLPlatformID);
            }
        }
    }
}