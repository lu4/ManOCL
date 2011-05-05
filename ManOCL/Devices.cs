using System;
using System.Collections;
using System.Collections.Generic;

using ManOCL.Native;

namespace ManOCL
{
	public partial class Devices : IEnumerable<Device>
	{
        public const Int32 DefaultCount = 32;

        // General

        internal Device[] DeviceArray { get; private set; }
        internal OpenCLDevice[] OpenCLDeviceArray { get; private set; }

        protected static Device[] GetDeviceArray(OpenCLDevice[] ids, Int32 deviceInfoBufferSize)
        {
            Device[] devices = new Device[ids.Length];

            for (int i = 0; i < devices.Length; i++)
            {
                devices[i] = new Device(ids[i], deviceInfoBufferSize);
            }

            return devices;
        }
        protected static OpenCLDevice[] GetOpenCLDeviceArray(Device[] devices)
        {
            OpenCLDevice[] openclDevices = new OpenCLDevice[devices.Length];

            for (UInt32 i = 0; i < devices.Length; i++)
            {
                openclDevices[i] = devices[i].OpenCLDevice;
            }

            return openclDevices;
        }

        internal Devices(OpenCLDevice[] ids, Device[] devices)
        {
            this.DeviceArray = devices;
            this.OpenCLDeviceArray = ids;
        }
        internal Devices(OpenCLDevice[] ids, Int32 deviceInfoBufferSize)
            : this(ids, GetDeviceArray(ids, deviceInfoBufferSize))
        {
        }

        public Devices(params Device[] deviceArray)
            : this(GetOpenCLDeviceArray(deviceArray), (Device[])deviceArray.Clone())
	    {
	    }
	
	    public Int32 Count
	    {
	        get
	        {
	            return DeviceArray.Length;
	        }
	    }
        public Device this[Int32 index]
	    {
	        get
	        {
	            return DeviceArray[index];
	        }
	    }

        // Statics

        #region public static Devices Default { get; } /* Singleton */
        private static Devices _Default;
        public static Devices Default
        {
            get
            {
                if (_Default == default(Devices))
                {
                    _Default = Devices.Create(Platforms.Default, Device.DefaultDeviceType, Devices.DefaultCount, Device.DefaultInfoBufferSize);
                }

                return _Default;
            }
        }
        #endregion

        public static Devices Create(DeviceType deviceType)
        {
            return Create(Platforms.Default, deviceType, DefaultCount, Device.DefaultInfoBufferSize);
        }
        public static Devices Create(DeviceType deviceType, Int32 deviceCount, Int32 deviceInfoBufferSize)
        {
            return Create(Platforms.Default, deviceType, deviceCount, deviceInfoBufferSize);
        }
        public static Devices Create(Platform platform, DeviceType deviceType)
        {
            return Create(platform, deviceType, DefaultCount, Device.DefaultInfoBufferSize);
        }
        public static Devices Create(Platform platform, DeviceType deviceType, Int32 deviceCount, Int32 deviceInfoBufferSize)
        {
            Int32 realDeviceCount;

            OpenCLDevice[] deviceIds = new OpenCLDevice[deviceCount];

            OpenCLError.Validate(OpenCLDriver.clGetDeviceIDs(platform == null ? OpenCLPlatform.None : platform.OpenCLPlatform, deviceType, deviceCount, deviceIds, out realDeviceCount));

            Array.Resize(ref deviceIds, realDeviceCount);

            return new Devices(deviceIds, deviceInfoBufferSize);
        }
        public static Devices Create(Platforms platforms, DeviceType deviceType)
        {
            return Create(platforms, deviceType, DefaultCount, Device.DefaultInfoBufferSize);
        }
        public static Devices Create(Platforms platforms, DeviceType deviceType, Int32 deviceCount, Int32 deviceInfoBufferSize)
        {
            List<Device> rd = new List<Device>();

            foreach (Platform platform in platforms)
            {
                Devices devices = Devices.Create(platform, deviceType, deviceCount, deviceInfoBufferSize);

                foreach (Device device in devices)
                {
                    rd.Add(device);
                }
            }

            Device[] resultingDevices = rd.ToArray();
            OpenCLDevice[] resultingOpenCLDevices = GetOpenCLDeviceArray(resultingDevices);

            return new Devices(resultingOpenCLDevices, resultingDevices);
        }

        // IEnumerable

        public IEnumerator<Device> GetEnumerator()
        {
            foreach (Device device in DeviceArray)
            {
                yield return device;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (Device device in DeviceArray)
            {
                yield return device;
            }
        }
    }
}