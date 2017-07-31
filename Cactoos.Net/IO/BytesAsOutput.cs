using System.IO;

namespace Cactoos.IO
{
    /// <summary>
    /// Bytes as output.
    /// </summary>
    public class BytesAsOutput : IOutput
    {
        private Stream _source;

        /// <summary>
        /// Initializes a new instance of <see cref="BytesAsOutput"/>.
        /// </summary>
        /// <param name="source">The source array.</param>
        public BytesAsOutput(byte[] source)
        {
            _source = new MemoryStream(source, true);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="BytesAsOutput"/>.
        /// </summary>
        /// <param name="source">The source bytes.</param>
        public BytesAsOutput(IBytes source) : this(source.Bytes())
        {

        }

        /// <summary>
        /// Get the stream value.
        /// </summary>
        /// <returns>The stream.</returns>
        public Stream Stream()
        {
            return _source;
        }
    }
}
