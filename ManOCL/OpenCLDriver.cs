//#define PROFILE_DRIVER_CALLS

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManOCL.Native
{
    public partial class OpenCLDriver
	{	
#if PROFILE_DRIVER_CALLS
	    public static Error clBuildProgram(OpenCLProgram program, Int32 num_devices, [In] OpenCLDevice[] device_list, IntPtr options, NotifyFunction func, IntPtr user_data)
        {
            Console.WriteLine("Calling Error clBuildProgram(OpenCLProgram program, Int32 num_devices, [In] OpenCLDevice[] device_list, IntPtr options, NotifyFunction func, IntPtr user_data)");
            return default(Error);
        }
	    public static Error clBuildProgram(OpenCLProgram program, Int32 num_devices, [In] OpenCLDevice[] device_list, String options, NotifyFunction func, IntPtr user_data)
        {
            Console.WriteLine("Calling Error clBuildProgram(OpenCLProgram program, Int32 num_devices, [In] OpenCLDevice[] device_list, String options, NotifyFunction func, IntPtr user_data)");
            return default(Error);
        }
	    
		public static OpenCLMem clCreateBuffer(OpenCLContext context, MemFlags flags, IntPtr size, [In] Byte[] bytes, out Error error)
        {
            error = default(Error);
            Console.WriteLine("Calling OpenCLMem clCreateBuffer(OpenCLContext context, MemFlags flags, IntPtr size, [In] Byte[] bytes, out Error error)");
            return default(OpenCLMem);
        }
	    public static OpenCLMem clCreateBuffer(OpenCLContext context, MemFlags flags, IntPtr size, IntPtr host_ptr, out Error error)
        {
            error = default(Error);
            Console.WriteLine("Calling OpenCLMem clCreateBuffer(OpenCLContext context, MemFlags flags, IntPtr size, IntPtr host_ptr, out Error error)");
            return default(OpenCLMem);
        }

		public static OpenCLCommandQueue clCreateCommandQueue(OpenCLContext context, OpenCLDevice device, CommandQueueProperties properties, out Error error)
        {
            error = default(Error);
            Console.WriteLine("Calling OpenCLCommandQueue clCreateCommandQueue(OpenCLContext context, OpenCLDevice device, CommandQueueProperties properties, out Error error)");
            return default(OpenCLCommandQueue);
        }
		public static OpenCLContext clCreateContext(IntPtr properties, Int32 num_devices, [In] OpenCLDevice[] devices, LoggingFunction pfn_notify, IntPtr user_data, out Error error)
        {
            error = default(Error);
            Console.WriteLine("Calling OpenCLContext clCreateContext(IntPtr properties, Int32 num_devices, [In] OpenCLDevice[] devices, LoggingFunction pfn_notify, IntPtr user_data, out Error error)");
            return default(OpenCLContext);
        }
	    public static OpenCLContext clCreateContextFromType(IntPtr properties, DeviceType device_type, LoggingFunction pfn_notify, IntPtr user_data, out Error error)
        {
            error = default(Error);
            Console.WriteLine("Calling OpenCLContext clCreateContextFromType(IntPtr properties, DeviceType device_type, LoggingFunction pfn_notify, IntPtr user_data, out Error error)");
            return default(OpenCLContext);
        }
	    public static OpenCLMem clCreateImage2D(OpenCLContext context, MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, IntPtr host_ptr, out Error error)
        {
            error = default(Error);
            Console.WriteLine("Calling OpenCLMem clCreateImage2D(OpenCLContext context, MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, IntPtr host_ptr, out Error error)");
            return default(OpenCLMem);
        }
	    public static OpenCLMem clCreateImage3D(OpenCLContext context, MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, IntPtr host_ptr, out Error error)
        {
            error = default(Error);
            Console.WriteLine("Calling OpenCLMem clCreateImage3D(OpenCLContext context, MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, IntPtr host_ptr, out Error error)");
            return default(OpenCLMem);
        }
	    public static OpenCLKernel clCreateKernel(OpenCLProgram program, String kernel_name, out Error error)
        {
            error = default(Error);
            Console.WriteLine("Calling OpenCLKernel clCreateKernel(OpenCLProgram program, String kernel_name, out Error error)");
            return default(OpenCLKernel);
        }
	    public static Error clCreateKernelsInProgram(OpenCLProgram program, Int32 num_kernels, [Out] OpenCLKernel[] kernels, out Int32 num_kernels_ret)
        {
            num_kernels_ret = 1;
            kernels = new OpenCLKernel[] { new OpenCLKernel() };
            Console.WriteLine("Calling Error clCreateKernelsInProgram(OpenCLProgram program, Int32 num_kernels, [Out] OpenCLKernel[] kernels, out Int32 num_kernels_ret)");
            return default(Error);
        }

		public static OpenCLProgram clCreateProgramWithBinary(OpenCLContext context, Int32 num_devices, [In] OpenCLDevice[] device_list, [In] IntPtr[] lengths, [In] IntPtr[] binaries, [In] Int32[] binary_status, out Error error)
        {
            error = default(Error);
            Console.WriteLine("Calling OpenCLProgram clCreateProgramWithBinary(OpenCLContext context, Int32 num_devices, [In] OpenCLDevice[] device_list, [In] IntPtr[] lengths, [In] IntPtr[] binaries, [In] Int32[] binary_status, out Error error)");
            return default(OpenCLProgram);
        }
        public static OpenCLProgram clCreateProgramWithSource(OpenCLContext context, Int32 count, IntPtr Strings, [In] IntPtr[] lengths, out Error error)
        {
            error = default(Error);
            Console.WriteLine("Calling OpenCLProgram clCreateProgramWithSource(OpenCLContext context, Int32 count, IntPtr Strings, [In] IntPtr[] lengths, out Error error)");
            return default(OpenCLProgram);
        }
        public static OpenCLProgram clCreateProgramWithSource(OpenCLContext context, Int32 count, [In] String[] sources, [In] IntPtr[] lengths, out Error error)
        {
            error = default(Error);
            Console.WriteLine("Calling OpenCLProgram clCreateProgramWithSource(OpenCLContext context, Int32 count, [In] String[] sources, [In] IntPtr[] lengths, out Error error)");
            return default(OpenCLProgram);
        }
        public static OpenCLProgram clCreateProgramWithSource(OpenCLContext context, Int32 count, [In] Byte[][] sources, [In] IntPtr[] lengths, out Error error)
        {
            error = default(Error);
            Console.WriteLine("Calling OpenCLProgram clCreateProgramWithSource(OpenCLContext context, Int32 count, [In] Byte[][] sources, [In] IntPtr[] lengths, out Error error)");
            return default(OpenCLProgram);
        }
        public static OpenCLSampler clCreateSampler(OpenCLContext context, Boolean normalized_coords, AddressingMode addressing_mode, FilterMode filter_mode, out Error error)
        {
            error = default(Error);
            Console.WriteLine("Calling OpenCLSampler clCreateSampler(OpenCLContext context, Boolean normalized_coords, AddressingMode addressing_mode, FilterMode filter_mode, out Error error)");
            return default(OpenCLSampler);
        }
	    public static Error clEnqueueBarrier(OpenCLCommandQueue command_queue)
        {
            Console.WriteLine("Calling Error clEnqueueBarrier(OpenCLCommandQueue command_queue)");
            return default(Error);
        }
	    public static Error clEnqueueCopyBuffer(OpenCLCommandQueue command_queue, OpenCLMem src_buffer, OpenCLMem dst_buffer, IntPtr src_offset, IntPtr dst_offset, IntPtr cb, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)
        {
            e = default(OpenCLEvent);
            Console.WriteLine("Calling Error clEnqueueCopyBuffer(OpenCLCommandQueue command_queue, OpenCLMem src_buffer, OpenCLMem dst_buffer, IntPtr src_offset, IntPtr dst_offset, IntPtr cb, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueCopyBufferToImage(OpenCLCommandQueue command_queue, OpenCLMem src_buffer, OpenCLMem dst_image, IntPtr src_offset, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)
        {
            e = default(OpenCLEvent);
            Console.WriteLine("Calling Error clEnqueueCopyBufferToImage(OpenCLCommandQueue command_queue, OpenCLMem src_buffer, OpenCLMem dst_image, IntPtr src_offset, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueCopyImage(OpenCLCommandQueue command_queue, OpenCLMem src_image, OpenCLMem dst_image, IntPtr[] src_origin, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)
        {
            e = default(OpenCLEvent);
            Console.WriteLine("Calling Error clEnqueueCopyImage(OpenCLCommandQueue command_queue, OpenCLMem src_image, OpenCLMem dst_image, IntPtr[] src_origin, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueCopyImageToBuffer(OpenCLCommandQueue command_queue, OpenCLMem src_image, OpenCLMem dst_buffer, IntPtr[] src_origin, IntPtr[] region, IntPtr dst_offset, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)
        {
            e = default(OpenCLEvent);
            Console.WriteLine("Calling Error clEnqueueCopyImageToBuffer(OpenCLCommandQueue command_queue, OpenCLMem src_image, OpenCLMem dst_buffer, IntPtr[] src_origin, IntPtr[] region, IntPtr dst_offset, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)");
            return default(Error);
        }
	    public static IntPtr clEnqueueMapBuffer(OpenCLCommandQueue command_queue, OpenCLMem buffer, Boolean blocking_map, Map map_flags, IntPtr offset, IntPtr cb, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e, out Error error)
        {
            error = default(Error);
            e = default(OpenCLEvent);
            Console.WriteLine("Calling IntPtr clEnqueueMapBuffer(OpenCLCommandQueue command_queue, OpenCLMem buffer, Boolean blocking_map, Map map_flags, IntPtr offset, IntPtr cb, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e, out Error error)");
            return default(IntPtr);
        }
	    public static IntPtr clEnqueueMapImage(OpenCLCommandQueue command_queue, OpenCLMem image, Boolean blocking_map, Map map_flags, IntPtr[] origin, IntPtr[] region, out IntPtr image_row_pitch, out IntPtr image_slice_pitch, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e, out Error error)
        {
            image_slice_pitch = default(IntPtr);
            image_row_pitch = default(IntPtr);
            e = default(OpenCLEvent);
            error = default(Error);
            Console.WriteLine("Calling IntPtr clEnqueueMapImage(OpenCLCommandQueue command_queue, OpenCLMem image, Boolean blocking_map, Map map_flags, IntPtr[] origin, IntPtr[] region, out IntPtr image_row_pitch, out IntPtr image_slice_pitch, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e, out Error error)");
            return default(IntPtr);
        }
	    public static Error clEnqueueMarker(OpenCLCommandQueue command_queue, out OpenCLEvent e)
        {
            e = default(OpenCLEvent);
            Console.WriteLine("Calling Error clEnqueueMarker(OpenCLCommandQueue command_queue, out OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueNativeKernel(OpenCLCommandQueue command_queue, UserFunction user_func, [In] IntPtr[] args, IntPtr cb_args, Int32 num_mem_objects, [In] OpenCLMem[] mem_list, [In] IntPtr[] args_mem_loc, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)
        {
            e = default(OpenCLEvent);
            Console.WriteLine("Calling Error clEnqueueNativeKernel(OpenCLCommandQueue command_queue, UserFunction user_func, [In] IntPtr[] args, IntPtr cb_args, Int32 num_mem_objects, [In] OpenCLMem[] mem_list, [In] IntPtr[] args_mem_loc, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueNDRangeKernel(OpenCLCommandQueue command_queue, OpenCLKernel kernel, Int32 work_dim, [In] IntPtr[] global_work_offset, [In] IntPtr[] global_work_size, [In] IntPtr[] local_work_size, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)
        {
            e = default(OpenCLEvent);
            Console.WriteLine("Calling Error clEnqueueNDRangeKernel(OpenCLCommandQueue command_queue, OpenCLKernel kernel, Int32 work_dim, [In] IntPtr[] global_work_offset, [In] IntPtr[] global_work_size, [In] IntPtr[] local_work_size, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueReadBuffer(OpenCLCommandQueue command_queue, OpenCLMem buffer, Boolean blocking_read, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)
        {
            Marshal.WriteInt32(ptr, 0, 1);
            Marshal.WriteInt32(ptr, 1, 2);
            Marshal.WriteInt32(ptr, 2, 3);

            e = default(OpenCLEvent);
            Console.WriteLine("Calling Error clEnqueueReadBuffer(OpenCLCommandQueue command_queue, OpenCLMem buffer, Boolean blocking_read, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueReadImage(OpenCLCommandQueue command_queue, OpenCLMem image, Boolean blocking_read, IntPtr[] origin, IntPtr[] region, IntPtr row_pitch, IntPtr slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)
        {
            e = default(OpenCLEvent);
            Console.WriteLine("Calling Error clEnqueueReadImage(OpenCLCommandQueue command_queue, OpenCLMem image, Boolean blocking_read, IntPtr[] origin, IntPtr[] region, IntPtr row_pitch, IntPtr slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueTask(OpenCLCommandQueue command_queue, OpenCLKernel kernel, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)
        {
            e = default(OpenCLEvent);
            Console.WriteLine("Calling Error clEnqueueTask(OpenCLCommandQueue command_queue, OpenCLKernel kernel, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueUnmapMemObject(OpenCLCommandQueue command_queue, OpenCLMem memobj, IntPtr mapped_ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)
        {
            e = default(OpenCLEvent);
            Console.WriteLine("Calling Error clEnqueueUnmapMemObject(OpenCLCommandQueue command_queue, OpenCLMem memobj, IntPtr mapped_ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueWaitForEvents(OpenCLCommandQueue command_queue, Int32 num_events, [In] OpenCLEvent[] event_list)
        {
            Console.WriteLine("Calling Error clEnqueueWaitForEvents(OpenCLCommandQueue command_queue, Int32 num_events, [In] OpenCLEvent[] event_list)");
            return default(Error);
        }
	    public static Error clEnqueueWriteBuffer(OpenCLCommandQueue command_queue, OpenCLMem buffer, Boolean blocking_write, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)
        {
            e = default(OpenCLEvent);
            Console.WriteLine("Calling Error clEnqueueWriteBuffer(OpenCLCommandQueue command_queue, OpenCLMem buffer, Boolean blocking_write, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueWriteImage(OpenCLCommandQueue command_queue, OpenCLMem image, Boolean blocking_write, IntPtr[] origin, IntPtr[] region, IntPtr input_row_pitch, IntPtr input_slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)
        {
            e = default(OpenCLEvent);
            Console.WriteLine("Calling Error clEnqueueWriteImage(OpenCLCommandQueue command_queue, OpenCLMem image, Boolean blocking_write, IntPtr[] origin, IntPtr[] region, IntPtr input_row_pitch, IntPtr input_slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clFinish(OpenCLCommandQueue command_queue)
        {
            Console.WriteLine("Calling Error clFinish(OpenCLCommandQueue command_queue)");
            return default(Error);
        }
	    public static Error clFlush(OpenCLCommandQueue command_queue)
        {
            Console.WriteLine("Calling Error clFlush(OpenCLCommandQueue command_queue)");
            return default(Error);
        }
	    public static Error clGetCommandQueueInfo(OpenCLCommandQueue command_queue, CommandQueueInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling Error clGetCommandQueueInfo(OpenCLCommandQueue command_queue, CommandQueueInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(Error);
        }

        public static Error clGetContextInfo(OpenCLContext context, ContextInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling Error clGetContextInfo(OpenCLContext context, ContextInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(Error);
        }
        public static Error clGetContextInfo(OpenCLContext context, ContextInfo param_name, IntPtr param_value_size, [Out] OpenCLDevice[] param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling Error clGetContextInfo(OpenCLContext context, ContextInfo param_name, IntPtr param_value_size, [Out] OpenCLDevice[] param_value, out IntPtr param_value_size_ret)");
            return default(Error);
        }
        
        public static Error clGetDeviceIDs(OpenCLPlatform platform_id, DeviceType device_type, Int32 num_entries, [Out] OpenCLDevice[] devices, out Int32 num_devices)
        {
            num_devices = 1;
            devices = new OpenCLDevice[num_devices];
            Console.WriteLine("Calling Error clGetDeviceIDs(OpenCLPlatform platform_id, DeviceType device_type, Int32 num_entries, [Out] OpenCLDevice[] devices, out Int32 num_devices)");
            return default(Error);
        }
	    public static Error clGetDeviceIDs(OpenCLPlatform platform_id, DeviceType device_type, Int32 num_entries, IntPtr devices, out Int32 num_devices)
        {
            num_devices = default(Int32);
            Console.WriteLine("Calling Error clGetDeviceIDs(OpenCLPlatform platform_id, DeviceType device_type, Int32 num_entries, IntPtr devices, out Int32 num_devices)");
            return default(Error);
        }
	    
	    public static Error clGetDeviceInfo(OpenCLDevice device, DeviceInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling Error clGetDeviceInfo(OpenCLDevice device, DeviceInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(Error);
        }
        public static Error clGetDeviceInfo(OpenCLDevice device, DeviceInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling Error clGetDeviceInfo(OpenCLDevice device, DeviceInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, out IntPtr param_value_size_ret)");
            return default(Error);
        }
	    
        public static Error clGetEventInfo(OpenCLEvent e, EventInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling Error clGetEventInfo(OpenCLEvent e, EventInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetEventProfilingInfo(OpenCLEvent e, ProfilingInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling Error clGetEventProfilingInfo(OpenCLEvent e, ProfilingInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, out IntPtr param_value_size_ret)");
            return default(Error);
        }
	    
		public static IntPtr clGetExtensionFunctionAddress(String func_name)
        {
            Console.WriteLine("Calling IntPtr clGetExtensionFunctionAddress(String func_name)");
            return default(IntPtr);
        }
	    public static Error clGetImageInfo(OpenCLMem image, ImageInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling Error clGetImageInfo(OpenCLMem image, ImageInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetKernelInfo(OpenCLKernel kernel, KernelInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            if (param_name == KernelInfo.NumArgs)
            {
                Marshal.WriteIntPtr(param_value, new IntPtr(3));

                param_value_size_ret = new IntPtr(IntPtr.Size);
            }
            else if (param_name == KernelInfo.FunctionName)
            {
                String name = "VectorAdd";

                for (int i = 0; i < name.Length; i++)
                {
                    Marshal.WriteByte(param_value, i, (byte)name[i]);
                }

                param_value_size_ret = new IntPtr(name.Length);
            }
            else
            {
                param_value_size_ret = default(IntPtr);
            }

            Console.WriteLine("Calling Error clGetKernelInfo(OpenCLKernel kernel, KernelInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetKernelWorkGroupInfo(OpenCLKernel kernel, OpenCLDevice device, KernelWorkGroupInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling Error clGetKernelWorkGroupInfo(OpenCLKernel kernel, OpenCLDevice device, KernelWorkGroupInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetMemObjectInfo(OpenCLMem memobj, MemInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling Error clGetMemObjectInfo(OpenCLMem memobj, MemInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetPlatformIDs(Int32 num_entries, IntPtr platforms, out Int32 num_platforms)
        {
            num_platforms = default(Int32);
            Console.WriteLine("Calling Error clGetPlatformIDs(Int32 num_entries, IntPtr platforms, out Int32 num_platforms)");
            return default(Error);
        }
	    public static Error clGetPlatformIDs(Int32 num_entries, [Out] OpenCLPlatform[] platforms, out Int32 num_platforms)
        {
            num_platforms = 1;
            platforms = new OpenCLPlatform[num_platforms];
            Console.WriteLine("Calling Error clGetPlatformIDs(Int32 num_entries, [Out] OpenCLPlatform[] platforms, out Int32 num_platforms)");
            return default(Error);
        }
	    public static Error clGetPlatformInfo(OpenCLPlatform platform, PlatformInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling Error clGetPlatformInfo(OpenCLPlatform platform, PlatformInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetPlatformInfo(OpenCLPlatform platform, PlatformInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling Error clGetPlatformInfo(OpenCLPlatform platform, PlatformInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, out IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetProgramBuildInfo(OpenCLProgram program, OpenCLDevice device, ProgramBuildInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling Error clGetProgramBuildInfo(OpenCLProgram program, OpenCLDevice device, ProgramBuildInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetProgramInfo(OpenCLProgram program, ProgramInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling Error clGetProgramInfo(OpenCLProgram program, ProgramInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetSamplerInfo(OpenCLSampler sampler, SamplerInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling Error clGetSamplerInfo(OpenCLSampler sampler, SamplerInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetSupportedImageFormats(OpenCLContext context, MemFlags flags, MemObjectType image_type, Int32 num_entries, IntPtr image_formats, out Int32 num_image_formats)
        {
            num_image_formats = default(Int32);
            Console.WriteLine("Calling Error clGetSupportedImageFormats(OpenCLContext context, MemFlags flags, MemObjectType image_type, Int32 num_entries, IntPtr image_formats, out Int32 num_image_formats)");
            return default(Error);
        }
	    public static Error clGetSupportedImageFormats(OpenCLContext context, MemFlags flags, MemObjectType image_type, Int32 num_entries, [Out] ImageFormat[] image_formats, out Int32 num_image_formats)
        {
            num_image_formats = default(Int32);
            Console.WriteLine("Calling Error clGetSupportedImageFormats(OpenCLContext context, MemFlags flags, MemObjectType image_type, Int32 num_entries, [Out] ImageFormat[] image_formats, out Int32 num_image_formats)");
            return default(Error);
        }
	    public static Error clReleaseCommandQueue(OpenCLCommandQueue command_queue)
        {
            Console.WriteLine("Calling Error clReleaseCommandQueue(OpenCLCommandQueue command_queue)");
            return default(Error);
        }
	    public static Error clReleaseContext(OpenCLContext context)
        {
            Console.WriteLine("Calling Error clReleaseContext(OpenCLContext context)");
            return default(Error);
        }
	    public static Error clReleaseEvent(OpenCLEvent e)
        {
            Console.WriteLine("Calling Error clReleaseEvent(OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clReleaseKernel(OpenCLKernel kernel)
        {
            Console.WriteLine("Calling Error clReleaseKernel(OpenCLKernel kernel)");
            return default(Error);
        }
	    public static Error clReleaseMemObject(OpenCLMem memobj)
        {
            Console.WriteLine("Calling Error clReleaseMemObject(OpenCLMem memobj)");
            return default(Error);
        }
	    public static Error clReleaseProgram(OpenCLProgram program)
        {
            Console.WriteLine("Calling Error clReleaseProgram(OpenCLProgram program)");
            return default(Error);
        }
	    public static Error clReleaseSampler(OpenCLSampler sampler)
        {
            Console.WriteLine("Calling Error clReleaseSampler(OpenCLSampler sampler)");
            return default(Error);
        }
	    public static Error clRetainCommandQueue(OpenCLCommandQueue command_queue)
        {
            Console.WriteLine("Calling Error clRetainCommandQueue(OpenCLCommandQueue command_queue)");
            return default(Error);
        }
	    public static Error clRetainContext(OpenCLContext context)
        {
            Console.WriteLine("Calling Error clRetainContext(OpenCLContext context)");
            return default(Error);
        }
	    public static Error clRetainEvent(OpenCLEvent e)
        {
            Console.WriteLine("Calling Error clRetainEvent(OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clRetainKernel(OpenCLKernel kernel)
        {
            Console.WriteLine("Calling Error clRetainKernel(OpenCLKernel kernel)");
            return default(Error);
        }
	    public static Error clRetainMemObject(OpenCLMem memobj)
        {
            Console.WriteLine("Calling Error clRetainMemObject(OpenCLMem memobj)");
            return default(Error);
        }
	    public static Error clRetainProgram(OpenCLProgram program)
        {
            Console.WriteLine("Calling Error clRetainProgram(OpenCLProgram program)");
            return default(Error);
        }
	    public static Error clRetainSampler(OpenCLSampler sampler)
        {
            Console.WriteLine("Calling Error clRetainSampler(OpenCLSampler sampler)");
            return default(Error);
        }
	    public static Error clSetCommandQueueProperty(OpenCLCommandQueue command_queue, CommandQueueProperties properties, Boolean enable, out CommandQueueProperties old_properties)
        {
            old_properties = default(CommandQueueProperties);

            Console.WriteLine("Calling Error clSetCommandQueueProperty(OpenCLCommandQueue command_queue, CommandQueueProperties properties, Boolean enable, out CommandQueueProperties old_properties)");

            return default(Error);
        }

        public static Error clSetKernelArg(OpenCLKernel kernel, Int32 arg_index, IntPtr arg_size, IntPtr arg_value)
        {
            Console.WriteLine("Calling Error clSetKernelArg(OpenCLKernel kernel, Int32 arg_index, IntPtr arg_size, IntPtr arg_value)");
            return default(Error);
        }
        public static Error clSetKernelArg(OpenCLKernel kernel, Int32 arg_index, IntPtr arg_size, ref OpenCLMem arg_value)
        {
            Console.WriteLine("Calling Error clSetKernelArg(OpenCLKernel kernel, Int32 arg_index, IntPtr arg_size, ref OpenCLMem arg_value)");
            return default(Error);
        }
	    
		public static Error clUnloadCompiler()
        {
            Console.WriteLine("Calling Error clUnloadCompiler()");
            return default(Error);
        }
	    public static Error clWaitForEvents(Int32 num_events, [In] OpenCLEvent[] event_list)
        {
            Console.WriteLine("Calling Error clWaitForEvents(Int32 num_events, [In] OpenCLEvent[] event_list)");
            return default(Error);
        }
	    public static Error clWaitForEvents(Int32 num_events, ref OpenCLEvent e)
        {
            Console.WriteLine("Calling Error clWaitForEvents(Int32 num_events, ref OpenCLEvent e)");
            return default(Error);
        }

	    public static OpenCLMem clCreateBuffer(OpenCLContext context, MemFlags flags, IntPtr size, IntPtr host_ptr, Error error)
        {
            Console.WriteLine("Calling OpenCLMem clCreateBuffer(OpenCLContext context, MemFlags flags, IntPtr size, IntPtr host_ptr, Error error)");
            return default(OpenCLMem);
        }
	    public static OpenCLCommandQueue clCreateCommandQueue(OpenCLContext context, OpenCLDevice device, CommandQueueProperties properties, Error error)
        {
            Console.WriteLine("Calling OpenCLCommandQueue clCreateCommandQueue(OpenCLContext context, OpenCLDevice device, CommandQueueProperties properties, Error error)");
            return default(OpenCLCommandQueue);
        }
		public static OpenCLContext clCreateContext(IntPtr properties, Int32 num_devices, [In] OpenCLDevice[] devices, LoggingFunction pfn_notify, IntPtr user_data, Error error)
        {
            Console.WriteLine("Calling OpenCLContext clCreateContext(IntPtr properties, Int32 num_devices, [In] OpenCLDevice[] devices, LoggingFunction pfn_notify, IntPtr user_data, Error error)");
            return default(OpenCLContext);
        }
	    public static OpenCLContext clCreateContextFromType(IntPtr properties, DeviceType device_type, LoggingFunction pfn_notify, IntPtr user_data, Error error)
        {
            Console.WriteLine("Calling OpenCLContext clCreateContextFromType(IntPtr properties, DeviceType device_type, LoggingFunction pfn_notify, IntPtr user_data, Error error)");
            return default(OpenCLContext);
        }
	    public static OpenCLMem clCreateImage2D(OpenCLContext context, MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, IntPtr host_ptr, Error error)
        {
            Console.WriteLine("Calling OpenCLMem clCreateImage2D(OpenCLContext context, MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, IntPtr host_ptr, Error error)");
            return default(OpenCLMem);
        }
	    public static OpenCLMem clCreateImage3D(OpenCLContext context, MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, IntPtr host_ptr, Error error)
        {
            Console.WriteLine("Calling OpenCLMem clCreateImage3D(OpenCLContext context, MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, IntPtr host_ptr, Error error)");
            return default(OpenCLMem);
        }
	    public static OpenCLKernel clCreateKernel(OpenCLProgram program, String kernel_name, Error error)
        {
            Console.WriteLine("Calling OpenCLKernel clCreateKernel(OpenCLProgram program, String kernel_name, Error error)");
            return default(OpenCLKernel);
        }
	    public static Error clCreateKernelsInProgram(OpenCLProgram program, Int32 num_kernels, [Out] OpenCLKernel[] kernels, Int32 num_kernels_ret)
        {
            Console.WriteLine("Calling Error clCreateKernelsInProgram(OpenCLProgram program, Int32 num_kernels, [Out] OpenCLKernel[] kernels, Int32 num_kernels_ret)");
            return default(Error);
        }
	    public static OpenCLProgram clCreateProgramWithBinary(OpenCLContext context, Int32 num_devices, [In] OpenCLDevice[] device_list, [In] IntPtr[] lengths, [In] IntPtr[] binaries, [In] Int32[] binary_status, Error error)
        {
            Console.WriteLine("Calling OpenCLProgram clCreateProgramWithBinary(OpenCLContext context, Int32 num_devices, [In] OpenCLDevice[] device_list, [In] IntPtr[] lengths, [In] IntPtr[] binaries, [In] Int32[] binary_status, Error error)");
            return default(OpenCLProgram);
        }
	    public static OpenCLProgram clCreateProgramWithSource(OpenCLContext context, Int32 count, [In] String[] Strings, [In] IntPtr[] lengths, Error error)
        {
            Console.WriteLine("Calling OpenCLProgram clCreateProgramWithSource(OpenCLContext context, Int32 count, [In] String[] Strings, [In] IntPtr[] lengths, Error error)");
            return default(OpenCLProgram);
        }
	    public static OpenCLProgram clCreateProgramWithSource(OpenCLContext context, Int32 count, IntPtr Strings, [In] IntPtr[] lengths, Error error)
        {
            Console.WriteLine("Calling OpenCLProgram clCreateProgramWithSource(OpenCLContext context, Int32 count, IntPtr Strings, [In] IntPtr[] lengths, Error error)");
            return default(OpenCLProgram);
        }
	    public static OpenCLProgram clCreateProgramWithSource(OpenCLContext context, Int32 count, String Strings, [In] IntPtr[] lengths, Error error)
        {
            Console.WriteLine("Calling OpenCLProgram clCreateProgramWithSource(OpenCLContext context, Int32 count, String Strings, [In] IntPtr[] lengths, Error error)");
            return default(OpenCLProgram);
        }
	    public static OpenCLSampler clCreateSampler(OpenCLContext context, Boolean normalized_coords, AddressingMode addressing_mode, FilterMode filter_mode, Error error)
        {
            Console.WriteLine("Calling OpenCLSampler clCreateSampler(OpenCLContext context, Boolean normalized_coords, AddressingMode addressing_mode, FilterMode filter_mode, Error error)");
            return default(OpenCLSampler);
        }
	    public static Error clEnqueueCopyBuffer(OpenCLCommandQueue command_queue, OpenCLMem src_buffer, OpenCLMem dst_buffer, IntPtr src_offset, IntPtr dst_offset, IntPtr cb, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)
        {
            Console.WriteLine("Calling Error clEnqueueCopyBuffer(OpenCLCommandQueue command_queue, OpenCLMem src_buffer, OpenCLMem dst_buffer, IntPtr src_offset, IntPtr dst_offset, IntPtr cb, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueCopyBufferToImage(OpenCLCommandQueue command_queue, OpenCLMem src_buffer, OpenCLMem dst_image, IntPtr src_offset, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)
        {
            Console.WriteLine("Calling Error clEnqueueCopyBufferToImage(OpenCLCommandQueue command_queue, OpenCLMem src_buffer, OpenCLMem dst_image, IntPtr src_offset, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueCopyImage(OpenCLCommandQueue command_queue, OpenCLMem src_image, OpenCLMem dst_image, IntPtr[] src_origin, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)
        {
            Console.WriteLine("Calling Error clEnqueueCopyImage(OpenCLCommandQueue command_queue, OpenCLMem src_image, OpenCLMem dst_image, IntPtr[] src_origin, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueCopyImageToBuffer(OpenCLCommandQueue command_queue, OpenCLMem src_image, OpenCLMem dst_buffer, IntPtr[] src_origin, IntPtr[] region, IntPtr dst_offset, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)
        {
            Console.WriteLine("Calling Error clEnqueueCopyImageToBuffer(OpenCLCommandQueue command_queue, OpenCLMem src_image, OpenCLMem dst_buffer, IntPtr[] src_origin, IntPtr[] region, IntPtr dst_offset, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)");
            return default(Error);
        }
	    public static IntPtr clEnqueueMapBuffer(OpenCLCommandQueue command_queue, OpenCLMem buffer, Boolean blocking_map, Map map_flags, IntPtr offset, IntPtr cb, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e, Error error)
        {
            Console.WriteLine("Calling IntPtr clEnqueueMapBuffer(OpenCLCommandQueue command_queue, OpenCLMem buffer, Boolean blocking_map, Map map_flags, IntPtr offset, IntPtr cb, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e, Error error)");
            return default(IntPtr);
        }
	    public static IntPtr clEnqueueMapImage(OpenCLCommandQueue command_queue, OpenCLMem image, Boolean blocking_map, Map map_flags, IntPtr[] origin, IntPtr[] region, IntPtr image_row_pitch, IntPtr image_slice_pitch, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e, Error error)
        {
            Console.WriteLine("Calling IntPtr clEnqueueMapImage(OpenCLCommandQueue command_queue, OpenCLMem image, Boolean blocking_map, Map map_flags, IntPtr[] origin, IntPtr[] region, IntPtr image_row_pitch, IntPtr image_slice_pitch, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e, Error error)");
            return default(IntPtr);
        }
	    public static Error clEnqueueMarker(OpenCLCommandQueue command_queue, OpenCLEvent e)
        {
            Console.WriteLine("Calling Error clEnqueueMarker(OpenCLCommandQueue command_queue, OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueNativeKernel(OpenCLCommandQueue command_queue, UserFunction user_func, [In] IntPtr[] args, IntPtr cb_args, Int32 num_mem_objects, [In] OpenCLMem[] mem_list, [In] IntPtr[] args_mem_loc, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)
        {
            Console.WriteLine("Calling Error clEnqueueNativeKernel(OpenCLCommandQueue command_queue, UserFunction user_func, [In] IntPtr[] args, IntPtr cb_args, Int32 num_mem_objects, [In] OpenCLMem[] mem_list, [In] IntPtr[] args_mem_loc, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueNDRangeKernel(OpenCLCommandQueue command_queue, OpenCLKernel kernel, Int32 work_dim, [In] IntPtr[] global_work_offset, [In] IntPtr[] global_work_size, [In] IntPtr[] local_work_size, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)
        {
            Console.WriteLine("Calling Error clEnqueueNDRangeKernel(OpenCLCommandQueue command_queue, OpenCLKernel kernel, Int32 work_dim, [In] IntPtr[] global_work_offset, [In] IntPtr[] global_work_size, [In] IntPtr[] local_work_size, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueReadBuffer(OpenCLCommandQueue command_queue, OpenCLMem buffer, Boolean blocking_read, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)
        {
            Console.WriteLine("Calling Error clEnqueueReadBuffer(OpenCLCommandQueue command_queue, OpenCLMem buffer, Boolean blocking_read, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueReadImage(OpenCLCommandQueue command_queue, OpenCLMem image, Boolean blocking_read, IntPtr[] origin, IntPtr[] region, IntPtr row_pitch, IntPtr slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)
        {
            Console.WriteLine("Calling Error clEnqueueReadImage(OpenCLCommandQueue command_queue, OpenCLMem image, Boolean blocking_read, IntPtr[] origin, IntPtr[] region, IntPtr row_pitch, IntPtr slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueTask(OpenCLCommandQueue command_queue, OpenCLKernel kernel, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)
        {
            Console.WriteLine("Calling Error clEnqueueTask(OpenCLCommandQueue command_queue, OpenCLKernel kernel, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueUnmapMemObject(OpenCLCommandQueue command_queue, OpenCLMem memobj, IntPtr mapped_ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)
        {
            Console.WriteLine("Calling Error clEnqueueUnmapMemObject(OpenCLCommandQueue command_queue, OpenCLMem memobj, IntPtr mapped_ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueWriteBuffer(OpenCLCommandQueue command_queue, OpenCLMem buffer, Boolean blocking_write, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)
        {
            Console.WriteLine("Calling Error clEnqueueWriteBuffer(OpenCLCommandQueue command_queue, OpenCLMem buffer, Boolean blocking_write, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)");
            return default(Error);
        }
	    public static Error clEnqueueWriteImage(OpenCLCommandQueue command_queue, OpenCLMem image, Boolean blocking_write, IntPtr[] origin, IntPtr[] region, IntPtr input_row_pitch, IntPtr input_slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)
        {
            Console.WriteLine("Calling Error clEnqueueWriteImage(OpenCLCommandQueue command_queue, OpenCLMem image, Boolean blocking_write, IntPtr[] origin, IntPtr[] region, IntPtr input_row_pitch, IntPtr input_slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e)");
            return default(Error);
        }
        public static Error clGetCommandQueueInfo(OpenCLCommandQueue command_queue, CommandQueueInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling Error clGetCommandQueueInfo(OpenCLCommandQueue command_queue, CommandQueueInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(Error);
        }
        public static Error clGetCommandQueueInfo(OpenCLCommandQueue command_queue, CommandQueueInfo param_name, IntPtr param_value_size, [Out] OpenCLDevice[] param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling Error clGetCommandQueueInfo(OpenCLCommandQueue command_queue, CommandQueueInfo param_name, IntPtr param_value_size, [Out] OpenCLDevice[] param_value, IntPtr param_value_size_ret)");
            return default(Error);
        }

        public static Error clGetContextInfo(OpenCLContext context, ContextInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling Error clGetContextInfo(OpenCLContext context, ContextInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(Error);
        }
        public static Error clGetContextInfo(OpenCLContext context, ContextInfo param_name, IntPtr param_value_size, [Out] OpenCLDevice[] param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling Error clGetContextInfo(OpenCLContext context, ContextInfo param_name, IntPtr param_value_size, [Out] OpenCLDevice[] param_value, IntPtr param_value_size_ret)");
            return default(Error);
        }

        public static Error clGetDeviceIDs(OpenCLPlatform platform_id, DeviceType device_type, Int32 num_entries, [Out] OpenCLDevice[] devices, Int32 num_devices)
        {
            Console.WriteLine("Calling Error clGetDeviceIDs(OpenCLPlatform platform_id, DeviceType device_type, Int32 num_entries, [Out] OpenCLDevice[] devices, Int32 num_devices)");
            return default(Error);
        }
	    public static Error clGetDeviceIDs(OpenCLPlatform platform_id, DeviceType device_type, Int32 num_entries, IntPtr devices, Int32 num_devices)
        {
            Console.WriteLine("Calling Error clGetDeviceIDs(OpenCLPlatform platform_id, DeviceType device_type, Int32 num_entries, IntPtr devices, Int32 num_devices)");
            return default(Error);
        }
	    public static Error clGetDeviceInfo(OpenCLDevice device, DeviceInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling Error clGetDeviceInfo(OpenCLDevice device, DeviceInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetDeviceInfo(OpenCLDevice device, DeviceInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling Error clGetDeviceInfo(OpenCLDevice device, DeviceInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetEventInfo(OpenCLEvent e, EventInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling Error clGetEventInfo(OpenCLEvent e, EventInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(Error);
        }
		public static Error clGetImageInfo(OpenCLMem image, ImageInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling Error clGetImageInfo(OpenCLMem image, ImageInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetKernelInfo(OpenCLKernel kernel, KernelInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling Error clGetKernelInfo(OpenCLKernel kernel, KernelInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetKernelWorkGroupInfo(OpenCLKernel kernel, OpenCLDevice device, KernelWorkGroupInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling Error clGetKernelWorkGroupInfo(OpenCLKernel kernel, OpenCLDevice device, KernelWorkGroupInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetMemObjectInfo(OpenCLMem memobj, MemInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling Error clGetMemObjectInfo(OpenCLMem memobj, MemInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetPlatformIDs(Int32 num_entries, IntPtr platforms, Int32 num_platforms)
        {
            Console.WriteLine("Calling Error clGetPlatformIDs(Int32 num_entries, IntPtr platforms, Int32 num_platforms)");
            return default(Error);
        }
	    public static Error clGetPlatformIDs(Int32 num_entries, [Out] OpenCLPlatform[] platforms, Int32 num_platforms)
        {
            Console.WriteLine("Calling Error clGetPlatformIDs(Int32 num_entries, [Out] OpenCLPlatform[] platforms, Int32 num_platforms)");
            return default(Error);
        }
	    public static Error clGetPlatformInfo(OpenCLPlatform platform, PlatformInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling Error clGetPlatformInfo(OpenCLPlatform platform, PlatformInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetPlatformInfo(OpenCLPlatform platform, PlatformInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling Error clGetPlatformInfo(OpenCLPlatform platform, PlatformInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetProgramBuildInfo(OpenCLProgram program, OpenCLDevice device, ProgramBuildInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling Error clGetProgramBuildInfo(OpenCLProgram program, OpenCLDevice device, ProgramBuildInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetProgramInfo(OpenCLProgram program, ProgramInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling Error clGetProgramInfo(OpenCLProgram program, ProgramInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetSamplerInfo(OpenCLSampler sampler, SamplerInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling Error clGetSamplerInfo(OpenCLSampler sampler, SamplerInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(Error);
        }
	    public static Error clGetSupportedImageFormats(OpenCLContext context, MemFlags flags, MemObjectType image_type, Int32 num_entries, IntPtr image_formats, Int32 num_image_formats)
        {
            Console.WriteLine("Calling Error clGetSupportedImageFormats(OpenCLContext context, MemFlags flags, MemObjectType image_type, Int32 num_entries, IntPtr image_formats, Int32 num_image_formats)");
            return default(Error);
        }
	    public static Error clGetSupportedImageFormats(OpenCLContext context, MemFlags flags, MemObjectType image_type, Int32 num_entries, [Out] ImageFormat[] image_formats, Int32 num_image_formats)
        {
            Console.WriteLine("Calling Error clGetSupportedImageFormats(OpenCLContext context, MemFlags flags, MemObjectType image_type, Int32 num_entries, [Out] ImageFormat[] image_formats, Int32 num_image_formats)");
            return default(Error);
        }
	    public static Error clSetCommandQueueProperty(OpenCLCommandQueue command_queue, CommandQueueProperties properties, Boolean enable, CommandQueueProperties old_properties)
        {
            Console.WriteLine("Calling Error clSetCommandQueueProperty(OpenCLCommandQueue command_queue, CommandQueueProperties properties, Boolean enable, CommandQueueProperties old_properties)");
            return default(Error);
        }
#else
	    [DllImport("OpenCL")] public static extern Error clBuildProgram(OpenCLProgram program, Int32 num_devices, [In] OpenCLDevice[] device_list, IntPtr options, NotifyFunction func, IntPtr user_data);
	    [DllImport("OpenCL")] public static extern Error clBuildProgram(OpenCLProgram program, Int32 num_devices, [In] OpenCLDevice[] device_list, String options, NotifyFunction func, IntPtr user_data);
	    
		[DllImport("OpenCL")] public static extern OpenCLMem clCreateBuffer(OpenCLContext context, MemFlags flags, IntPtr size, [In] Byte[] bytes, out Error error);
	    [DllImport("OpenCL")] public static extern OpenCLMem clCreateBuffer(OpenCLContext context, MemFlags flags, IntPtr size, IntPtr host_ptr, out Error error);

		[DllImport("OpenCL")] public static extern OpenCLCommandQueue clCreateCommandQueue(OpenCLContext context, OpenCLDevice device, CommandQueueProperties properties, out Error error);
		[DllImport("OpenCL")] public static extern OpenCLContext clCreateContext(IntPtr properties, Int32 num_devices, [In] OpenCLDevice[] devices, LoggingFunction pfn_notify, IntPtr user_data, out Error error);
	    [DllImport("OpenCL")] public static extern OpenCLContext clCreateContextFromType(IntPtr properties, DeviceType device_type, LoggingFunction pfn_notify, IntPtr user_data, out Error error);
	    [DllImport("OpenCL")] public static extern OpenCLMem clCreateImage2D(OpenCLContext context, MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, IntPtr host_ptr, out Error error);
	    [DllImport("OpenCL")] public static extern OpenCLMem clCreateImage3D(OpenCLContext context, MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, IntPtr host_ptr, out Error error);
	    [DllImport("OpenCL")] public static extern OpenCLKernel clCreateKernel(OpenCLProgram program, String kernel_name, out Error error);
	    [DllImport("OpenCL")] public static extern Error clCreateKernelsInProgram(OpenCLProgram program, Int32 num_kernels, [Out] OpenCLKernel[] kernels, out Int32 num_kernels_ret);

		// This line causes Mono to crash
		// [DllImport("OpenCL")] public static extern OpenCLProgram clCreateProgramWithSource<T>(OpenCLContext context, Int32 count, [In] T[] sources, [In] IntPtr[] lengths, out Error error);

		[DllImport("OpenCL")] public static extern OpenCLProgram clCreateProgramWithBinary(OpenCLContext context, Int32 num_devices, [In] OpenCLDevice[] device_list, [In] IntPtr[] lengths, [In] IntPtr[] binaries, [In] Int32[] binary_status, out Error error);
        [DllImport("OpenCL")] public static extern OpenCLProgram clCreateProgramWithSource(OpenCLContext context, Int32 count, IntPtr Strings, [In] IntPtr[] lengths, out Error error);
        [DllImport("OpenCL")] public static extern OpenCLProgram clCreateProgramWithSource(OpenCLContext context, Int32 count, [In] String[] sources, [In] IntPtr[] lengths, out Error error);
        [DllImport("OpenCL")] public static extern OpenCLProgram clCreateProgramWithSource(OpenCLContext context, Int32 count, [In] Byte[][] sources, [In] IntPtr[] lengths, out Error error);
        [DllImport("OpenCL")] public static extern OpenCLSampler clCreateSampler(OpenCLContext context, Boolean normalized_coords, AddressingMode addressing_mode, FilterMode filter_mode, out Error error);
	    [DllImport("OpenCL")] public static extern Error clEnqueueBarrier(OpenCLCommandQueue command_queue);
	    [DllImport("OpenCL")] public static extern Error clEnqueueCopyBuffer(OpenCLCommandQueue command_queue, OpenCLMem src_buffer, OpenCLMem dst_buffer, IntPtr src_offset, IntPtr dst_offset, IntPtr cb, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueCopyBufferToImage(OpenCLCommandQueue command_queue, OpenCLMem src_buffer, OpenCLMem dst_image, IntPtr src_offset, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueCopyImage(OpenCLCommandQueue command_queue, OpenCLMem src_image, OpenCLMem dst_image, IntPtr[] src_origin, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueCopyImageToBuffer(OpenCLCommandQueue command_queue, OpenCLMem src_image, OpenCLMem dst_buffer, IntPtr[] src_origin, IntPtr[] region, IntPtr dst_offset, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern IntPtr clEnqueueMapBuffer(OpenCLCommandQueue command_queue, OpenCLMem buffer, Boolean blocking_map, Map map_flags, IntPtr offset, IntPtr cb, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e, out Error error);
	    [DllImport("OpenCL")] public static extern IntPtr clEnqueueMapImage(OpenCLCommandQueue command_queue, OpenCLMem image, Boolean blocking_map, Map map_flags, IntPtr[] origin, IntPtr[] region, out IntPtr image_row_pitch, out IntPtr image_slice_pitch, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e, out Error error);
	    [DllImport("OpenCL")] public static extern Error clEnqueueMarker(OpenCLCommandQueue command_queue, out OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueNativeKernel(OpenCLCommandQueue command_queue, UserFunction user_func, [In] IntPtr[] args, IntPtr cb_args, Int32 num_mem_objects, [In] OpenCLMem[] mem_list, [In] IntPtr[] args_mem_loc, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueNDRangeKernel(OpenCLCommandQueue command_queue, OpenCLKernel kernel, Int32 work_dim, [In] IntPtr[] global_work_offset, [In] IntPtr[] global_work_size, [In] IntPtr[] local_work_size, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueReadBuffer(OpenCLCommandQueue command_queue, OpenCLMem buffer, Boolean blocking_read, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueReadImage(OpenCLCommandQueue command_queue, OpenCLMem image, Boolean blocking_read, IntPtr[] origin, IntPtr[] region, IntPtr row_pitch, IntPtr slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueTask(OpenCLCommandQueue command_queue, OpenCLKernel kernel, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueUnmapMemObject(OpenCLCommandQueue command_queue, OpenCLMem memobj, IntPtr mapped_ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueWaitForEvents(OpenCLCommandQueue command_queue, Int32 num_events, [In] OpenCLEvent[] event_list);
	    [DllImport("OpenCL")] public static extern Error clEnqueueWriteBuffer(OpenCLCommandQueue command_queue, OpenCLMem buffer, Boolean blocking_write, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueWriteImage(OpenCLCommandQueue command_queue, OpenCLMem image, Boolean blocking_write, IntPtr[] origin, IntPtr[] region, IntPtr input_row_pitch, IntPtr input_slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, out OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clFinish(OpenCLCommandQueue command_queue);
	    [DllImport("OpenCL")] public static extern Error clFlush(OpenCLCommandQueue command_queue);
	    [DllImport("OpenCL")] public static extern Error clGetCommandQueueInfo(OpenCLCommandQueue command_queue, CommandQueueInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);

        [DllImport("OpenCL")] public static extern Error clGetContextInfo(OpenCLContext context, ContextInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
        [DllImport("OpenCL")] public static extern Error clGetContextInfo(OpenCLContext context, ContextInfo param_name, IntPtr param_value_size, [Out] OpenCLDevice[] param_value, out IntPtr param_value_size_ret);
        
        [DllImport("OpenCL")] public static extern Error clGetDeviceIDs(OpenCLPlatform platform_id, DeviceType device_type, Int32 num_entries, [Out] OpenCLDevice[] devices, out Int32 num_devices);
	    [DllImport("OpenCL")] public static extern Error clGetDeviceIDs(OpenCLPlatform platform_id, DeviceType device_type, Int32 num_entries, IntPtr devices, out Int32 num_devices);
	    
	    [DllImport("OpenCL")] public static extern Error clGetDeviceInfo(OpenCLDevice device, DeviceInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
	    
        [DllImport("OpenCL")] public static extern Error clGetEventInfo(OpenCLEvent e, EventInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetEventProfilingInfo(OpenCLEvent e, ProfilingInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, out IntPtr param_value_size_ret);
	    
		[DllImport("OpenCL")] public static extern IntPtr clGetExtensionFunctionAddress(String func_name);
	    [DllImport("OpenCL")] public static extern Error clGetImageInfo(OpenCLMem image, ImageInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetKernelInfo(OpenCLKernel kernel, KernelInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetKernelWorkGroupInfo(OpenCLKernel kernel, OpenCLDevice device, KernelWorkGroupInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetMemObjectInfo(OpenCLMem memobj, MemInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetPlatformIDs(Int32 num_entries, IntPtr platforms, out Int32 num_platforms);
	    [DllImport("OpenCL")] public static extern Error clGetPlatformIDs(Int32 num_entries, [Out] OpenCLPlatform[] platforms, out Int32 num_platforms);
	    [DllImport("OpenCL")] public static extern Error clGetPlatformInfo(OpenCLPlatform platform, PlatformInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetPlatformInfo(OpenCLPlatform platform, PlatformInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, out IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetProgramBuildInfo(OpenCLProgram program, OpenCLDevice device, ProgramBuildInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetProgramInfo(OpenCLProgram program, ProgramInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetSamplerInfo(OpenCLSampler sampler, SamplerInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetSupportedImageFormats(OpenCLContext context, MemFlags flags, MemObjectType image_type, Int32 num_entries, IntPtr image_formats, out Int32 num_image_formats);
	    [DllImport("OpenCL")] public static extern Error clGetSupportedImageFormats(OpenCLContext context, MemFlags flags, MemObjectType image_type, Int32 num_entries, [Out] ImageFormat[] image_formats, out Int32 num_image_formats);
	    [DllImport("OpenCL")] public static extern Error clReleaseCommandQueue(OpenCLCommandQueue command_queue);
	    [DllImport("OpenCL")] public static extern Error clReleaseContext(OpenCLContext context);
	    [DllImport("OpenCL")] public static extern Error clReleaseEvent(OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clReleaseKernel(OpenCLKernel kernel);
	    [DllImport("OpenCL")] public static extern Error clReleaseMemObject(OpenCLMem memobj);
	    [DllImport("OpenCL")] public static extern Error clReleaseProgram(OpenCLProgram program);
	    [DllImport("OpenCL")] public static extern Error clReleaseSampler(OpenCLSampler sampler);
	    [DllImport("OpenCL")] public static extern Error clRetainCommandQueue(OpenCLCommandQueue command_queue);
	    [DllImport("OpenCL")] public static extern Error clRetainContext(OpenCLContext context);
	    [DllImport("OpenCL")] public static extern Error clRetainEvent(OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clRetainKernel(OpenCLKernel kernel);
	    [DllImport("OpenCL")] public static extern Error clRetainMemObject(OpenCLMem memobj);
	    [DllImport("OpenCL")] public static extern Error clRetainProgram(OpenCLProgram program);
	    [DllImport("OpenCL")] public static extern Error clRetainSampler(OpenCLSampler sampler);
	    [DllImport("OpenCL")] public static extern Error clSetCommandQueueProperty(OpenCLCommandQueue command_queue, CommandQueueProperties properties, Boolean enable, out CommandQueueProperties old_properties);

        [DllImport("OpenCL")] public static extern Error clSetKernelArg(OpenCLKernel kernel, Int32 arg_index, IntPtr arg_size, IntPtr arg_value);
        [DllImport("OpenCL")] public static extern Error clSetKernelArg(OpenCLKernel kernel, Int32 arg_index, IntPtr arg_size, ref OpenCLMem arg_value);
	    
		[DllImport("OpenCL")] public static extern Error clUnloadCompiler();
	    [DllImport("OpenCL")] public static extern Error clWaitForEvents(Int32 num_events, [In] OpenCLEvent[] event_list);
	    [DllImport("OpenCL")] public static extern Error clWaitForEvents(Int32 num_events, ref OpenCLEvent e);

	    [DllImport("OpenCL")] public static extern OpenCLMem clCreateBuffer(OpenCLContext context, MemFlags flags, IntPtr size, IntPtr host_ptr, Error error);
	    [DllImport("OpenCL")] public static extern OpenCLCommandQueue clCreateCommandQueue(OpenCLContext context, OpenCLDevice device, CommandQueueProperties properties, Error error);
		[DllImport("OpenCL")] public static extern OpenCLContext clCreateContext(IntPtr properties, Int32 num_devices, [In] OpenCLDevice[] devices, LoggingFunction pfn_notify, IntPtr user_data, Error error);
	    [DllImport("OpenCL")] public static extern OpenCLContext clCreateContextFromType(IntPtr properties, DeviceType device_type, LoggingFunction pfn_notify, IntPtr user_data, Error error);
	    [DllImport("OpenCL")] public static extern OpenCLMem clCreateImage2D(OpenCLContext context, MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, IntPtr host_ptr, Error error);
	    [DllImport("OpenCL")] public static extern OpenCLMem clCreateImage3D(OpenCLContext context, MemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, IntPtr host_ptr, Error error);
	    [DllImport("OpenCL")] public static extern OpenCLKernel clCreateKernel(OpenCLProgram program, String kernel_name, Error error);
	    [DllImport("OpenCL")] public static extern Error clCreateKernelsInProgram(OpenCLProgram program, Int32 num_kernels, [Out] OpenCLKernel[] kernels, Int32 num_kernels_ret);
	    [DllImport("OpenCL")] public static extern OpenCLProgram clCreateProgramWithBinary(OpenCLContext context, Int32 num_devices, [In] OpenCLDevice[] device_list, [In] IntPtr[] lengths, [In] IntPtr[] binaries, [In] Int32[] binary_status, Error error);
	    [DllImport("OpenCL")] public static extern OpenCLProgram clCreateProgramWithSource(OpenCLContext context, Int32 count, [In] String[] Strings, [In] IntPtr[] lengths, Error error);
	    [DllImport("OpenCL")] public static extern OpenCLProgram clCreateProgramWithSource(OpenCLContext context, Int32 count, IntPtr Strings, [In] IntPtr[] lengths, Error error);
	    [DllImport("OpenCL")] public static extern OpenCLProgram clCreateProgramWithSource(OpenCLContext context, Int32 count, String Strings, [In] IntPtr[] lengths, Error error);
	    [DllImport("OpenCL")] public static extern OpenCLSampler clCreateSampler(OpenCLContext context, Boolean normalized_coords, AddressingMode addressing_mode, FilterMode filter_mode, Error error);
	    [DllImport("OpenCL")] public static extern Error clEnqueueCopyBuffer(OpenCLCommandQueue command_queue, OpenCLMem src_buffer, OpenCLMem dst_buffer, IntPtr src_offset, IntPtr dst_offset, IntPtr cb, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueCopyBufferToImage(OpenCLCommandQueue command_queue, OpenCLMem src_buffer, OpenCLMem dst_image, IntPtr src_offset, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueCopyImage(OpenCLCommandQueue command_queue, OpenCLMem src_image, OpenCLMem dst_image, IntPtr[] src_origin, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueCopyImageToBuffer(OpenCLCommandQueue command_queue, OpenCLMem src_image, OpenCLMem dst_buffer, IntPtr[] src_origin, IntPtr[] region, IntPtr dst_offset, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern IntPtr clEnqueueMapBuffer(OpenCLCommandQueue command_queue, OpenCLMem buffer, Boolean blocking_map, Map map_flags, IntPtr offset, IntPtr cb, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e, Error error);
	    [DllImport("OpenCL")] public static extern IntPtr clEnqueueMapImage(OpenCLCommandQueue command_queue, OpenCLMem image, Boolean blocking_map, Map map_flags, IntPtr[] origin, IntPtr[] region, IntPtr image_row_pitch, IntPtr image_slice_pitch, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e, Error error);
	    [DllImport("OpenCL")] public static extern Error clEnqueueMarker(OpenCLCommandQueue command_queue, OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueNativeKernel(OpenCLCommandQueue command_queue, UserFunction user_func, [In] IntPtr[] args, IntPtr cb_args, Int32 num_mem_objects, [In] OpenCLMem[] mem_list, [In] IntPtr[] args_mem_loc, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueNDRangeKernel(OpenCLCommandQueue command_queue, OpenCLKernel kernel, Int32 work_dim, [In] IntPtr[] global_work_offset, [In] IntPtr[] global_work_size, [In] IntPtr[] local_work_size, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueReadBuffer(OpenCLCommandQueue command_queue, OpenCLMem buffer, Boolean blocking_read, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueReadImage(OpenCLCommandQueue command_queue, OpenCLMem image, Boolean blocking_read, IntPtr[] origin, IntPtr[] region, IntPtr row_pitch, IntPtr slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueTask(OpenCLCommandQueue command_queue, OpenCLKernel kernel, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueUnmapMemObject(OpenCLCommandQueue command_queue, OpenCLMem memobj, IntPtr mapped_ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueWriteBuffer(OpenCLCommandQueue command_queue, OpenCLMem buffer, Boolean blocking_write, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e);
	    [DllImport("OpenCL")] public static extern Error clEnqueueWriteImage(OpenCLCommandQueue command_queue, OpenCLMem image, Boolean blocking_write, IntPtr[] origin, IntPtr[] region, IntPtr input_row_pitch, IntPtr input_slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] OpenCLEvent[] event_wait_list, OpenCLEvent e);
        [DllImport("OpenCL")] public static extern Error clGetCommandQueueInfo(OpenCLCommandQueue command_queue, CommandQueueInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
        [DllImport("OpenCL")] public static extern Error clGetCommandQueueInfo(OpenCLCommandQueue command_queue, CommandQueueInfo param_name, IntPtr param_value_size, [Out] OpenCLDevice[] param_value, IntPtr param_value_size_ret);

        [DllImport("OpenCL")] public static extern Error clGetContextInfo(OpenCLContext context, ContextInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
        [DllImport("OpenCL")] public static extern Error clGetContextInfo(OpenCLContext context, ContextInfo param_name, IntPtr param_value_size, [Out] OpenCLDevice[] param_value, IntPtr param_value_size_ret);

        [DllImport("OpenCL")] public static extern Error clGetDeviceIDs(OpenCLPlatform platform_id, DeviceType device_type, Int32 num_entries, [Out] OpenCLDevice[] devices, Int32 num_devices);
	    [DllImport("OpenCL")] public static extern Error clGetDeviceIDs(OpenCLPlatform platform_id, DeviceType device_type, Int32 num_entries, IntPtr devices, Int32 num_devices);
	    [DllImport("OpenCL")] public static extern Error clGetDeviceInfo(OpenCLDevice device, DeviceInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetDeviceInfo(OpenCLDevice device, DeviceInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetEventInfo(OpenCLEvent e, EventInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
		[DllImport("OpenCL")] public static extern Error clGetImageInfo(OpenCLMem image, ImageInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetKernelInfo(OpenCLKernel kernel, KernelInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetKernelWorkGroupInfo(OpenCLKernel kernel, OpenCLDevice device, KernelWorkGroupInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetMemObjectInfo(OpenCLMem memobj, MemInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetPlatformIDs(Int32 num_entries, IntPtr platforms, Int32 num_platforms);
	    [DllImport("OpenCL")] public static extern Error clGetPlatformIDs(Int32 num_entries, [Out] OpenCLPlatform[] platforms, Int32 num_platforms);
	    [DllImport("OpenCL")] public static extern Error clGetPlatformInfo(OpenCLPlatform platform, PlatformInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetPlatformInfo(OpenCLPlatform platform, PlatformInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetProgramBuildInfo(OpenCLProgram program, OpenCLDevice device, ProgramBuildInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetProgramInfo(OpenCLProgram program, ProgramInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetSamplerInfo(OpenCLSampler sampler, SamplerInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern Error clGetSupportedImageFormats(OpenCLContext context, MemFlags flags, MemObjectType image_type, Int32 num_entries, IntPtr image_formats, Int32 num_image_formats);
	    [DllImport("OpenCL")] public static extern Error clGetSupportedImageFormats(OpenCLContext context, MemFlags flags, MemObjectType image_type, Int32 num_entries, [Out] ImageFormat[] image_formats, Int32 num_image_formats);
	    [DllImport("OpenCL")] public static extern Error clSetCommandQueueProperty(OpenCLCommandQueue command_queue, CommandQueueProperties properties, Boolean enable, CommandQueueProperties old_properties);
#endif
		
	    public delegate void LoggingFunction(IntPtr errinfo, IntPtr private_info, IntPtr cb, IntPtr user_data);
	
	    public delegate void NotifyFunction(OpenCLProgram program, IntPtr user_data);
	
	    public delegate void UserFunction(IntPtr[] args);
	}
}