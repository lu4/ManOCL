using System;
using System.Collections.Generic;
using System.Text;

namespace ManOCL
{
    public struct Int32Segment
    {
        private Int32 _A;
        private Int32 _B;

        public Int32Segment(Int32 a, Int32 b)
        {
            this._A = a;
            this._B = b;
        }

        public Int32 A
        {
            get
            {
                return _A;
            }
        }

        public Int32 B
        {
            get
            {
                return _B;
            }
        }

        public Int32 Length
        {
            get
            {

                return B - A;
            }
        }
    }

    public struct Int64Segment
    {
        private Int64 _A;
        private Int64 _B;

        public Int64Segment(Int64 a, Int64 b)
        {
            this._A = a;
            this._B = b;
        }

        public Int64 A
        {
            get
            {
                return _A;
            }
        }

        public Int64 B
        {
            get
            {
                return _B;
            }
        }

        public Int64 Length
        {
            get
            {

                return B - A;
            }
        }
    }
}
