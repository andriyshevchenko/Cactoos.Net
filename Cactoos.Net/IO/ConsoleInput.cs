using System;
using System.IO;

namespace Cactoos.IO
{
    public class ConsoleInput : IInput
    {
        public class ConsoleInputStream : Stream
        {
            private MemoryStream _stream = new MemoryStream();

            public override bool CanRead => true;

            public override bool CanSeek => _stream.CanSeek;

            public override bool CanWrite => false;

            public override long Length => long.MaxValue;

            public override long Position { get => _stream.Position; set => _stream.Position = value; }

            public override void Flush()
            {
                _stream.Flush();
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                int mod = 0;
                int div = count;
                int read;

                if (count > 4)
                {
                    mod = count % 4;
                    div = count - mod;

                    for (int i = 0; i < div; i += 4)
                    {
                        read = Console.Read();
                        buffer[i] = (byte)(read >> 24);
                        buffer[i + 1] = (byte)((read & 0xFFFFF) >> 16);
                        buffer[i + 2] = (byte)((read & 0xFFFF) >> 8);
                        buffer[i + 3] = (byte)(read & 0xFF);
                    }
                }

                read = Console.Read();
                buffer[div] = (byte)(read >> 24);

                if (mod > 0)
                {
                    buffer[div + 1] = (byte)((read & 0xFFFFF) >> 16);
                    if (mod > 1)
                    {
                        buffer[div + 2] = (byte)((read & 0xFFFF) >> 8);
                        if (mod > 2)
                        {
                            buffer[div + 3] = (byte)(read & 0xFF);
                        }
                    }
                }

                _stream.Write(buffer, 0, count);

                return count;
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                return _stream.Seek(offset, origin);
            }

            public override void SetLength(long value)
            {
                _stream.SetLength(value);
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException("Cant write to input stream");
            }
        }

        public Stream Stream()
        {
            return new ConsoleInputStream();
        }
    }
}
