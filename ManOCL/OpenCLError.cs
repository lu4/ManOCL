using System;
using ManOCL.Native;
using System.Runtime.InteropServices;
using ManOCL;

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
		internal Error ErrorCode { get; private set; }

		internal OpenCLError(Error errorCode)
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
			return String.Format(Resources.OpenCL_error_occured_ErrorCode_additional_info, ErrorCode, BaseExceptionString);
		}
		
		internal static void Validate(Error error)
		{
			if (error != Error.None) throw new OpenCLError(error);
		}

		internal static void Validate(Int32 error)
		{
			if ((Error)error != Error.None) throw new OpenCLError((Error)error);
		}
	}

    internal class OpenCLBuildError : OpenCLError
    {
        public String BuildLog { get; private set; }

        public OpenCLBuildError(Error error, String buildLog)
            : base(error)
        {
            this.BuildLog = buildLog;
        }

        public override String ToString()
        {
            return String.Format(Resources.Program_failed_to_build_ErrorCode_BuildLog_Additional_info, ErrorCode, BuildLog, BaseExceptionString);
        }

        internal static void ValidateBuild(OpenCLProgram openclProgram, Device device, Error error)
        {
            if (Error.None != error)
            {
                byte[] buffer = new byte[1024 * 64];

                GCHandle bufferHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);

                try
                {
                    OpenCLDriver.clGetProgramBuildInfo(openclProgram, device.OpenCLDevice, ProgramBuildInfo.Log, new IntPtr(buffer.Length), bufferHandle.AddrOfPinnedObject(), IntPtr.Zero);
                }
                finally
                {
                    bufferHandle.Free();
                }

                Int32 count = Array.IndexOf<byte>(buffer, 0);

                throw new OpenCLBuildError(error, System.Text.Encoding.ASCII.GetString(buffer, 0, count < 0 ? buffer.Length : count));
            }
        }
    }
}

