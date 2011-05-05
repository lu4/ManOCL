using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ManOCL.IO
{
    public class StreamSegment : Stream
    {
        private Int64 length;
        private Int64 position;
        private Stream BaseStream;
        private Int64Segment[] Segments;

        private int IterateOverStream(byte[] buffer, int offset, int count, bool read)
        {
            if (Position >= Length) return 0;
            if (!read && (Length - Position < count)) throw new IOException("Data cannon fit the stream");

            long LocalPosition = Position;
            int CurrentSegmentIndex = 0;
            while (LocalPosition >= Segments[CurrentSegmentIndex].Length)
            {
                CurrentSegmentIndex++;
                LocalPosition -= Segments[CurrentSegmentIndex].Length;
            }

            int CurrentBufferOffset = offset;
            int BytesLeft = count;
            int BytesProcessed = 0;


            while ((CurrentSegmentIndex < Segments.Length) && (BytesLeft > 0))
            {
                BaseStream.Position = Segments[CurrentSegmentIndex].A + LocalPosition;
                int BytesToRequest = (int)(Segments[CurrentSegmentIndex].Length - LocalPosition);
                int BytesJustProcessed;
                if (read)
                    BytesJustProcessed = BaseStream.Read(buffer, CurrentBufferOffset, BytesToRequest);
                else
                {
                    BaseStream.Write(buffer, CurrentBufferOffset, BytesToRequest);
                    BytesJustProcessed = BytesToRequest;
                }
                BytesLeft -= BytesJustProcessed;
                BytesProcessed += BytesJustProcessed;
                CurrentBufferOffset += BytesJustProcessed;
                LocalPosition = 0;
                CurrentSegmentIndex++;
            }

            Position += BytesProcessed;

            return BytesProcessed;
        }

        public StreamSegment(Stream stream, params Int64Segment[] segments)
        {
            Segments = segments;
            BaseStream = stream;

            length = 0;
            position = 0;

            foreach (Int64Segment segment in Segments)
            {
                length += segment.Length;
            }
        }

        public override bool CanRead
        {
            get { return BaseStream.CanRead; }
        }
        public override bool CanSeek
        {
            get { return BaseStream.CanSeek; }
        }
        public override bool CanWrite
        {
            get { return BaseStream.CanWrite; }
        }
        public override void Flush()
        {
            BaseStream.Flush();
        }
        public override long Length
        {
            get { return length; }
        }
        public override long Position
        {
            get
            {
                return position;
            }
            set
            {
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
                case SeekOrigin.End: position = Length + offset;
                    break;
            }

            return Position;
        }
        public override void SetLength(long value)
        {
            throw new NotSupportedException(
                "This class should not be used to modify the size of the stream");
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            return IterateOverStream(buffer, offset, count, true);
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            IterateOverStream(buffer, offset, count, false);
        }
    }
}
