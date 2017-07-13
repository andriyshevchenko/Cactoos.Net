using System.IO;
using System.Collections.Generic;
using System.Collections;
using System;

namespace Cactoos.IO
{
    /// <summary>
    /// Reads a bytes one-by-one from <see cref="Stream"/> or <see cref="IInput"/>
    /// </summary>
    public class Input : IEnumerable<byte>, IDisposable
    {
        private Stream _stream;

        public Input(Stream stream)
        {
            _stream = stream;
        }

        public Input(IInput stream) : this(stream.Stream())
        {
        }

        public void Dispose()
        {
            _stream.Dispose();
        }

        public IEnumerator<byte> GetEnumerator()
        {
            return new SingleByteEnumerator(
                       new InputEnumerator(_stream, 1)
                   );
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
