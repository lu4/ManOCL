using System;
using System.Collections.Generic;
using System.Text;

using ManOCL.Internal.OpenCL;

namespace ManOCL
{
    public class CommandQueue
    {
        private Boolean disposed;

        internal CommandQueue(CLCommandQueue openclCommandQueue, Context context, Device device, CommandQueueProperties commandQueueProperties)
        {
            this.Device = device;
            this.Context = context;
            this.CLCommandQueue = openclCommandQueue;
            this.CLCommandQueueProperties = commandQueueProperties;
        }

        internal CLCommandQueue CLCommandQueue { get; private set; }

        public const CommandQueueProperties DefaultProperties = CommandQueueProperties.ProfilingEnable;

        public static CommandQueue Create(Context context, Device device, CommandQueueProperties commandQueueProperties)
        {
            CLError error = CLError.None;

            CLCommandQueue openclCommandQueue = OpenCLDriver.clCreateCommandQueue(context.CLContext, device.CLDeviceID, (ManOCL.Internal.OpenCL.CLCommandQueueProperties)commandQueueProperties, ref error);

            OpenCLError.Validate(error);

            return new CommandQueue(openclCommandQueue, context, device, commandQueueProperties);
        }

        public static CommandQueue Create()
        {
            return Create(Context.Default, Device.Default, CommandQueue.DefaultProperties);
        }
        public static CommandQueue Create(CommandQueueProperties commandQueueProperties)
        {
            return Create(Context.Default, Device.Default, commandQueueProperties);
        }
        public static CommandQueue Create(Device device)
        {
            return Create(Context.Default, device, CommandQueue.DefaultProperties);
        }
        public static CommandQueue Create(Device device, CommandQueueProperties commandQueueProperties)
        {
            return Create(Context.Default, device, commandQueueProperties);
        }

        #region public static CommandQueue Default { get; } /* Singleton */
        private static CommandQueue _Default;
        public static CommandQueue Default
        {
            get
            {
                if (_Default == default(CommandQueue))
                {
                    _Default = CommandQueue.Create();
                }

                return _Default;
            }
			set
			{
				_Default = value;
			}
        }
        #endregion

        public Device Device { get; private set; }
        public Context Context { get; private set; }

        public CommandQueueProperties CLCommandQueueProperties { get; private set; }

        public void Finish()
        {
            OpenCLError.Validate(OpenCLDriver.clFinish(CLCommandQueue));
        }

        ~CommandQueue()
        {
            if (!disposed)
            {
                OpenCLError.Validate(OpenCLDriver.clReleaseCommandQueue(CLCommandQueue));

                disposed = true;
            }
        }
   }
}