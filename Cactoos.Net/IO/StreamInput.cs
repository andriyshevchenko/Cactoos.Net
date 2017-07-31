using System.IO;

namespace Cactoos.IO
{
    /// <summary>
    /// Stream input.
    /// </summary>
    public class StreamInput : IInput
    {
        private Stream _source;

        /// <summary>
        /// Initializes a new instance of <see cref="StreamInput"/>. 
        /// </summary>
        /// <param name="source">The source.</param>
        public StreamInput(Stream source)
        {
            _source = source;
        }

        /// <summary>
        /// Gets the stream.
        /// </summary>
        /// <returns>The stream.</returns>
        public Stream Stream()
        {
            return _source;
        }
    }
}
