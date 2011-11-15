using System;
using System.Runtime.InteropServices;

using ManOCL;
using ManOCL.Internal.OpenCL;
using ManOCL.Internal.OpenCL.OpenGL;
using ManOCL.Internal;

namespace ManOCL
{
    public class DeviceImage : Argument, IDisposable
    {
        public const DeviceBufferAccess DefaultDeviceBufferAccess = DeviceBufferAccess.ReadWrite;

        private CLMem[] memObjects;

        public DeviceImage(Mem mem)
        {
            this.memObjects = new CLMem[] { new CLMem { Value = mem.Value } };
        }

        public static DeviceImage CreateFromTexture2D(UInt32 texture, Int32 mipLevel, DeviceBufferAccess access, Context context)
        {
            CLError error = CLError.None;

            CLMem mem = ManOCL.Internal.OpenCL.OpenGL.OpenCLGLDriver.clCreateFromGLTexture2D(context.CLContext, GetMemFlags(access), 3553 /* GL_TEXTURE_2D */, mipLevel, texture, ref error);

            OpenCLError.Validate(error);

            DeviceImage result = new DeviceImage(new Mem { Value = mem.Value });

            return result;
        }

        public static DeviceImage CreateFromTexture2D(UInt32 texture, DeviceBufferAccess access, Context context)
        {
            return CreateFromTexture2D(texture, 0, access, context);
        }

        public static DeviceImage CreateFromTexture2D(UInt32 texture, Int32 mipLevel, Context context)
        {
            return CreateFromTexture2D(texture, mipLevel, DefaultDeviceBufferAccess, context);
        }

        public static DeviceImage CreateFromTexture2D(UInt32 texture, Context context)
        {
            return CreateFromTexture2D(texture, 0, DefaultDeviceBufferAccess, context);
        }

        public static DeviceImage CreateFromTexture2D(UInt32 texture, Int32 mipLevel, DeviceBufferAccess access)
        {
            return CreateFromTexture2D(texture, mipLevel, access, Context.Default);
        }

        public static DeviceImage CreateFromTexture2D(UInt32 texture, DeviceBufferAccess access)
        {
            return CreateFromTexture2D(texture, 0, access, Context.Default);
        }

        public static DeviceImage CreateFromTexture2D(UInt32 texture, Int32 mipLevel)
        {
            return CreateFromTexture2D(texture, mipLevel, DefaultDeviceBufferAccess, Context.Default);
        }

        public static DeviceImage CreateFromTexture2D(UInt32 texture)
        {
            return CreateFromTexture2D(texture, 0, DefaultDeviceBufferAccess, Context.Default);
        }

        internal Boolean Acquired { get; private set; }

        public Event Acquire(CommandQueue commandQueue, Events eventWaitList)
        {
            CLEvent e = new CLEvent();

            OpenCLError.Validate(OpenCLGLDriver.clEnqueueAcquireGLObjects(commandQueue.CLCommandQueue, memObjects.Length, memObjects, eventWaitList.Count, eventWaitList.OpenCLEventArray, ref e));

            Acquired = true;

            return new Event(e);
        }

        public Event Acquire(CommandQueue commandQueue)
        {
            return Acquire(commandQueue, Events.Empty);
        }

        public Event Acquire(Events eventWaitList)
        {
            return Acquire(CommandQueue.Default, eventWaitList);
        }

        public Event Acquire()
        {
            return Acquire(CommandQueue.Default, Events.Empty);
        }

        public Event Release(CommandQueue commandQueue, Events eventWaitList)
        {
            CLEvent e = new CLEvent();

            OpenCLError.Validate(OpenCLGLDriver.clEnqueueReleaseGLObjects(commandQueue.CLCommandQueue, memObjects.Length, memObjects, eventWaitList.Count, eventWaitList.OpenCLEventArray, ref e));

            Acquired = false;

            return new Event(e);
        }

        public Event Release(CommandQueue commandQueue)
        {
            return Release(commandQueue, Events.Empty);
        }

        public Event Release(Events events)
        {
            return Release(CommandQueue.Default, events);
        }

        public Event Release()
        {
            return Release(CommandQueue.Default, Events.Empty);
        }

        internal override void SetAsKernelArgument(CLKernel kernel, Int32 index)
        {
            OpenCLError.Validate(OpenCLDriver.clSetKernelArg(kernel, index, new SizeT(IntPtr.Size), memObjects));
        }

        #region IDisposable implementation
        public void Dispose()
        {
            if (Acquired) Release();
        }
        #endregion
    }
}