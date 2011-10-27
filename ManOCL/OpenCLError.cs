using System;
using ManOCL.Internal.OpenCL;
using System.Runtime.InteropServices;
using ManOCL;
using ManOCL.Internal;


namespace ManOCL
{
	public class OpenCLException : Exception
	{
		public OpenCLException()
		{
		}

		public OpenCLException(String message)
			: base (message)
		{
		}
	}
	
	internal class OpenCLError : OpenCLException
	{
		internal CLError ErrorCode { get; private set; }

		internal OpenCLError(CLError errorCode)
		{
			this.ErrorCode = errorCode;
		}

        internal String BaseExceptionString
        {
            get
            {
                return base.ToString();
            }
        }

		public override String ToString()
		{
			return String.Format("OpenCL error occured, error code = {0}, additional info:\r\n{1}", ErrorCode, BaseExceptionString);
		}
		
		internal static void Validate(CLError error)
		{
			if (error != CLError.None) throw new OpenCLError(error);
		}

		internal static void Validate(Int32 error)
		{
			if ((CLError)error != CLError.None) throw new OpenCLError((CLError)error);
		}
	}

    internal class OpenCLBuildError : OpenCLError
    {
        public String BuildLog { get; private set; }

        public OpenCLBuildError(CLError error, String buildLog)
            : base(error)
        {
            this.BuildLog = buildLog;
        }

        public override String ToString()
        {
            return String.Format("Program failed to build, error code = {0}, build log:\r\n{1}\r\nAdditionalInfo:\r\n{2}", ErrorCode, BuildLog, BaseExceptionString);
        }

        internal static void ValidateBuild(CLProgram openclProgram, Device device, CLError error)
        {
            if (CLError.None != error)
            {
				SizeT bufferSize = SizeT.Zero;
				
                OpenCLError.Validate(OpenCLDriver.clGetProgramBuildInfo(openclProgram, device.CLDeviceID, CLProgramBuildInfo.Log, SizeT.Zero, IntPtr.Zero, ref bufferSize));
				
                byte[] buffer = new byte[(Int64)bufferSize];

                GCHandle bufferHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);

                try
                {
                    OpenCLError.Validate(OpenCLDriver.clGetProgramBuildInfo(openclProgram, device.CLDeviceID, CLProgramBuildInfo.Log, new SizeT(buffer.LongLength), bufferHandle.AddrOfPinnedObject(), ref bufferSize));

                    Int32 count = Array.IndexOf<byte>(buffer, 0);

                    throw new OpenCLBuildError(error, System.Text.Encoding.ASCII.GetString(buffer, 0, count < 0 ? buffer.Length : count).Trim());
                }
                finally
                {
                    bufferHandle.Free();
                }
            }
        }
    }
}

