using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using ManOCL.Internal.OpenCL;

namespace ManOCL
{
	public partial class Devices : IEnumerable<Device>
	{
        // General

        internal Device[] DeviceArray { get; private set; }
        internal CLDeviceID[] OpenCLDeviceArray { get; private set; }

        internal static Device[] GetDeviceArray(CLDeviceID[] ids)
        {
            Device[] devices = new Device[ids.Length];

            for (int i = 0; i < devices.Length; i++)
            {
                devices[i] = new Device(ids[i]);
            }

            return devices;
        }

        internal static CLDeviceID[] GetOpenCLDeviceArray(Device[] devices)
        {
            CLDeviceID[] openclDevices = new CLDeviceID[devices.Length];

            for (UInt32 i = 0; i < devices.Length; i++)
            {
                openclDevices[i] = devices[i].CLDeviceID;
            }

            return openclDevices;
        }

        internal Devices(CLDeviceID[] ids, Device[] devices)
        {
            this.DeviceArray = devices;
            this.OpenCLDeviceArray = ids;
        }
        
        internal Devices(CLDeviceID[] ids)
            : this(ids, GetDeviceArray(ids))
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

		public static Devices Create()
		{
			return Create(CLDeviceType.All, Context.Default.Platforms);
		}
        public static Devices Create(CLDeviceType deviceType)
        {
            return Create(deviceType, Context.Default.Platforms);
        }
        public static Devices Create(CLDeviceType deviceType, Platform platform)
        {
            Int32 deviceCount = 0;

            CLPlatformID pfm = platform == null ? new CLPlatformID() : platform.CLPlatformID;

            OpenCLError.Validate(OpenCLDriver.clGetDeviceIDs(pfm, (ManOCL.Internal.OpenCL.CLDeviceType)deviceType, 0, null, ref deviceCount));

            CLDeviceID[] deviceIds = new CLDeviceID[deviceCount];

            OpenCLError.Validate(OpenCLDriver.clGetDeviceIDs(pfm, (ManOCL.Internal.OpenCL.CLDeviceType)deviceType, deviceCount, deviceIds, ref deviceCount));

            return new Devices(deviceIds);
        }
        public static Devices Create(CLDeviceType deviceType, Platforms platforms)
        {
            List<Device> rd = new List<Device>();

            foreach (Platform platform in platforms)
            {
                Devices devices = Devices.Create(deviceType, platform);

                foreach (Device device in devices)
                {
                    rd.Add(device);
                }
            }

            Device[] resultingDevices = rd.ToArray();
            CLDeviceID[] resultingOpenCLDevices = GetOpenCLDeviceArray(resultingDevices);

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

		internal String ToIdentedString(Int32 ident, Int32 identSize)
		{
			String identation = new String(' ', identSize * ident);

			StringBuilder sb = new StringBuilder();
			
			sb.AppendLine(identation +  "Platforms");
			sb.AppendLine(identation + "{");
			
			foreach (Device device in DeviceArray)
			{
				sb.AppendLine(device.ToIdentedString(ident + 1, identSize));
			}
			
			sb.AppendLine(identation + "}");
			
			return sb.ToString();			
		}
		
		public override string ToString ()
		{
			return ToIdentedString(0, Globals.IdentSize);
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