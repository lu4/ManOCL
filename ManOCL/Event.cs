using System;

namespace ManOCL
{
    using Native;

    public class Event
    {
        internal OpenCLEvent OpenCLEvent { get; private set; }

        internal Event(OpenCLEvent openclEvent)
        {
            this.OpenCLEvent = openclEvent;
        }
    }
}
