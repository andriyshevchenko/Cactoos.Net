using System;
using System.IO;
using System.Text;

namespace Cactoos.IO
{
    public class ConsoleOutput : IOutput
    {
        private Encoding _encoding;

        public ConsoleOutput(Encoding encoding)
        {
            _encoding = encoding;
        }

        public class ConsoleOutputStream :Stream
        {
            private Encoding _encoding;
            private MemoryStream _stream = new MemoryStream();

            public ConsoleOutputStream(Encoding enc)
            {
                _encoding = enc;
            }

            public override bool CanRead => _stream.CanRead;

            public override bool CanSeek => _stream.CanSeek;

            public override bool CanWrite => _stream.CanWrite;

            public override long Length => _stream.Length;

            public override long Position { get => _stream.Position; set => _stream.Position = value; }

            public override void Flush()
            {
                _stream.Flush();
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException("Cant read from output stream");
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
                char[] cString = _encoding.GetChars(buffer);
                _stream.Write(buffer, offset, count);
                Console.Write(cString);
            }
        }

        public Stream Stream()
        {
            return new ConsoleOutputStream(_encoding);
        }
    }
}
