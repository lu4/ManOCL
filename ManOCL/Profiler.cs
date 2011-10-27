using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using ManOCL.Internal;
using ManOCL.Internal.OpenCL;


namespace ManOCL
{
    public class Profiler
    {
        private static Int64 GetInfo(Event e, CLProfilingInfo info)
        {
            Byte[] bytes = new Byte[8];

            SizeT paramValueSizeRet = SizeT.Zero;

            GCHandle bytesHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            {
                OpenCLError.Validate(OpenCLDriver.clGetEventProfilingInfo(e.CLEvent, info, new SizeT(bytes.LongLength), bytesHandle.AddrOfPinnedObject(), ref paramValueSizeRet));
            }
            bytesHandle.Free();

            return BitConverter.ToInt64(bytes, 0);
        }

        public static Int64 SubmitTick(Event e)
        {
            return GetInfo(e, CLProfilingInfo.Submit);
        }
        public static Int64 QueuedTick(Event e)
        {
            return GetInfo(e, CLProfilingInfo.Queued);
        }

        public static Int64 StartTick(Event e)
        {
            return GetInfo(e, CLProfilingInfo.Start);
        }
        public static Int64 EndTick(Event e)
        {
            return GetInfo(e, CLProfilingInfo.End);
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
