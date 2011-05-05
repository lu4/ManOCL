namespace ManOCL.Native.OpenGL
{
    using ManOCL.Native;
    using System;
    using System.Runtime.InteropServices;

    public class OpenCLGLDriver
    {
        [DllImport("OpenCL")]
        public static extern Error clCreateFromGLBuffer(OpenCLContext context, MemFlags flags, uint bufobj, ref Error errcode_ret);
        [DllImport("OpenCL")]
        public static extern Error clCreateFromGLRenderbuffer(OpenCLContext context, MemFlags flags, uint renderbuffer, ref Error errcode_ret);
        [DllImport("OpenCL")]
        public static extern Error clCreateFromGLTexture2D(OpenCLContext context, MemFlags flags, int target, int miplevel, uint texture, ref Error errcode_ret);
        [DllImport("OpenCL")]
        public static extern Error clCreateFromGLTexture3D(OpenCLContext context, MemFlags flags, int target, int miplevel, uint texture, ref Error errcode_ret);
        [DllImport("OpenCL")]
        public static extern Error clEnqueueAcquireGLObjects(OpenCLCommandQueue command_queue, uint num_objects, [In] OpenCLMem[] mem_objects, uint num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, ref OpenCLEvent e);
        [DllImport("OpenCL")]
        public static extern Error clEnqueueReleaseGLObjects(OpenCLCommandQueue command_queue, uint num_objects, [In] OpenCLMem[] mem_objects, uint num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, ref OpenCLEvent e);
        [DllImport("OpenCL")]
        public static extern Error clGetGLObjectInfo(OpenCLMem memobj, ref uint gl_object_type, ref uint gl_object_name);
        [DllImport("OpenCL")]
        public static extern Error clGetGLTextureInfo(OpenCLMem memobj, uint param_name, IntPtr param_value_size, IntPtr param_value, ref IntPtr param_value_size_ret);
    }
}
