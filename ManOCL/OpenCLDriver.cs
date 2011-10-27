//#define PROFILE_DRIVER_CALLS

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GASS.OpenCL
{
    public partial class OpenCLDriver
	{	
#if PROFILE_DRIVER_CALLS
	    public static CLError clBuildProgram(CLProgram program, Int32 num_devices, [In] CLDeviceID[] device_list, IntPtr options, NotifyFunction func, IntPtr user_data)
        {
            Console.WriteLine("Calling CLError clBuildProgram(CLProgram program, Int32 num_devices, [In] CLDeviceID[] device_list, IntPtr options, NotifyFunction func, IntPtr user_data)");
            return default(CLError);
        }
	    public static CLError clBuildProgram(CLProgram program, Int32 num_devices, [In] CLDeviceID[] device_list, String options, NotifyFunction func, IntPtr user_data)
        {
            Console.WriteLine("Calling CLError clBuildProgram(CLProgram program, Int32 num_devices, [In] CLDeviceID[] device_list, String options, NotifyFunction func, IntPtr user_data)");
            return default(CLError);
        }
	    
		public static CLMem clCreateBuffer(CLContext context, CLMemFlags flags, IntPtr size, [In] Byte[] bytes, out CLError error)
        {
            error = default(CLError);
            Console.WriteLine("Calling CLMem clCreateBuffer(CLContext context, CLMemFlags flags, IntPtr size, [In] Byte[] bytes, out CLError error)");
            return default(CLMem);
        }
	    public static CLMem clCreateBuffer(CLContext context, CLMemFlags flags, IntPtr size, IntPtr host_ptr, out CLError error)
        {
            error = default(CLError);
            Console.WriteLine("Calling CLMem clCreateBuffer(CLContext context, CLMemFlags flags, IntPtr size, IntPtr host_ptr, out CLError error)");
            return default(CLMem);
        }

		public static CLCommandQueue clCreateCommandQueue(CLContext context, CLDeviceID device, CLCommandQueueProperties properties, out CLError error)
        {
            error = default(CLError);
            Console.WriteLine("Calling CLCommandQueue clCreateCommandQueue(CLContext context, CLDeviceID device, CLCommandQueueProperties properties, out CLError error)");
            return default(CLCommandQueue);
        }
		public static CLContext clCreateContext(IntPtr properties, Int32 num_devices, [In] CLDeviceID[] devices, LoggingFunction pfn_notify, IntPtr user_data, out CLError error)
        {
            error = default(CLError);
            Console.WriteLine("Calling CLContext clCreateContext(IntPtr properties, Int32 num_devices, [In] CLDeviceID[] devices, LoggingFunction pfn_notify, IntPtr user_data, out CLError error)");
            return default(CLContext);
        }
	    public static CLContext clCreateContextFromType(IntPtr properties, CLDeviceType device_type, LoggingFunction pfn_notify, IntPtr user_data, out CLError error)
        {
            error = default(CLError);
            Console.WriteLine("Calling CLContext clCreateContextFromType(IntPtr properties, CLDeviceType device_type, LoggingFunction pfn_notify, IntPtr user_data, out CLError error)");
            return default(CLContext);
        }
	    public static CLMem clCreateImage2D(CLContext context, CLMemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, IntPtr host_ptr, out CLError error)
        {
            error = default(CLError);
            Console.WriteLine("Calling CLMem clCreateImage2D(CLContext context, CLMemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, IntPtr host_ptr, out CLError error)");
            return default(CLMem);
        }
	    public static CLMem clCreateImage3D(CLContext context, CLMemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, IntPtr host_ptr, out CLError error)
        {
            error = default(CLError);
            Console.WriteLine("Calling CLMem clCreateImage3D(CLContext context, CLMemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, IntPtr host_ptr, out CLError error)");
            return default(CLMem);
        }
	    public static CLKernel clCreateKernel(CLProgram program, String kernel_name, out CLError error)
        {
            error = default(CLError);
            Console.WriteLine("Calling CLKernel clCreateKernel(CLProgram program, String kernel_name, out CLError error)");
            return default(CLKernel);
        }
	    public static CLError clCreateKernelsInProgram(CLProgram program, Int32 num_kernels, [Out] CLKernel[] kernels, out Int32 num_kernels_ret)
        {
            num_kernels_ret = 1;
            kernels = new CLKernel[] { new CLKernel() };
            Console.WriteLine("Calling CLError clCreateKernelsInProgram(CLProgram program, Int32 num_kernels, [Out] CLKernel[] kernels, out Int32 num_kernels_ret)");
            return default(CLError);
        }

		public static CLProgram clCreateProgramWithBinary(CLContext context, Int32 num_devices, [In] CLDeviceID[] device_list, [In] IntPtr[] lengths, [In] IntPtr[] binaries, [In] Int32[] binary_status, out CLError error)
        {
            error = default(CLError);
            Console.WriteLine("Calling CLProgram clCreateProgramWithBinary(CLContext context, Int32 num_devices, [In] CLDeviceID[] device_list, [In] IntPtr[] lengths, [In] IntPtr[] binaries, [In] Int32[] binary_status, out CLError error)");
            return default(CLProgram);
        }
        public static CLProgram clCreateProgramWithSource(CLContext context, Int32 count, IntPtr Strings, [In] IntPtr[] lengths, out CLError error)
        {
            error = default(CLError);
            Console.WriteLine("Calling CLProgram clCreateProgramWithSource(CLContext context, Int32 count, IntPtr Strings, [In] IntPtr[] lengths, out CLError error)");
            return default(CLProgram);
        }
        public static CLProgram clCreateProgramWithSource(CLContext context, Int32 count, [In] String[] sources, [In] IntPtr[] lengths, out CLError error)
        {
            error = default(CLError);
            Console.WriteLine("Calling CLProgram clCreateProgramWithSource(CLContext context, Int32 count, [In] String[] sources, [In] IntPtr[] lengths, out CLError error)");
            return default(CLProgram);
        }
        public static CLProgram clCreateProgramWithSource(CLContext context, Int32 count, [In] Byte[][] sources, [In] IntPtr[] lengths, out CLError error)
        {
            error = default(CLError);
            Console.WriteLine("Calling CLProgram clCreateProgramWithSource(CLContext context, Int32 count, [In] Byte[][] sources, [In] IntPtr[] lengths, out CLError error)");
            return default(CLProgram);
        }
        public static CLSampler clCreateSampler(CLContext context, Boolean normalized_coords, AddressingMode addressing_mode, FilterMode filter_mode, out CLError error)
        {
            error = default(CLError);
            Console.WriteLine("Calling CLSampler clCreateSampler(CLContext context, Boolean normalized_coords, AddressingMode addressing_mode, FilterMode filter_mode, out CLError error)");
            return default(CLSampler);
        }
	    public static CLError clEnqueueBarrier(CLCommandQueue command_queue)
        {
            Console.WriteLine("Calling CLError clEnqueueBarrier(CLCommandQueue command_queue)");
            return default(CLError);
        }
	    public static CLError clEnqueueCopyBuffer(CLCommandQueue command_queue, CLMem src_buffer, CLMem dst_buffer, IntPtr src_offset, IntPtr dst_offset, IntPtr cb, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)
        {
            e = default(CLEvent);
            Console.WriteLine("Calling CLError clEnqueueCopyBuffer(CLCommandQueue command_queue, CLMem src_buffer, CLMem dst_buffer, IntPtr src_offset, IntPtr dst_offset, IntPtr cb, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueCopyBufferToImage(CLCommandQueue command_queue, CLMem src_buffer, CLMem dst_image, IntPtr src_offset, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)
        {
            e = default(CLEvent);
            Console.WriteLine("Calling CLError clEnqueueCopyBufferToImage(CLCommandQueue command_queue, CLMem src_buffer, CLMem dst_image, IntPtr src_offset, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueCopyImage(CLCommandQueue command_queue, CLMem src_image, CLMem dst_image, IntPtr[] src_origin, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)
        {
            e = default(CLEvent);
            Console.WriteLine("Calling CLError clEnqueueCopyImage(CLCommandQueue command_queue, CLMem src_image, CLMem dst_image, IntPtr[] src_origin, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueCopyImageToBuffer(CLCommandQueue command_queue, CLMem src_image, CLMem dst_buffer, IntPtr[] src_origin, IntPtr[] region, IntPtr dst_offset, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)
        {
            e = default(CLEvent);
            Console.WriteLine("Calling CLError clEnqueueCopyImageToBuffer(CLCommandQueue command_queue, CLMem src_image, CLMem dst_buffer, IntPtr[] src_origin, IntPtr[] region, IntPtr dst_offset, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)");
            return default(CLError);
        }
	    public static IntPtr clEnqueueMapBuffer(CLCommandQueue command_queue, CLMem buffer, Boolean blocking_map, Map map_flags, IntPtr offset, IntPtr cb, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e, out CLError error)
        {
            error = default(CLError);
            e = default(CLEvent);
            Console.WriteLine("Calling IntPtr clEnqueueMapBuffer(CLCommandQueue command_queue, CLMem buffer, Boolean blocking_map, Map map_flags, IntPtr offset, IntPtr cb, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e, out CLError error)");
            return default(IntPtr);
        }
	    public static IntPtr clEnqueueMapImage(CLCommandQueue command_queue, CLMem image, Boolean blocking_map, Map map_flags, IntPtr[] origin, IntPtr[] region, out IntPtr image_row_pitch, out IntPtr image_slice_pitch, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e, out CLError error)
        {
            image_slice_pitch = default(IntPtr);
            image_row_pitch = default(IntPtr);
            e = default(CLEvent);
            error = default(CLError);
            Console.WriteLine("Calling IntPtr clEnqueueMapImage(CLCommandQueue command_queue, CLMem image, Boolean blocking_map, Map map_flags, IntPtr[] origin, IntPtr[] region, out IntPtr image_row_pitch, out IntPtr image_slice_pitch, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e, out CLError error)");
            return default(IntPtr);
        }
	    public static CLError clEnqueueMarker(CLCommandQueue command_queue, out CLEvent e)
        {
            e = default(CLEvent);
            Console.WriteLine("Calling CLError clEnqueueMarker(CLCommandQueue command_queue, out CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueNativeKernel(CLCommandQueue command_queue, UserFunction user_func, [In] IntPtr[] args, IntPtr cb_args, Int32 num_mem_objects, [In] CLMem[] mem_list, [In] IntPtr[] args_mem_loc, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)
        {
            e = default(CLEvent);
            Console.WriteLine("Calling CLError clEnqueueNativeKernel(CLCommandQueue command_queue, UserFunction user_func, [In] IntPtr[] args, IntPtr cb_args, Int32 num_mem_objects, [In] CLMem[] mem_list, [In] IntPtr[] args_mem_loc, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueNDRangeKernel(CLCommandQueue command_queue, CLKernel kernel, Int32 work_dim, [In] IntPtr[] global_work_offset, [In] IntPtr[] global_work_size, [In] IntPtr[] local_work_size, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)
        {
            e = default(CLEvent);
            Console.WriteLine("Calling CLError clEnqueueNDRangeKernel(CLCommandQueue command_queue, CLKernel kernel, Int32 work_dim, [In] IntPtr[] global_work_offset, [In] IntPtr[] global_work_size, [In] IntPtr[] local_work_size, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueReadBuffer(CLCommandQueue command_queue, CLMem buffer, Boolean blocking_read, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)
        {
            Marshal.WriteInt32(ptr, 0, 1);
            Marshal.WriteInt32(ptr, 1, 2);
            Marshal.WriteInt32(ptr, 2, 3);

            e = default(CLEvent);
            Console.WriteLine("Calling CLError clEnqueueReadBuffer(CLCommandQueue command_queue, CLMem buffer, Boolean blocking_read, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueReadImage(CLCommandQueue command_queue, CLMem image, Boolean blocking_read, IntPtr[] origin, IntPtr[] region, IntPtr row_pitch, IntPtr slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)
        {
            e = default(CLEvent);
            Console.WriteLine("Calling CLError clEnqueueReadImage(CLCommandQueue command_queue, CLMem image, Boolean blocking_read, IntPtr[] origin, IntPtr[] region, IntPtr row_pitch, IntPtr slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueTask(CLCommandQueue command_queue, CLKernel kernel, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)
        {
            e = default(CLEvent);
            Console.WriteLine("Calling CLError clEnqueueTask(CLCommandQueue command_queue, CLKernel kernel, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueUnmapMemObject(CLCommandQueue command_queue, CLMem memobj, IntPtr mapped_ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)
        {
            e = default(CLEvent);
            Console.WriteLine("Calling CLError clEnqueueUnmapMemObject(CLCommandQueue command_queue, CLMem memobj, IntPtr mapped_ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueWaitForEvents(CLCommandQueue command_queue, Int32 num_events, [In] CLEvent[] event_list)
        {
            Console.WriteLine("Calling CLError clEnqueueWaitForEvents(CLCommandQueue command_queue, Int32 num_events, [In] CLEvent[] event_list)");
            return default(CLError);
        }
	    public static CLError clEnqueueWriteBuffer(CLCommandQueue command_queue, CLMem buffer, Boolean blocking_write, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)
        {
            e = default(CLEvent);
            Console.WriteLine("Calling CLError clEnqueueWriteBuffer(CLCommandQueue command_queue, CLMem buffer, Boolean blocking_write, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueWriteImage(CLCommandQueue command_queue, CLMem image, Boolean blocking_write, IntPtr[] origin, IntPtr[] region, IntPtr input_row_pitch, IntPtr input_slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)
        {
            e = default(CLEvent);
            Console.WriteLine("Calling CLError clEnqueueWriteImage(CLCommandQueue command_queue, CLMem image, Boolean blocking_write, IntPtr[] origin, IntPtr[] region, IntPtr input_row_pitch, IntPtr input_slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e)");
            return default(CLError);
        }
	    public static CLError clFinish(CLCommandQueue command_queue)
        {
            Console.WriteLine("Calling CLError clFinish(CLCommandQueue command_queue)");
            return default(CLError);
        }
	    public static CLError clFlush(CLCommandQueue command_queue)
        {
            Console.WriteLine("Calling CLError clFlush(CLCommandQueue command_queue)");
            return default(CLError);
        }
	    public static CLError clGetCommandQueueInfo(CLCommandQueue command_queue, CommandQueueInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling CLError clGetCommandQueueInfo(CLCommandQueue command_queue, CommandQueueInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(CLError);
        }

        public static CLError clGetContextInfo(CLContext context, ContextInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling CLError clGetContextInfo(CLContext context, ContextInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(CLError);
        }
        public static CLError clGetContextInfo(CLContext context, ContextInfo param_name, IntPtr param_value_size, [Out] CLDeviceID[] param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling CLError clGetContextInfo(CLContext context, ContextInfo param_name, IntPtr param_value_size, [Out] CLDeviceID[] param_value, out IntPtr param_value_size_ret)");
            return default(CLError);
        }
        
        public static CLError clGetDeviceIDs(CLPlatformID platform_id, CLDeviceType device_type, Int32 num_entries, [Out] CLDeviceID[] devices, out Int32 num_devices)
        {
            num_devices = 1;
            devices = new CLDeviceID[num_devices];
            Console.WriteLine("Calling CLError clGetDeviceIDs(CLPlatformID platform_id, CLDeviceType device_type, Int32 num_entries, [Out] CLDeviceID[] devices, out Int32 num_devices)");
            return default(CLError);
        }
	    public static CLError clGetDeviceIDs(CLPlatformID platform_id, CLDeviceType device_type, Int32 num_entries, IntPtr devices, out Int32 num_devices)
        {
            num_devices = default(Int32);
            Console.WriteLine("Calling CLError clGetDeviceIDs(CLPlatformID platform_id, CLDeviceType device_type, Int32 num_entries, IntPtr devices, out Int32 num_devices)");
            return default(CLError);
        }
	    
	    public static CLError clGetDeviceInfo(CLDeviceID device, CLDeviceInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling CLError clGetDeviceInfo(CLDeviceID device, CLDeviceInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(CLError);
        }
        public static CLError clGetDeviceInfo(CLDeviceID device, CLDeviceInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling CLError clGetDeviceInfo(CLDeviceID device, CLDeviceInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, out IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    
        public static CLError clGetEventInfo(CLEvent e, EventInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling CLError clGetEventInfo(CLEvent e, EventInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetEventProfilingInfo(CLEvent e, CLProfilingInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling CLError clGetEventProfilingInfo(CLEvent e, CLProfilingInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, out IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    
		public static IntPtr clGetExtensionFunctionAddress(String func_name)
        {
            Console.WriteLine("Calling IntPtr clGetExtensionFunctionAddress(String func_name)");
            return default(IntPtr);
        }
	    public static CLError clGetImageInfo(CLMem image, ImageInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling CLError clGetImageInfo(CLMem image, ImageInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetKernelInfo(CLKernel kernel, CLKernelInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            if (param_name == CLKernelInfo.NumArgs)
            {
                Marshal.WriteIntPtr(param_value, new IntPtr(3));

                param_value_size_ret = new IntPtr(IntPtr.Size);
            }
            else if (param_name == CLKernelInfo.FunctionName)
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

            Console.WriteLine("Calling CLError clGetKernelInfo(CLKernel kernel, CLKernelInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetKernelWorkGroupInfo(CLKernel kernel, CLDeviceID device, KernelWorkGroupInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling CLError clGetKernelWorkGroupInfo(CLKernel kernel, CLDeviceID device, KernelWorkGroupInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetMemObjectInfo(CLMem memobj, MemInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling CLError clGetMemObjectInfo(CLMem memobj, MemInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetPlatformIDs(Int32 num_entries, IntPtr platforms, out Int32 num_platforms)
        {
            num_platforms = default(Int32);
            Console.WriteLine("Calling CLError clGetPlatformIDs(Int32 num_entries, IntPtr platforms, out Int32 num_platforms)");
            return default(CLError);
        }
	    public static CLError clGetPlatformIDs(Int32 num_entries, [Out] CLPlatformID[] platforms, out Int32 num_platforms)
        {
            num_platforms = 1;
            platforms = new CLPlatformID[num_platforms];
            Console.WriteLine("Calling CLError clGetPlatformIDs(Int32 num_entries, [Out] CLPlatformID[] platforms, out Int32 num_platforms)");
            return default(CLError);
        }
	    public static CLError clGetPlatformInfo(CLPlatformID platform, CLPlatformInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling CLError clGetPlatformInfo(CLPlatformID platform, CLPlatformInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetPlatformInfo(CLPlatformID platform, CLPlatformInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling CLError clGetPlatformInfo(CLPlatformID platform, CLPlatformInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, out IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetProgramBuildInfo(CLProgram program, CLDeviceID device, ProgramBuildInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling CLError clGetProgramBuildInfo(CLProgram program, CLDeviceID device, ProgramBuildInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetProgramInfo(CLProgram program, ProgramInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling CLError clGetProgramInfo(CLProgram program, ProgramInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetSamplerInfo(CLSampler sampler, SamplerInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)
        {
            param_value_size_ret = default(IntPtr);
            Console.WriteLine("Calling CLError clGetSamplerInfo(CLSampler sampler, SamplerInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetSupportedImageFormats(CLContext context, CLMemFlags flags, MemObjectType image_type, Int32 num_entries, IntPtr image_formats, out Int32 num_image_formats)
        {
            num_image_formats = default(Int32);
            Console.WriteLine("Calling CLError clGetSupportedImageFormats(CLContext context, CLMemFlags flags, MemObjectType image_type, Int32 num_entries, IntPtr image_formats, out Int32 num_image_formats)");
            return default(CLError);
        }
	    public static CLError clGetSupportedImageFormats(CLContext context, CLMemFlags flags, MemObjectType image_type, Int32 num_entries, [Out] ImageFormat[] image_formats, out Int32 num_image_formats)
        {
            num_image_formats = default(Int32);
            Console.WriteLine("Calling CLError clGetSupportedImageFormats(CLContext context, CLMemFlags flags, MemObjectType image_type, Int32 num_entries, [Out] ImageFormat[] image_formats, out Int32 num_image_formats)");
            return default(CLError);
        }
	    public static CLError clReleaseCommandQueue(CLCommandQueue command_queue)
        {
            Console.WriteLine("Calling CLError clReleaseCommandQueue(CLCommandQueue command_queue)");
            return default(CLError);
        }
	    public static CLError clReleaseContext(CLContext context)
        {
            Console.WriteLine("Calling CLError clReleaseContext(CLContext context)");
            return default(CLError);
        }
	    public static CLError clReleaseEvent(CLEvent e)
        {
            Console.WriteLine("Calling CLError clReleaseEvent(CLEvent e)");
            return default(CLError);
        }
	    public static CLError clReleaseKernel(CLKernel kernel)
        {
            Console.WriteLine("Calling CLError clReleaseKernel(CLKernel kernel)");
            return default(CLError);
        }
	    public static CLError clReleaseMemObject(CLMem memobj)
        {
            Console.WriteLine("Calling CLError clReleaseMemObject(CLMem memobj)");
            return default(CLError);
        }
	    public static CLError clReleaseProgram(CLProgram program)
        {
            Console.WriteLine("Calling CLError clReleaseProgram(CLProgram program)");
            return default(CLError);
        }
	    public static CLError clReleaseSampler(CLSampler sampler)
        {
            Console.WriteLine("Calling CLError clReleaseSampler(CLSampler sampler)");
            return default(CLError);
        }
	    public static CLError clRetainCommandQueue(CLCommandQueue command_queue)
        {
            Console.WriteLine("Calling CLError clRetainCommandQueue(CLCommandQueue command_queue)");
            return default(CLError);
        }
	    public static CLError clRetainContext(CLContext context)
        {
            Console.WriteLine("Calling CLError clRetainContext(CLContext context)");
            return default(CLError);
        }
	    public static CLError clRetainEvent(CLEvent e)
        {
            Console.WriteLine("Calling CLError clRetainEvent(CLEvent e)");
            return default(CLError);
        }
	    public static CLError clRetainKernel(CLKernel kernel)
        {
            Console.WriteLine("Calling CLError clRetainKernel(CLKernel kernel)");
            return default(CLError);
        }
	    public static CLError clRetainMemObject(CLMem memobj)
        {
            Console.WriteLine("Calling CLError clRetainMemObject(CLMem memobj)");
            return default(CLError);
        }
	    public static CLError clRetainProgram(CLProgram program)
        {
            Console.WriteLine("Calling CLError clRetainProgram(CLProgram program)");
            return default(CLError);
        }
	    public static CLError clRetainSampler(CLSampler sampler)
        {
            Console.WriteLine("Calling CLError clRetainSampler(CLSampler sampler)");
            return default(CLError);
        }
	    public static CLError clSetCommandQueueProperty(CLCommandQueue command_queue, CLCommandQueueProperties properties, Boolean enable, out CLCommandQueueProperties old_properties)
        {
            old_properties = default(CLCommandQueueProperties);

            Console.WriteLine("Calling CLError clSetCommandQueueProperty(CLCommandQueue command_queue, CLCommandQueueProperties properties, Boolean enable, out CLCommandQueueProperties old_properties)");

            return default(CLError);
        }

        public static CLError clSetKernelArg(CLKernel kernel, Int32 arg_index, IntPtr arg_size, IntPtr arg_value)
        {
            Console.WriteLine("Calling CLError clSetKernelArg(CLKernel kernel, Int32 arg_index, IntPtr arg_size, IntPtr arg_value)");
            return default(CLError);
        }
        public static CLError clSetKernelArg(CLKernel kernel, Int32 arg_index, IntPtr arg_size, ref CLMem arg_value)
        {
            Console.WriteLine("Calling CLError clSetKernelArg(CLKernel kernel, Int32 arg_index, IntPtr arg_size, ref CLMem arg_value)");
            return default(CLError);
        }
	    
		public static CLError clUnloadCompiler()
        {
            Console.WriteLine("Calling CLError clUnloadCompiler()");
            return default(CLError);
        }
	    public static CLError clWaitForEvents(Int32 num_events, [In] CLEvent[] event_list)
        {
            Console.WriteLine("Calling CLError clWaitForEvents(Int32 num_events, [In] CLEvent[] event_list)");
            return default(CLError);
        }
	    public static CLError clWaitForEvents(Int32 num_events, ref CLEvent e)
        {
            Console.WriteLine("Calling CLError clWaitForEvents(Int32 num_events, ref CLEvent e)");
            return default(CLError);
        }

	    public static CLMem clCreateBuffer(CLContext context, CLMemFlags flags, IntPtr size, IntPtr host_ptr, CLError error)
        {
            Console.WriteLine("Calling CLMem clCreateBuffer(CLContext context, CLMemFlags flags, IntPtr size, IntPtr host_ptr, CLError error)");
            return default(CLMem);
        }
	    public static CLCommandQueue clCreateCommandQueue(CLContext context, CLDeviceID device, CLCommandQueueProperties properties, CLError error)
        {
            Console.WriteLine("Calling CLCommandQueue clCreateCommandQueue(CLContext context, CLDeviceID device, CLCommandQueueProperties properties, CLError error)");
            return default(CLCommandQueue);
        }
		public static CLContext clCreateContext(IntPtr properties, Int32 num_devices, [In] CLDeviceID[] devices, LoggingFunction pfn_notify, IntPtr user_data, CLError error)
        {
            Console.WriteLine("Calling CLContext clCreateContext(IntPtr properties, Int32 num_devices, [In] CLDeviceID[] devices, LoggingFunction pfn_notify, IntPtr user_data, CLError error)");
            return default(CLContext);
        }
	    public static CLContext clCreateContextFromType(IntPtr properties, CLDeviceType device_type, LoggingFunction pfn_notify, IntPtr user_data, CLError error)
        {
            Console.WriteLine("Calling CLContext clCreateContextFromType(IntPtr properties, CLDeviceType device_type, LoggingFunction pfn_notify, IntPtr user_data, CLError error)");
            return default(CLContext);
        }
	    public static CLMem clCreateImage2D(CLContext context, CLMemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, IntPtr host_ptr, CLError error)
        {
            Console.WriteLine("Calling CLMem clCreateImage2D(CLContext context, CLMemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, IntPtr host_ptr, CLError error)");
            return default(CLMem);
        }
	    public static CLMem clCreateImage3D(CLContext context, CLMemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, IntPtr host_ptr, CLError error)
        {
            Console.WriteLine("Calling CLMem clCreateImage3D(CLContext context, CLMemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, IntPtr host_ptr, CLError error)");
            return default(CLMem);
        }
	    public static CLKernel clCreateKernel(CLProgram program, String kernel_name, CLError error)
        {
            Console.WriteLine("Calling CLKernel clCreateKernel(CLProgram program, String kernel_name, CLError error)");
            return default(CLKernel);
        }
	    public static CLError clCreateKernelsInProgram(CLProgram program, Int32 num_kernels, [Out] CLKernel[] kernels, Int32 num_kernels_ret)
        {
            Console.WriteLine("Calling CLError clCreateKernelsInProgram(CLProgram program, Int32 num_kernels, [Out] CLKernel[] kernels, Int32 num_kernels_ret)");
            return default(CLError);
        }
	    public static CLProgram clCreateProgramWithBinary(CLContext context, Int32 num_devices, [In] CLDeviceID[] device_list, [In] IntPtr[] lengths, [In] IntPtr[] binaries, [In] Int32[] binary_status, CLError error)
        {
            Console.WriteLine("Calling CLProgram clCreateProgramWithBinary(CLContext context, Int32 num_devices, [In] CLDeviceID[] device_list, [In] IntPtr[] lengths, [In] IntPtr[] binaries, [In] Int32[] binary_status, CLError error)");
            return default(CLProgram);
        }
	    public static CLProgram clCreateProgramWithSource(CLContext context, Int32 count, [In] String[] Strings, [In] IntPtr[] lengths, CLError error)
        {
            Console.WriteLine("Calling CLProgram clCreateProgramWithSource(CLContext context, Int32 count, [In] String[] Strings, [In] IntPtr[] lengths, CLError error)");
            return default(CLProgram);
        }
	    public static CLProgram clCreateProgramWithSource(CLContext context, Int32 count, IntPtr Strings, [In] IntPtr[] lengths, CLError error)
        {
            Console.WriteLine("Calling CLProgram clCreateProgramWithSource(CLContext context, Int32 count, IntPtr Strings, [In] IntPtr[] lengths, CLError error)");
            return default(CLProgram);
        }
	    public static CLProgram clCreateProgramWithSource(CLContext context, Int32 count, String Strings, [In] IntPtr[] lengths, CLError error)
        {
            Console.WriteLine("Calling CLProgram clCreateProgramWithSource(CLContext context, Int32 count, String Strings, [In] IntPtr[] lengths, CLError error)");
            return default(CLProgram);
        }
	    public static CLSampler clCreateSampler(CLContext context, Boolean normalized_coords, AddressingMode addressing_mode, FilterMode filter_mode, CLError error)
        {
            Console.WriteLine("Calling CLSampler clCreateSampler(CLContext context, Boolean normalized_coords, AddressingMode addressing_mode, FilterMode filter_mode, CLError error)");
            return default(CLSampler);
        }
	    public static CLError clEnqueueCopyBuffer(CLCommandQueue command_queue, CLMem src_buffer, CLMem dst_buffer, IntPtr src_offset, IntPtr dst_offset, IntPtr cb, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)
        {
            Console.WriteLine("Calling CLError clEnqueueCopyBuffer(CLCommandQueue command_queue, CLMem src_buffer, CLMem dst_buffer, IntPtr src_offset, IntPtr dst_offset, IntPtr cb, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueCopyBufferToImage(CLCommandQueue command_queue, CLMem src_buffer, CLMem dst_image, IntPtr src_offset, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)
        {
            Console.WriteLine("Calling CLError clEnqueueCopyBufferToImage(CLCommandQueue command_queue, CLMem src_buffer, CLMem dst_image, IntPtr src_offset, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueCopyImage(CLCommandQueue command_queue, CLMem src_image, CLMem dst_image, IntPtr[] src_origin, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)
        {
            Console.WriteLine("Calling CLError clEnqueueCopyImage(CLCommandQueue command_queue, CLMem src_image, CLMem dst_image, IntPtr[] src_origin, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueCopyImageToBuffer(CLCommandQueue command_queue, CLMem src_image, CLMem dst_buffer, IntPtr[] src_origin, IntPtr[] region, IntPtr dst_offset, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)
        {
            Console.WriteLine("Calling CLError clEnqueueCopyImageToBuffer(CLCommandQueue command_queue, CLMem src_image, CLMem dst_buffer, IntPtr[] src_origin, IntPtr[] region, IntPtr dst_offset, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)");
            return default(CLError);
        }
	    public static IntPtr clEnqueueMapBuffer(CLCommandQueue command_queue, CLMem buffer, Boolean blocking_map, Map map_flags, IntPtr offset, IntPtr cb, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e, CLError error)
        {
            Console.WriteLine("Calling IntPtr clEnqueueMapBuffer(CLCommandQueue command_queue, CLMem buffer, Boolean blocking_map, Map map_flags, IntPtr offset, IntPtr cb, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e, CLError error)");
            return default(IntPtr);
        }
	    public static IntPtr clEnqueueMapImage(CLCommandQueue command_queue, CLMem image, Boolean blocking_map, Map map_flags, IntPtr[] origin, IntPtr[] region, IntPtr image_row_pitch, IntPtr image_slice_pitch, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e, CLError error)
        {
            Console.WriteLine("Calling IntPtr clEnqueueMapImage(CLCommandQueue command_queue, CLMem image, Boolean blocking_map, Map map_flags, IntPtr[] origin, IntPtr[] region, IntPtr image_row_pitch, IntPtr image_slice_pitch, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e, CLError error)");
            return default(IntPtr);
        }
	    public static CLError clEnqueueMarker(CLCommandQueue command_queue, CLEvent e)
        {
            Console.WriteLine("Calling CLError clEnqueueMarker(CLCommandQueue command_queue, CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueNativeKernel(CLCommandQueue command_queue, UserFunction user_func, [In] IntPtr[] args, IntPtr cb_args, Int32 num_mem_objects, [In] CLMem[] mem_list, [In] IntPtr[] args_mem_loc, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)
        {
            Console.WriteLine("Calling CLError clEnqueueNativeKernel(CLCommandQueue command_queue, UserFunction user_func, [In] IntPtr[] args, IntPtr cb_args, Int32 num_mem_objects, [In] CLMem[] mem_list, [In] IntPtr[] args_mem_loc, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueNDRangeKernel(CLCommandQueue command_queue, CLKernel kernel, Int32 work_dim, [In] IntPtr[] global_work_offset, [In] IntPtr[] global_work_size, [In] IntPtr[] local_work_size, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)
        {
            Console.WriteLine("Calling CLError clEnqueueNDRangeKernel(CLCommandQueue command_queue, CLKernel kernel, Int32 work_dim, [In] IntPtr[] global_work_offset, [In] IntPtr[] global_work_size, [In] IntPtr[] local_work_size, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueReadBuffer(CLCommandQueue command_queue, CLMem buffer, Boolean blocking_read, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)
        {
            Console.WriteLine("Calling CLError clEnqueueReadBuffer(CLCommandQueue command_queue, CLMem buffer, Boolean blocking_read, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueReadImage(CLCommandQueue command_queue, CLMem image, Boolean blocking_read, IntPtr[] origin, IntPtr[] region, IntPtr row_pitch, IntPtr slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)
        {
            Console.WriteLine("Calling CLError clEnqueueReadImage(CLCommandQueue command_queue, CLMem image, Boolean blocking_read, IntPtr[] origin, IntPtr[] region, IntPtr row_pitch, IntPtr slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueTask(CLCommandQueue command_queue, CLKernel kernel, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)
        {
            Console.WriteLine("Calling CLError clEnqueueTask(CLCommandQueue command_queue, CLKernel kernel, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueUnmapMemObject(CLCommandQueue command_queue, CLMem memobj, IntPtr mapped_ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)
        {
            Console.WriteLine("Calling CLError clEnqueueUnmapMemObject(CLCommandQueue command_queue, CLMem memobj, IntPtr mapped_ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueWriteBuffer(CLCommandQueue command_queue, CLMem buffer, Boolean blocking_write, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)
        {
            Console.WriteLine("Calling CLError clEnqueueWriteBuffer(CLCommandQueue command_queue, CLMem buffer, Boolean blocking_write, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)");
            return default(CLError);
        }
	    public static CLError clEnqueueWriteImage(CLCommandQueue command_queue, CLMem image, Boolean blocking_write, IntPtr[] origin, IntPtr[] region, IntPtr input_row_pitch, IntPtr input_slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)
        {
            Console.WriteLine("Calling CLError clEnqueueWriteImage(CLCommandQueue command_queue, CLMem image, Boolean blocking_write, IntPtr[] origin, IntPtr[] region, IntPtr input_row_pitch, IntPtr input_slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e)");
            return default(CLError);
        }
        public static CLError clGetCommandQueueInfo(CLCommandQueue command_queue, CommandQueueInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling CLError clGetCommandQueueInfo(CLCommandQueue command_queue, CommandQueueInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(CLError);
        }
        public static CLError clGetCommandQueueInfo(CLCommandQueue command_queue, CommandQueueInfo param_name, IntPtr param_value_size, [Out] CLDeviceID[] param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling CLError clGetCommandQueueInfo(CLCommandQueue command_queue, CommandQueueInfo param_name, IntPtr param_value_size, [Out] CLDeviceID[] param_value, IntPtr param_value_size_ret)");
            return default(CLError);
        }

        public static CLError clGetContextInfo(CLContext context, ContextInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling CLError clGetContextInfo(CLContext context, ContextInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(CLError);
        }
        public static CLError clGetContextInfo(CLContext context, ContextInfo param_name, IntPtr param_value_size, [Out] CLDeviceID[] param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling CLError clGetContextInfo(CLContext context, ContextInfo param_name, IntPtr param_value_size, [Out] CLDeviceID[] param_value, IntPtr param_value_size_ret)");
            return default(CLError);
        }

        public static CLError clGetDeviceIDs(CLPlatformID platform_id, CLDeviceType device_type, Int32 num_entries, [Out] CLDeviceID[] devices, Int32 num_devices)
        {
            Console.WriteLine("Calling CLError clGetDeviceIDs(CLPlatformID platform_id, CLDeviceType device_type, Int32 num_entries, [Out] CLDeviceID[] devices, Int32 num_devices)");
            return default(CLError);
        }
	    public static CLError clGetDeviceIDs(CLPlatformID platform_id, CLDeviceType device_type, Int32 num_entries, IntPtr devices, Int32 num_devices)
        {
            Console.WriteLine("Calling CLError clGetDeviceIDs(CLPlatformID platform_id, CLDeviceType device_type, Int32 num_entries, IntPtr devices, Int32 num_devices)");
            return default(CLError);
        }
	    public static CLError clGetDeviceInfo(CLDeviceID device, CLDeviceInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling CLError clGetDeviceInfo(CLDeviceID device, CLDeviceInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetDeviceInfo(CLDeviceID device, CLDeviceInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling CLError clGetDeviceInfo(CLDeviceID device, CLDeviceInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetEventInfo(CLEvent e, EventInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling CLError clGetEventInfo(CLEvent e, EventInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(CLError);
        }
		public static CLError clGetImageInfo(CLMem image, ImageInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling CLError clGetImageInfo(CLMem image, ImageInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetKernelInfo(CLKernel kernel, CLKernelInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling CLError clGetKernelInfo(CLKernel kernel, CLKernelInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetKernelWorkGroupInfo(CLKernel kernel, CLDeviceID device, KernelWorkGroupInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling CLError clGetKernelWorkGroupInfo(CLKernel kernel, CLDeviceID device, KernelWorkGroupInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetMemObjectInfo(CLMem memobj, MemInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling CLError clGetMemObjectInfo(CLMem memobj, MemInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetPlatformIDs(Int32 num_entries, IntPtr platforms, Int32 num_platforms)
        {
            Console.WriteLine("Calling CLError clGetPlatformIDs(Int32 num_entries, IntPtr platforms, Int32 num_platforms)");
            return default(CLError);
        }
	    public static CLError clGetPlatformIDs(Int32 num_entries, [Out] CLPlatformID[] platforms, Int32 num_platforms)
        {
            Console.WriteLine("Calling CLError clGetPlatformIDs(Int32 num_entries, [Out] CLPlatformID[] platforms, Int32 num_platforms)");
            return default(CLError);
        }
	    public static CLError clGetPlatformInfo(CLPlatformID platform, CLPlatformInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling CLError clGetPlatformInfo(CLPlatformID platform, CLPlatformInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetPlatformInfo(CLPlatformID platform, CLPlatformInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling CLError clGetPlatformInfo(CLPlatformID platform, CLPlatformInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetProgramBuildInfo(CLProgram program, CLDeviceID device, ProgramBuildInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling CLError clGetProgramBuildInfo(CLProgram program, CLDeviceID device, ProgramBuildInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetProgramInfo(CLProgram program, ProgramInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling CLError clGetProgramInfo(CLProgram program, ProgramInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetSamplerInfo(CLSampler sampler, SamplerInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)
        {
            Console.WriteLine("Calling CLError clGetSamplerInfo(CLSampler sampler, SamplerInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret)");
            return default(CLError);
        }
	    public static CLError clGetSupportedImageFormats(CLContext context, CLMemFlags flags, MemObjectType image_type, Int32 num_entries, IntPtr image_formats, Int32 num_image_formats)
        {
            Console.WriteLine("Calling CLError clGetSupportedImageFormats(CLContext context, CLMemFlags flags, MemObjectType image_type, Int32 num_entries, IntPtr image_formats, Int32 num_image_formats)");
            return default(CLError);
        }
	    public static CLError clGetSupportedImageFormats(CLContext context, CLMemFlags flags, MemObjectType image_type, Int32 num_entries, [Out] ImageFormat[] image_formats, Int32 num_image_formats)
        {
            Console.WriteLine("Calling CLError clGetSupportedImageFormats(CLContext context, CLMemFlags flags, MemObjectType image_type, Int32 num_entries, [Out] ImageFormat[] image_formats, Int32 num_image_formats)");
            return default(CLError);
        }
	    public static CLError clSetCommandQueueProperty(CLCommandQueue command_queue, CLCommandQueueProperties properties, Boolean enable, CLCommandQueueProperties old_properties)
        {
            Console.WriteLine("Calling CLError clSetCommandQueueProperty(CLCommandQueue command_queue, CLCommandQueueProperties properties, Boolean enable, CLCommandQueueProperties old_properties)");
            return default(CLError);
        }
#else
	    [DllImport("OpenCL")] public static extern CLError clBuildProgram(CLProgram program, Int32 num_devices, [In] CLDeviceID[] device_list, IntPtr options, NotifyFunction func, IntPtr user_data);
	    [DllImport("OpenCL")] public static extern CLError clBuildProgram(CLProgram program, Int32 num_devices, [In] CLDeviceID[] device_list, String options, NotifyFunction func, IntPtr user_data);
	    
		[DllImport("OpenCL")] public static extern CLMem clCreateBuffer(CLContext context, CLMemFlags flags, IntPtr size, [In] Byte[] bytes, out CLError error);
	    [DllImport("OpenCL")] public static extern CLMem clCreateBuffer(CLContext context, CLMemFlags flags, IntPtr size, IntPtr host_ptr, out CLError error);

		[DllImport("OpenCL")] public static extern CLCommandQueue clCreateCommandQueue(CLContext context, CLDeviceID device, CLCommandQueueProperties properties, out CLError error);
		[DllImport("OpenCL")] public static extern CLContext clCreateContext(IntPtr[] properties, Int32 num_devices, [In] CLDeviceID[] devices, LoggingFunction pfn_notify, IntPtr user_data, out CLError error);
	    [DllImport("OpenCL")] public static extern CLContext clCreateContextFromType(IntPtr properties, CLDeviceType device_type, LoggingFunction pfn_notify, IntPtr user_data, out CLError error);
	    [DllImport("OpenCL")] public static extern CLMem clCreateImage2D(CLContext context, CLMemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, IntPtr host_ptr, out CLError error);
	    [DllImport("OpenCL")] public static extern CLMem clCreateImage3D(CLContext context, CLMemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, IntPtr host_ptr, out CLError error);
	    [DllImport("OpenCL")] public static extern CLKernel clCreateKernel(CLProgram program, String kernel_name, out CLError error);
	    [DllImport("OpenCL")] public static extern CLError clCreateKernelsInProgram(CLProgram program, Int32 num_kernels, [Out] CLKernel[] kernels, out Int32 num_kernels_ret);

		// This line causes Mono to crash
		// [DllImport("OpenCL")] public static extern CLProgram clCreateProgramWithSource<T>(CLContext context, Int32 count, [In] T[] sources, [In] IntPtr[] lengths, out CLError error);

		[DllImport("OpenCL")] public static extern CLProgram clCreateProgramWithBinary(CLContext context, Int32 num_devices, [In] CLDeviceID[] device_list, [In] IntPtr[] lengths, [In] IntPtr[] binaries, [In] Int32[] binary_status, out CLError error);
        [DllImport("OpenCL")] public static extern CLProgram clCreateProgramWithSource(CLContext context, Int32 count, IntPtr Strings, [In] IntPtr[] lengths, out CLError error);
        [DllImport("OpenCL")] public static extern CLProgram clCreateProgramWithSource(CLContext context, Int32 count, [In] String[] sources, [In] IntPtr[] lengths, out CLError error);
        [DllImport("OpenCL")] public static extern CLProgram clCreateProgramWithSource(CLContext context, Int32 count, [In] Byte[][] sources, [In] IntPtr[] lengths, out CLError error);
        [DllImport("OpenCL")] public static extern CLSampler clCreateSampler(CLContext context, Boolean normalized_coords, AddressingMode addressing_mode, FilterMode filter_mode, out CLError error);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueBarrier(CLCommandQueue command_queue);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueCopyBuffer(CLCommandQueue command_queue, CLMem src_buffer, CLMem dst_buffer, IntPtr src_offset, IntPtr dst_offset, IntPtr cb, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueCopyBufferToImage(CLCommandQueue command_queue, CLMem src_buffer, CLMem dst_image, IntPtr src_offset, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueCopyImage(CLCommandQueue command_queue, CLMem src_image, CLMem dst_image, IntPtr[] src_origin, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueCopyImageToBuffer(CLCommandQueue command_queue, CLMem src_image, CLMem dst_buffer, IntPtr[] src_origin, IntPtr[] region, IntPtr dst_offset, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e);
	    [DllImport("OpenCL")] public static extern IntPtr clEnqueueMapBuffer(CLCommandQueue command_queue, CLMem buffer, Boolean blocking_map, Map map_flags, IntPtr offset, IntPtr cb, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e, out CLError error);
	    [DllImport("OpenCL")] public static extern IntPtr clEnqueueMapImage(CLCommandQueue command_queue, CLMem image, Boolean blocking_map, Map map_flags, IntPtr[] origin, IntPtr[] region, out IntPtr image_row_pitch, out IntPtr image_slice_pitch, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e, out CLError error);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueMarker(CLCommandQueue command_queue, out CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueNativeKernel(CLCommandQueue command_queue, UserFunction user_func, [In] IntPtr[] args, IntPtr cb_args, Int32 num_mem_objects, [In] CLMem[] mem_list, [In] IntPtr[] args_mem_loc, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueNDRangeKernel(CLCommandQueue command_queue, CLKernel kernel, Int32 work_dim, [In] IntPtr[] global_work_offset, [In] IntPtr[] global_work_size, [In] IntPtr[] local_work_size, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, ref CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueReadBuffer(CLCommandQueue command_queue, CLMem buffer, Boolean blocking_read, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueReadImage(CLCommandQueue command_queue, CLMem image, Boolean blocking_read, IntPtr[] origin, IntPtr[] region, IntPtr row_pitch, IntPtr slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueTask(CLCommandQueue command_queue, CLKernel kernel, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueUnmapMemObject(CLCommandQueue command_queue, CLMem memobj, IntPtr mapped_ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueWaitForEvents(CLCommandQueue command_queue, Int32 num_events, [In] CLEvent[] event_list);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueWriteBuffer(CLCommandQueue command_queue, CLMem buffer, Boolean blocking_write, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueWriteImage(CLCommandQueue command_queue, CLMem image, Boolean blocking_write, IntPtr[] origin, IntPtr[] region, IntPtr input_row_pitch, IntPtr input_slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, out CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clFinish(CLCommandQueue command_queue);
	    [DllImport("OpenCL")] public static extern CLError clFlush(CLCommandQueue command_queue);
	    [DllImport("OpenCL")] public static extern CLError clGetCommandQueueInfo(CLCommandQueue command_queue, CommandQueueInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);

        [DllImport("OpenCL")] public static extern CLError clGetContextInfo(CLContext context, ContextInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
        [DllImport("OpenCL")] public static extern CLError clGetContextInfo(CLContext context, ContextInfo param_name, IntPtr param_value_size, [Out] CLDeviceID[] param_value, out IntPtr param_value_size_ret);
        
        [DllImport("OpenCL")] public static extern CLError clGetDeviceIDs(CLPlatformID platform_id, CLDeviceType device_type, Int32 num_entries, [Out] CLDeviceID[] devices, out Int32 num_devices);
	    [DllImport("OpenCL")] public static extern CLError clGetDeviceIDs(CLPlatformID platform_id, CLDeviceType device_type, Int32 num_entries, IntPtr devices, out Int32 num_devices);
	    
	    [DllImport("OpenCL")] public static extern CLError clGetDeviceInfo(CLDeviceID device, CLDeviceInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
	    
        [DllImport("OpenCL")] public static extern CLError clGetEventInfo(CLEvent e, EventInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetEventProfilingInfo(CLEvent e, CLProfilingInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, out IntPtr param_value_size_ret);
	    
		[DllImport("OpenCL")] public static extern IntPtr clGetExtensionFunctionAddress(String func_name);
	    [DllImport("OpenCL")] public static extern CLError clGetImageInfo(CLMem image, ImageInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetKernelInfo(CLKernel kernel, CLKernelInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetKernelWorkGroupInfo(CLKernel kernel, CLDeviceID device, KernelWorkGroupInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetMemObjectInfo(CLMem memobj, MemInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetPlatformIDs(Int32 num_entries, IntPtr platforms, out Int32 num_platforms);
	    [DllImport("OpenCL")] public static extern CLError clGetPlatformIDs(Int32 num_entries, [Out] CLPlatformID[] platforms, out Int32 num_platforms);
	    [DllImport("OpenCL")] public static extern CLError clGetPlatformInfo(CLPlatformID platform, CLPlatformInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetPlatformInfo(CLPlatformID platform, CLPlatformInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, out IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetProgramBuildInfo(CLProgram program, CLDeviceID device, ProgramBuildInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetProgramInfo(CLProgram program, ProgramInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetSamplerInfo(CLSampler sampler, SamplerInfo param_name, IntPtr param_value_size, IntPtr param_value, out IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetSupportedImageFormats(CLContext context, CLMemFlags flags, MemObjectType image_type, Int32 num_entries, IntPtr image_formats, out Int32 num_image_formats);
	    [DllImport("OpenCL")] public static extern CLError clGetSupportedImageFormats(CLContext context, CLMemFlags flags, MemObjectType image_type, Int32 num_entries, [Out] ImageFormat[] image_formats, out Int32 num_image_formats);
	    [DllImport("OpenCL")] public static extern CLError clReleaseCommandQueue(CLCommandQueue command_queue);
	    [DllImport("OpenCL")] public static extern CLError clReleaseContext(CLContext context);
	    [DllImport("OpenCL")] public static extern CLError clReleaseEvent(CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clReleaseKernel(CLKernel kernel);
	    [DllImport("OpenCL")] public static extern CLError clReleaseMemObject(CLMem memobj);
	    [DllImport("OpenCL")] public static extern CLError clReleaseProgram(CLProgram program);
	    [DllImport("OpenCL")] public static extern CLError clReleaseSampler(CLSampler sampler);
	    [DllImport("OpenCL")] public static extern CLError clRetainCommandQueue(CLCommandQueue command_queue);
	    [DllImport("OpenCL")] public static extern CLError clRetainContext(CLContext context);
	    [DllImport("OpenCL")] public static extern CLError clRetainEvent(CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clRetainKernel(CLKernel kernel);
	    [DllImport("OpenCL")] public static extern CLError clRetainMemObject(CLMem memobj);
	    [DllImport("OpenCL")] public static extern CLError clRetainProgram(CLProgram program);
	    [DllImport("OpenCL")] public static extern CLError clRetainSampler(CLSampler sampler);
	    [DllImport("OpenCL")] public static extern CLError clSetCommandQueueProperty(CLCommandQueue command_queue, CLCommandQueueProperties properties, Boolean enable, out CLCommandQueueProperties old_properties);

        [DllImport("OpenCL")] public static extern CLError clSetKernelArg(CLKernel kernel, Int32 arg_index, IntPtr arg_size, IntPtr arg_value);
        [DllImport("OpenCL")] public static extern CLError clSetKernelArg(CLKernel kernel, Int32 arg_index, IntPtr arg_size, ref CLMem mem);
        [DllImport("OpenCL")] public static extern CLError clSetKernelArg(CLKernel kernel, Int32 arg_index, IntPtr arg_size, ref CLSampler sampler);
	    
		[DllImport("OpenCL")] public static extern CLError clUnloadCompiler();
	    [DllImport("OpenCL")] public static extern CLError clWaitForEvents(Int32 num_events, [In] CLEvent[] event_list);
	    [DllImport("OpenCL")] public static extern CLError clWaitForEvents(Int32 num_events, ref CLEvent e);

	    [DllImport("OpenCL")] public static extern CLMem clCreateBuffer(CLContext context, CLMemFlags flags, IntPtr size, IntPtr host_ptr, CLError error);
	    [DllImport("OpenCL")] public static extern CLCommandQueue clCreateCommandQueue(CLContext context, CLDeviceID device, CLCommandQueueProperties properties, CLError error);
		[DllImport("OpenCL")] public static extern CLContext clCreateContext(IntPtr[] properties, Int32 num_devices, [In] CLDeviceID[] devices, LoggingFunction pfn_notify, IntPtr user_data, CLError error);
	    [DllImport("OpenCL")] public static extern CLContext clCreateContextFromType(IntPtr properties, CLDeviceType device_type, LoggingFunction pfn_notify, IntPtr user_data, CLError error);
	    [DllImport("OpenCL")] public static extern CLMem clCreateImage2D(CLContext context, CLMemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_row_pitch, IntPtr host_ptr, CLError error);
	    [DllImport("OpenCL")] public static extern CLMem clCreateImage3D(CLContext context, CLMemFlags flags, ref ImageFormat image_format, IntPtr image_width, IntPtr image_height, IntPtr image_depth, IntPtr image_row_pitch, IntPtr image_slice_pitch, IntPtr host_ptr, CLError error);
	    [DllImport("OpenCL")] public static extern CLKernel clCreateKernel(CLProgram program, String kernel_name, CLError error);
	    [DllImport("OpenCL")] public static extern CLError clCreateKernelsInProgram(CLProgram program, Int32 num_kernels, [Out] CLKernel[] kernels, Int32 num_kernels_ret);
	    [DllImport("OpenCL")] public static extern CLProgram clCreateProgramWithBinary(CLContext context, Int32 num_devices, [In] CLDeviceID[] device_list, [In] IntPtr[] lengths, [In] IntPtr[] binaries, [In] Int32[] binary_status, CLError error);
	    [DllImport("OpenCL")] public static extern CLProgram clCreateProgramWithSource(CLContext context, Int32 count, [In] String[] Strings, [In] IntPtr[] lengths, CLError error);
	    [DllImport("OpenCL")] public static extern CLProgram clCreateProgramWithSource(CLContext context, Int32 count, IntPtr Strings, [In] IntPtr[] lengths, CLError error);
	    [DllImport("OpenCL")] public static extern CLProgram clCreateProgramWithSource(CLContext context, Int32 count, String Strings, [In] IntPtr[] lengths, CLError error);
	    [DllImport("OpenCL")] public static extern CLSampler clCreateSampler(CLContext context, Boolean normalized_coords, AddressingMode addressing_mode, FilterMode filter_mode, CLError error);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueCopyBuffer(CLCommandQueue command_queue, CLMem src_buffer, CLMem dst_buffer, IntPtr src_offset, IntPtr dst_offset, IntPtr cb, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueCopyBufferToImage(CLCommandQueue command_queue, CLMem src_buffer, CLMem dst_image, IntPtr src_offset, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueCopyImage(CLCommandQueue command_queue, CLMem src_image, CLMem dst_image, IntPtr[] src_origin, IntPtr[] dst_origin, IntPtr[] region, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueCopyImageToBuffer(CLCommandQueue command_queue, CLMem src_image, CLMem dst_buffer, IntPtr[] src_origin, IntPtr[] region, IntPtr dst_offset, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e);
	    [DllImport("OpenCL")] public static extern IntPtr clEnqueueMapBuffer(CLCommandQueue command_queue, CLMem buffer, Boolean blocking_map, Map map_flags, IntPtr offset, IntPtr cb, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e, CLError error);
	    [DllImport("OpenCL")] public static extern IntPtr clEnqueueMapImage(CLCommandQueue command_queue, CLMem image, Boolean blocking_map, Map map_flags, IntPtr[] origin, IntPtr[] region, IntPtr image_row_pitch, IntPtr image_slice_pitch, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e, CLError error);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueMarker(CLCommandQueue command_queue, CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueNativeKernel(CLCommandQueue command_queue, UserFunction user_func, [In] IntPtr[] args, IntPtr cb_args, Int32 num_mem_objects, [In] CLMem[] mem_list, [In] IntPtr[] args_mem_loc, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueNDRangeKernel(CLCommandQueue command_queue, CLKernel kernel, Int32 work_dim, [In] IntPtr[] global_work_offset, [In] IntPtr[] global_work_size, [In] IntPtr[] local_work_size, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueReadBuffer(CLCommandQueue command_queue, CLMem buffer, Boolean blocking_read, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueReadImage(CLCommandQueue command_queue, CLMem image, Boolean blocking_read, IntPtr[] origin, IntPtr[] region, IntPtr row_pitch, IntPtr slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueTask(CLCommandQueue command_queue, CLKernel kernel, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueUnmapMemObject(CLCommandQueue command_queue, CLMem memobj, IntPtr mapped_ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueWriteBuffer(CLCommandQueue command_queue, CLMem buffer, Boolean blocking_write, IntPtr offset, IntPtr cb, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e);
	    [DllImport("OpenCL")] public static extern CLError clEnqueueWriteImage(CLCommandQueue command_queue, CLMem image, Boolean blocking_write, IntPtr[] origin, IntPtr[] region, IntPtr input_row_pitch, IntPtr input_slice_pitch, IntPtr ptr, Int32 num_events_in_wait_list, [In] CLEvent[] event_wait_list, CLEvent e);
        [DllImport("OpenCL")] public static extern CLError clGetCommandQueueInfo(CLCommandQueue command_queue, CommandQueueInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
        [DllImport("OpenCL")] public static extern CLError clGetCommandQueueInfo(CLCommandQueue command_queue, CommandQueueInfo param_name, IntPtr param_value_size, [Out] CLDeviceID[] param_value, IntPtr param_value_size_ret);

        [DllImport("OpenCL")] public static extern CLError clGetContextInfo(CLContext context, ContextInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
        [DllImport("OpenCL")] public static extern CLError clGetContextInfo(CLContext context, ContextInfo param_name, IntPtr param_value_size, [Out] CLDeviceID[] param_value, IntPtr param_value_size_ret);

        [DllImport("OpenCL")] public static extern CLError clGetDeviceIDs(CLPlatformID platform_id, CLDeviceType device_type, Int32 num_entries, [Out] CLDeviceID[] devices, Int32 num_devices);
	    [DllImport("OpenCL")] public static extern CLError clGetDeviceIDs(CLPlatformID platform_id, CLDeviceType device_type, Int32 num_entries, IntPtr devices, Int32 num_devices);
	    [DllImport("OpenCL")] public static extern CLError clGetDeviceInfo(CLDeviceID device, CLDeviceInfo param_name, IntPtr param_value_size, [Out] CLPlatformID[] param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetDeviceInfo(CLDeviceID device, CLDeviceInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetDeviceInfo(CLDeviceID device, CLDeviceInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetEventInfo(CLEvent e, EventInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
		[DllImport("OpenCL")] public static extern CLError clGetImageInfo(CLMem image, ImageInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetKernelInfo(CLKernel kernel, CLKernelInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetKernelWorkGroupInfo(CLKernel kernel, CLDeviceID device, KernelWorkGroupInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetMemObjectInfo(CLMem memobj, MemInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetPlatformIDs(Int32 num_entries, IntPtr platforms, Int32 num_platforms);
	    [DllImport("OpenCL")] public static extern CLError clGetPlatformIDs(Int32 num_entries, [Out] CLPlatformID[] platforms, Int32 num_platforms);
	    [DllImport("OpenCL")] public static extern CLError clGetPlatformInfo(CLPlatformID platform, CLPlatformInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetPlatformInfo(CLPlatformID platform, CLPlatformInfo param_name, IntPtr param_value_size, [Out] Byte[] param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetProgramBuildInfo(CLProgram program, CLDeviceID device, ProgramBuildInfo param_name, IntPtr param_value_size, [In] byte[] param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetProgramInfo(CLProgram program, ProgramInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetSamplerInfo(CLSampler sampler, SamplerInfo param_name, IntPtr param_value_size, IntPtr param_value, IntPtr param_value_size_ret);
	    [DllImport("OpenCL")] public static extern CLError clGetSupportedImageFormats(CLContext context, CLMemFlags flags, MemObjectType image_type, Int32 num_entries, IntPtr image_formats, Int32 num_image_formats);
	    [DllImport("OpenCL")] public static extern CLError clGetSupportedImageFormats(CLContext context, CLMemFlags flags, MemObjectType image_type, Int32 num_entries, [Out] ImageFormat[] image_formats, Int32 num_image_formats);
	    [DllImport("OpenCL")] public static extern CLError clSetCommandQueueProperty(CLCommandQueue command_queue, CLCommandQueueProperties properties, Boolean enable, CLCommandQueueProperties old_properties);
#endif
		
	    public delegate void LoggingFunction(IntPtr errinfo, IntPtr private_info, IntPtr cb, IntPtr user_data);
	
	    public delegate void NotifyFunction(CLProgram program, IntPtr user_data);
	
	    public delegate void UserFunction(IntPtr[] args);
	}
}