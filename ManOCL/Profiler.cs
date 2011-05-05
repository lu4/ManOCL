using System;
using System.Collections.Generic;
using System.Text;
using ManOCL.Native;

namespace ManOCL
{
    public class Profiler
    {
        private static Int64 GetInfo(Event e, ProfilingInfo info)
        {
            Byte[] bytes = new Byte[8];

            IntPtr paramValueSizeRet;

            OpenCLError.Validate(OpenCLDriver.clGetEventProfilingInfo(e.OpenCLEvent, info, new IntPtr(bytes.Length), bytes, out paramValueSizeRet));

            return BitConverter.ToInt64(bytes, 0);
        }

        public static Int64 SubmitTick(Event e)
        {
            return GetInfo(e, ProfilingInfo.Submit);
        }
        public static Int64 QueuedTick(Event e)
        {
            return GetInfo(e, ProfilingInfo.Queued);
        }

        public static Int64 StartTick(Event e)
        {
            return GetInfo(e, ProfilingInfo.Start);
        }
        public static Int64 EndTick(Event e)
        {
            return GetInfo(e, ProfilingInfo.End);
        }
        public static Int64 DurationTicks(Event e)
        {
            return EndTick(e) - StartTick(e);
        }
        public static Double DurationSeconds(Event e)
        {
            return DurationTicks(e) * 1.0E-9;
        }
        public static Double DurationMilliseconds(Event e)
        {
            return DurationTicks(e) * 1.0E-6;
        }
        
        public static TimeSpan DurationTimespan(Event e)
        {
            return TimeSpan.FromSeconds(DurationSeconds(e));
        }

    }
}
