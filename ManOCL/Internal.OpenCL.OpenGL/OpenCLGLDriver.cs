namespace ManOCL.Internal.OpenCL.OpenGL
{
    using ManOCL.Internal.OpenCL;
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// This class provides the driver interface for OpenGL interoperability
    /// with OpenCL standard.
    /// </summary>
    internal class OpenCLGLDriver
    {
        [DllImport("OpenCL")]
        internal static extern CLError clCreateFromGLBuffer(CLContext context, CLMemFlags flags, int bufobj, ref CLError errcode_ret);
        [DllImport("OpenCL")]
        internal static extern CLError clCreateFromGLRenderbuffer(CLContext context, CLMemFlags flags, int renderbuffer, ref CLError errcode_ret);
        [DllImport("OpenCL")]
        internal static extern CLMem clCreateFromGLTexture2D(CLContext context, CLMemFlags flags, int target, int miplevel, uint texture, ref CLError errcode_ret);
        [DllImport("OpenCL")]
        internal static extern CLMem clCreateFromGLTexture3D(CLContext context, CLMemFlags flags, int target, int miplevel, uint texture, ref CLError errcode_ret);
        [DllImport("OpenCL")]
        internal static extern CLError clEnqueueAcquireGLObjects(CLCommandQueue command_queue, int num_objects, [In] CLMem[] mem_objects, int num_events_in_wait_list, [In] CLEvent[] event_wait_list, ref CLEvent e);
        [DllImport("OpenCL")]
        internal static extern CLError clEnqueueReleaseGLObjects(CLCommandQueue command_queue, int num_objects, [In] CLMem[] mem_objects, int num_events_in_wait_list, [In] CLEvent[] event_wait_list, ref CLEvent e);
        [DllImport("OpenCL")]
        internal static extern CLError clGetGLObjectInfo(CLMem memobj, ref int gl_object_type, ref int gl_object_name);
        [DllImport("OpenCL")]
        internal static extern CLError clGetGLTextureInfo(CLMem memobj, int param_name, SizeT param_value_size, IntPtr param_value, ref SizeT param_value_size_ret);
    }
}

