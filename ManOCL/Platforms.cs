using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using ManOCL.Internal.OpenCL;

namespace ManOCL
{
    public partial class Platforms : IEnumerable<Platform>
    {
        private Platform[] platforms;
        internal CLPlatformID[] OpenCLPlatforms { get; private set; }

        internal Platforms(CLPlatformID[] openCLPlatforms)
        {
			this.OpenCLPlatforms = openCLPlatforms;
            this.platforms = new Platform[openCLPlatforms.Length];
            
            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i] = new Platform(openCLPlatforms[i]);
            }
        }

        private static CLPlatformID[] GetOpenCLPlatforms(Devices devices)
        {
            Dictionary<CLPlatformID, Device> platforms = new Dictionary<CLPlatformID, Device>();

            foreach (Device device in devices)
            {
                if (!platforms.ContainsKey(device.PlatformID))
                {
                    platforms.Add(device.PlatformID, device);
                }
            }

            CLPlatformID[] result = new CLPlatformID[platforms.Count];

            platforms.Keys.CopyTo(result, 0);

            return result;
        }

        public static Platforms Filter(Devices devices)
        {
            return new Platforms(GetOpenCLPlatforms(devices));
        }

        public static Platforms Create()
        {
            Int32 platformsCount = 0;

            OpenCLError.Validate(OpenCLDriver.clGetPlatformIDs(0, null, ref platformsCount));

            CLPlatformID[] platforms = new CLPlatformID[platformsCount];

            OpenCLError.Validate(OpenCLDriver.clGetPlatformIDs(platformsCount, platforms, ref platformsCount));

            return new Platforms(platforms);
        }

        public Int32 Count
        {
            get
            {
                return platforms.Length;
            }
        }

        public Platform this[Int32 index]
        {
            get
            {
                return platforms[index];
            }
        }

        public IEnumerator<Platform> GetEnumerator()
        {
            foreach (Platform platform in platforms)
            {
                yield return platform;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (Platform platform in platforms)
            {
                yield return platform;
            }
        }
		
		internal String ToIdentedString(Int32 ident, Int32 identSize)
		{
			String identation = new String(' ', identSize * ident);

			StringBuilder sb = new StringBuilder();
			
			sb.AppendLine(identation +  "Platforms");
			sb.AppendLine(identation + "{");
			
			foreach (Platform platform in platforms)
			{
				sb.AppendLine(platform.ToIdentedString(ident + 1, identSize));
			}
			
			sb.AppendLine(identation + "}");
			
			return sb.ToString();			
		}
		
 		public override string ToString ()
		{
			return ToIdentedString(0, Globals.IdentSize);
		}
   }
}