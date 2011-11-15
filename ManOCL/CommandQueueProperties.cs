using System;

namespace ManOCL
{
    public enum CommandQueueProperties : ulong
    {
		None						= 0L,
        OutOfOrderExecModeEnable	= 1L,
        ProfilingEnable				= 2L
    }
}
