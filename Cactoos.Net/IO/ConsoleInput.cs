using System;
using System.IO;

namespace Cactoos.IO
{
    public class ConsoleInput : IInput
    {
        public class ConsoleInputStream : Stream
        {
            private int last;
            private byte current_byte;
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
                byte read_first_bt(int value) => (byte)(value >> 24);
                byte read_second_bt(int value) => (byte)((value & 0xFFFFF) >> 16);
                byte read_third_bt(int value) => (byte)((value & 0xFFFF) >> 8);
                byte read_fourth_bt(int value) => (byte)(last & 0xFF);

                int length = buffer.Length;

                if (count > length)
                {
                    count = length;
                }

                int mod = count % 4;
                int div = count / 4;
                
                if (count > 4)
                {
                    mod = count % 4;
                    div = count - mod;

                    for (int i = 0; i < div; i += 4)
                    {
                        last = Console.Read();
                        buffer[i] = read_first_bt(last);
                        buffer[i + 1] = read_second_bt(last);
                        buffer[i + 2] = read_third_bt(last);
                        buffer[i + 3] = read_fourth_bt(last);
                        current_byte = 4;
                    }
                }

                last = Console.Read();
                //decide which bytes to read depending on current_byte
                //read number=length of bytes

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
