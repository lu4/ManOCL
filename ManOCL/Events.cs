using System;
using System.Collections.Generic;
using System.Text;
using ManOCL.Native;
using System.Collections;

namespace ManOCL
{
    public partial class Events : IEnumerable<Event>
    {
        // General

        internal Event[] EventArray { get; private set; }
        internal OpenCLEvent[] OpenCLEventArray { get; private set; }

        protected static Event[] GetEventArray(OpenCLEvent[] openclEvents, Int32 eventInfoBufferSize)
        {
            Event[] events = new Event[openclEvents.Length];

            for (int i = 0; i < events.Length; i++)
            {
                events[i] = new Event(openclEvents[i]);
            }

            return events;
        }
        protected static OpenCLEvent[] GetOpenCLEventArray(Event[] events)
        {
            OpenCLEvent[] openclEvents = new OpenCLEvent[events.Length];

            for (UInt32 i = 0; i < events.Length; i++)
            {
                openclEvents[i] = events[i].OpenCLEvent;
            }

            return openclEvents;
        }

        internal Events(OpenCLEvent[] openclEvents, Event[] events)
        {
            this.EventArray = events;
            this.OpenCLEventArray = openclEvents;
        }
        internal Events(OpenCLEvent[] openclEvents, Int32 eventInfoBufferSize)
            : this(openclEvents, GetEventArray(openclEvents, eventInfoBufferSize))
        {
        }

        public Events(params Event[] eventArray)
            : this(GetOpenCLEventArray(eventArray), (Event[])eventArray.Clone())
        {
        }

        public Int32 Count
        {
            get
            {
                return EventArray.Length;
            }
        }
        public Event this[Int32 index]
        {
            get
            {
                return EventArray[index];
            }
        }

        // IEnumerable

        public IEnumerator<Event> GetEnumerator()
        {
            foreach (Event evt in EventArray)
            {
                yield return evt;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (Event evt in EventArray)
            {
                yield return evt;
            }
        }
    }
}
