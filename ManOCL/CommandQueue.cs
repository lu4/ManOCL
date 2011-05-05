using System;
using System.Collections.Generic;
using System.Text;

namespace ManOCL
{
    using Native;

    public class CommandQueue
    {
        private Boolean disposed;

        internal CommandQueue(OpenCLCommandQueue openclCommandQueue, Context context, Device device, CommandQueueProperties commandQueueProperties)
        {
            this.Device = device;
            this.Context = context;
            this.OpenCLCommandQueue = openclCommandQueue;
            this.CommandQueueProperties = commandQueueProperties;
        }

        internal OpenCLCommandQueue OpenCLCommandQueue { get; private set; }

        public const CommandQueueProperties DefaultProperties = CommandQueueProperties.ProfilingEnable;

        public static CommandQueue Create(Context context, Device device, CommandQueueProperties commandQueueProperties)
        {
            Error error;

            OpenCLCommandQueue openclCommandQueue = OpenCLDriver.clCreateCommandQueue(context.OpenCLContext, device.OpenCLDevice, commandQueueProperties, out error);

            OpenCLError.Validate(error);

            return new CommandQueue(openclCommandQueue, context, device, commandQueueProperties);
        }

        public static CommandQueue CreateDefault()
        {
            return Create(Context.Default, Device.Default, CommandQueue.DefaultProperties);
        }
        public static CommandQueue CreateDefault(CommandQueueProperties commandQueueProperties)
        {
            return Create(Context.Default, Device.Default, commandQueueProperties);
        }
        public static CommandQueue CreateDefault(Device device)
        {
            return Create(Context.Default, device, CommandQueue.DefaultProperties);
        }
        public static CommandQueue CreateDefault(Device device, CommandQueueProperties commandQueueProperties)
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
                    _Default = CommandQueue.CreateDefault();
                }

                return _Default;
            }
        }
        #endregion

        public Device Device { get; private set; }
        public Context Context { get; private set; }

        public CommandQueueProperties CommandQueueProperties { get; private set; }

        public void Finish()
        {
            OpenCLError.Validate(OpenCLDriver.clFinish(OpenCLCommandQueue));
        }

        ~CommandQueue()
        {
            if (!disposed)
            {
                OpenCLError.Validate(OpenCLDriver.clReleaseCommandQueue(OpenCLCommandQueue));

                disposed = true;
            }
        }
   }
}