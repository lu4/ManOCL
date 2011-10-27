using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ManOCL.IO
{
    // Absolutely not thread safe
    public class StreamMerge : Stream
    {
        Stream[] Streams;
        
        bool[] Dirty; // This flags show if the corresponding Stream may need flushing

        bool Readable, Writable, Seekable;
        long position, length;
        long LocalPosition, CurrentStreamIndex;
        
        public StreamMerge(params Stream[] streams)
        {
            Streams = streams;
            
            Dirty = new bool[streams.Length];
            for (int i = 0; i < Dirty.Length; i++)
                Dirty[i] = true; // We don't know flush status

            length = 0;
            position = 0;
            streams[0].Position = 0;
            
            Readable = Writable = Seekable = true;
            foreach (Stream s in streams)
            {
                length += s.Length;
                if (!s.CanRead) Readable = false;
                if (!s.CanWrite) Writable = false;
                if (!s.CanSeek) Seekable = false;
            }
        }

        public override bool CanRead
        {
            get { return Readable; }
        }

        public override bool CanSeek
        {
            get { return Seekable; }
        }

        public override bool CanWrite
        {
            get { return Writable; }
        }

        public override void Flush()
        {
            if (!CanWrite)
                throw new NotSupportedException("This stream is readonly");
            
            for (int i = 0; i < Dirty.Length; i++)
            {
                if (Dirty[i])
                {
                    Streams[i].Flush();
                    Dirty[i] = false;
                }
            }
        }

        public override long Length
        {
            get 
            {
                return length;
            }
        }

        public override long Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                Seek(value, SeekOrigin.Begin);
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin: position = offset;
                    break;
                case SeekOrigin.Current: position += offset;
                    break;
                case SeekOrigin.End: position = Length+offset;
                    break;
            }

            LocalPosition = Position;
            CurrentStreamIndex = 0;
            while ((CurrentStreamIndex < Streams.Length-1) && 
                (LocalPosition >= Streams[CurrentStreamIndex].Length))
            {
                CurrentStreamIndex++;
                LocalPosition -= Streams[CurrentStreamIndex].Length;
            }
            Streams[CurrentStreamIndex].Position = LocalPosition;

            return Position;
        }

        // This is mixed read/write logic. Nothing beautiful, but avoids 
        // copy/paste in Read and Write. They are very similar
        private int IterateOverStreams(byte[] buffer, int offset, int count, bool read)
        {
            int CurrentBufferOffset = offset;
            int BytesLeft = count;
            int BytesProcessed = 0;

            while (true)
            {
                long CurrentStreamLength = Streams[CurrentStreamIndex].Length;
                Streams[CurrentStreamIndex].Position = LocalPosition;
                if (!read)
                    Dirty[CurrentStreamIndex] = true;

                if ((CurrentStreamIndex == Streams.Length - 1)
                    || (CurrentStreamLength - LocalPosition >= BytesLeft))
                {
                    if (read)
                        BytesProcessed += Streams[CurrentStreamIndex].Read(buffer, CurrentBufferOffset, BytesLeft);
                    else
                    {
                        BytesProcessed += BytesLeft;
                        Streams[CurrentStreamIndex].Write(buffer, CurrentBufferOffset, BytesLeft);
                    }
                    LocalPosition = Streams[CurrentStreamIndex].Position;
                    break;
                }
                else
                {
                    int JustBytesProcessed;
                    if (read)
                        JustBytesProcessed = Streams[CurrentStreamIndex].Read(buffer, CurrentBufferOffset,
                          (int)(CurrentStreamLength - LocalPosition));
                    else
                    {
                        JustBytesProcessed = (int)(CurrentStreamLength - LocalPosition);
                        Streams[CurrentStreamIndex].Write(buffer, CurrentBufferOffset,
                            JustBytesProcessed);
                    }
                    BytesProcessed += JustBytesProcessed;
                    BytesLeft -= JustBytesProcessed;
                    CurrentBufferOffset += JustBytesProcessed;
                    LocalPosition = 0;
                    CurrentStreamIndex++;
                }
            }
            Seek(Position + count, SeekOrigin.Begin); // Simple solution. Needs to be checked and debugged
            return BytesProcessed;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return IterateOverStreams(buffer, offset, count, true);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            IterateOverStreams(buffer, offset, count, false);
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException("This operation is not yet specified");
            /*
             *  A few cases need to be specified
             *  1. Length is bigger than current length. Should we extend the last stream? 
             *      It is supported if the last internal stream is expandable. 
             *      If not, this internal stream throws exception. It is done automatically on write,
             *      not through this method. We need to think more how to implement this method
             *
             *  2. Length is less than currenty length. Should we throw away some streams if required.
             *      Have now idea how to deal with this. Strictly speaking I can throw away some of the 
             *      streams, but should I close them? Shrinking last stream also depends on resizability
             *      of the internal stream.
             *  */
        }
    }
}
