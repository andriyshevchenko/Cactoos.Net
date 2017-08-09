using System;
using System.IO;

namespace Cactoos.IO.Async
{
    /// <summary>
    /// Reads a bytes asynchronously one-by-one from <see cref="Stream"/> or <see cref="IInput"/>.
    /// </summary>
    public class AsyncInput : IAsyncEnumerable<byte>, IDisposable
    {
        private Stream _stream;

        /// <summary>
        /// Initializes a new instance of <see cref="AsyncInput"/>.
        /// </summary>
        /// <param name="stream">Stream to read from.</param>
        public AsyncInput(Stream stream)
        {
            _stream = stream;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="AsyncInput"/>.
        /// </summary>
        /// <param name="stream">AsyncInput to read from.</param>
        public AsyncInput(IInput stream) : this(stream.Stream())
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
        public IAsyncEnumerator<byte> GetEnumerator()
        {
            return new SingleByteAsyncEnumerator(
                       new AsyncInputEnumerator(_stream, 1)
                   );
        }

        IAsyncEnumerator IAsyncEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
