using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ManOCL;

namespace ManOCL.IO
{
    public class DeviceBufferStream : Stream
    {
        public DeviceBuffer DeviceBuffer { get; private set; }

        public CommandQueue CommandQueue { get; private set; }

        public DeviceBufferStream(DeviceBuffer deviceBuffer)
        {
            this.DeviceBuffer = deviceBuffer;
            this.CommandQueue = CommandQueue.Default;
        }
        public DeviceBufferStream(DeviceBuffer deviceBuffer, CommandQueue commandQueue)
        {
            this.DeviceBuffer = deviceBuffer;
            this.CommandQueue = commandQueue;
        }

        public override bool CanRead
        {
            get
            {
                return true;
            }
        }
        public override bool CanSeek
        {
            get
            {
                return true;
            }
        }
        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }

        public override void Flush()
        {
        }
        public override long Length
        {
            get
            {
                return DeviceBuffer.Size;
            }
        }

        #region public override long Position { get; set; }
        private long _Position = 0;

        public override long Position
        {
            get
            {
                return _Position;
            }
            set
            {
                _Position = value;
            }
        }
        #endregion

        public override int Read(byte[] buffer, int offset, int count)
        {
            Int64 newPosition = _Position + count;
            Int64 overflow = Length - newPosition;

            count += (Int32)(overflow < 0 ? overflow : 0);

            DeviceBuffer.Read(buffer, offset, (Int32)_Position, count, CommandQueue, null);

            _Position += count;

            return count;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            if (origin == SeekOrigin.Begin)
            {
                return _Position = offset;
            }
            else if (origin == SeekOrigin.Current)
            {
                return _Position += offset;
            }
            else if (origin == SeekOrigin.End)
            {
                return _Position = Length + offset;
            }
            else
            {
                throw new ArgumentException(Resources.Invalid_SeekOrigin);
            }
        }

        public override void SetLength(long value)
        {
            throw new InvalidOperationException(Resources.DeviceBufferStream_SetLength_method_can_t_change_DeviceBuffer_size_because_it_is_a_fixed_size_object);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            DeviceBuffer.Write(buffer, offset, _Position, count, CommandQueue, null);

            _Position += count;
        }
    }
}