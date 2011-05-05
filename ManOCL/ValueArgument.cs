using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManOCL
{
    public class ValueArgument<T> : Argument
        where T : struct
    {
        private GCHandle valueHandle;

        public T Value { get; private set; }

        public ValueArgument(T value)
        {
            this.valueHandle = GCHandle.Alloc(this.Value = value, GCHandleType.Pinned);
        }

        internal override IntPtr IntPtr
        {
            get
            {
                return valueHandle.AddrOfPinnedObject();
            }
        }
        internal override IntPtr IntPtrSize
        {
            get
            {
                return new IntPtr(Marshal.SizeOf(typeof(T)));
            }
        }

        public static implicit operator ValueArgument<T>(T value)
        {
            return new ValueArgument<T>(value);
        }
    }
}
