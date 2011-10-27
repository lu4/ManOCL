using System;
using System.Collections.Generic;
using System.Text;
using ManOCL.Internal.OpenCL;
using System.Collections;

namespace ManOCL
{
    public partial class Events : IEnumerable<Event>
    {
        internal Event[] EventArray { get; private set; }
        internal CLEvent[] OpenCLEventArray { get; private set; }

        internal static CLEvent[] GetOpenCLEventArray(Event[] events)
        {
			if (events != null && events.Length != 0)
			{
	            CLEvent[] openclEvents = new CLEvent[events.Length];
	
	            for (UInt32 i = 0; i < events.Length; i++)
	            {
	                openclEvents[i] = events[i].CLEvent;
	            }
	
	            return openclEvents;
			}
			else
			{
				return null;
			}
        }

        internal static Event[] GetEventArray(CLEvent[] openCLEvents)
        {
			if (openCLEvents != null && openCLEvents.Length != 0)
			{
	            Event[] events = new Event[openCLEvents.Length];
	
	            for (UInt32 i = 0; i < openCLEvents.Length; i++)
	            {
	                events[i] = new Event(openCLEvents[i]);
	            }
	
	            return events;
			}
			else
			{
				return null;
			}
        }

        internal Events(CLEvent[] openclEvents, Event[] events, Int32 count)
        {
			this.Count = count;
			
            this.EventArray = events;
            this.OpenCLEventArray = openclEvents;
        }
		
        internal Events(CLEvent[] openCLEvents)
			// No clone is needed since this is internal side (which is stupid user-safe)
            : this(openCLEvents, GetEventArray(openCLEvents), openCLEvents == null ? 0 : openCLEvents.Length)
        {
        }

        public Events(params Event[] eventArray)
            : this(GetOpenCLEventArray(eventArray), eventArray == null ? null : (Event[])eventArray.Clone(), eventArray == null ? 0 : eventArray.Length)
        {
        }

		public Int32 Count { get; private set; }

		public Event this[Int32 index]
        {
            get
            {
                return EventArray[index];
            }
        }
		
		private static Events _Empty;
		
		public static Events Empty
		{
			get
			{
				if (_Empty == null)
				{
					_Empty = new Events(null, null, 0);
				}
				
				return _Empty;
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
