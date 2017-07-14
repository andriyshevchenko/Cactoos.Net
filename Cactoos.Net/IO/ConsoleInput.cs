using System;
using System.IO;

namespace Cactoos.IO
{
    public class ConsoleInput : IInput
    {
        public class ConsoleInputStream : Stream
        {
            private int last;
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
                int length = buffer.Length;
                count = count - length > 0 ? count : length;
                int mod = count % 4;
                int div = count / 4;
                
                if (count > 4)
                {
                    mod = count % 4;
                    div = count - mod;

                    for (int i = 0; i < div; i += 4)
                    {
                        last = Console.Read();
                        buffer[i] = (byte)(last >> 24);
                        buffer[i + 1] = (byte)((last & 0xFFFFF) >> 16);
                        buffer[i + 2] = (byte)((last & 0xFFFF) >> 8);
                        buffer[i + 3] = (byte)(last & 0xFF);
                    }
                }

                last = Console.Read();
                if (count == 1)
                {
                    buffer[0] = (byte)last;
                }
                if (count == 2)
                {

                }
                if (count == 3)
                {

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
