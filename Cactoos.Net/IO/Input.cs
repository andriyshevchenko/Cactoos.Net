using System.IO;
using System.Collections.Generic;
using System.Collections;
using System;

namespace Cactoos.IO
{
    /// <summary>
    /// Reads a bytes one-by-one from <see cref="Stream"/> or <see cref="IInput"/>.
    /// </summary>
    public class Input : IEnumerable<byte>, IDisposable
    {
        private Stream _stream;

        /// <summary>
        /// Initializes a new instance of <see cref="Input"/>.
        /// </summary>
        /// <param name="stream">Stream to read from.</param>
        public Input(Stream stream)
        {
            _stream = stream;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Input"/>.
        /// </summary>
        /// <param name="stream">Input to read from.</param>
        public Input(IInput stream) : this(stream.Stream())
        {
        }

        /// <summary>
        /// Dispose a stream it uses.
        /// </summary>
        public void Dispose()
        {
            _stream.Dispose();
        }

        /// <summary>
        /// Returns a new enumerator.
        /// </summary>
        /// <returns>New enumerator.</returns>
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
