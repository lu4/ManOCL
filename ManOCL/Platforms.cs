using System;
using System.Collections;
using System.Collections.Generic;

using ManOCL.Native;

namespace ManOCL
{
    public partial class Platforms : IEnumerable<Platform>
    {
        public const Int32 DefaultCount = 8;

        private Platform[] platforms;
        internal OpenCLPlatform[] OpenCLPlatforms { get; private set; }

        internal Platforms(OpenCLPlatform[] openCLPlatforms, Int32 platformInfoBufferSize)
        {
			this.OpenCLPlatforms = openCLPlatforms;
            this.platforms = new Platform[openCLPlatforms.Length];
            
            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i] = new Platform(openCLPlatforms[i], platformInfoBufferSize);
            }
        }

        private static OpenCLPlatform[] GetOpenCLPlatforms(Devices devices)
        {
            Dictionary<OpenCLPlatform, Device> platforms = new Dictionary<OpenCLPlatform, Device>();

            foreach (Device device in devices)
            {
                if (!platforms.ContainsKey(device.PlatformID))
                {
                    platforms.Add(device.PlatformID, device);
                }
            }

            OpenCLPlatform[] result = new OpenCLPlatform[platforms.Count];

            platforms.Keys.CopyTo(result, 0);

            return result;
        }

        public static Platforms Filter(Devices devices)
        {
            return new Platforms(GetOpenCLPlatforms(devices), Platform.DefaultInfoBufferSize);
        }
        public static Platforms Filter(Devices devices, Int32 platformInfoBufferSize)
        {
            return new Platforms(GetOpenCLPlatforms(devices), platformInfoBufferSize);
        }

        public static Platforms Create()
        {
            return Create(DefaultCount, Platform.DefaultInfoBufferSize);
        }
        public static Platforms Create(Int32 platformsCount, Int32 platformInfoBufferSize)
        {
            Int32 realPlatformsCount;

            OpenCLPlatform[] platforms = new OpenCLPlatform[platformsCount];

            OpenCLError.Validate(OpenCLDriver.clGetPlatformIDs(platforms.Length, platforms, out realPlatformsCount));

            Array.Resize(ref platforms, (Int32)realPlatformsCount);

            return new Platforms(platforms, platformInfoBufferSize);
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

        #region public static Platforms Default { get; } /* Singleton */
        private static Platforms _Default;
        public static Platforms Default
        {
            get
            {
                if (_Default == default(Platforms))
                {
                    _Default = Platforms.Create();
                }

                return _Default;
            }
        }
        #endregion

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (Platform platform in platforms)
            {
                yield return platform;
            }
        }
    }
}