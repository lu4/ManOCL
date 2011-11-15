using System;

using ManOCL.Internal.OpenCL;

namespace ManOCL
{
    public class Event : IDisposable
    {
		private Boolean disposed;
		
        internal CLEvent CLEvent { get; private set; }

        internal Event(CLEvent openclEvent)
        {
            this.CLEvent = openclEvent;
        }
		
		#region IDisposable implementation
		public void Dispose()
		{
			Dispose(true);
			
			GC.SuppressFinalize(this);
		}
		
		protected virtual void Dispose(Boolean disposing)
		{
			if (!disposed)
			{
				disposed = true;
				
				// if (disposing)
				// {
				// 		No managed resources to dispose
				// }
				
				OpenCLDriver.clReleaseEvent(CLEvent);
			}
		}
		#endregion
		
		~Event()
		{
			Dispose(false);
		}
    }
}
