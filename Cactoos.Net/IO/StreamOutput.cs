using System.IO;

namespace Cactoos.IO
{
    /// <summary>
    /// Stream as output.
    /// </summary>
    public class StreamOutput : IOutput 
    {
        private Stream _source;

        /// <summary>
        /// Initializes a new instance of <see cref="Output"/>. 
        /// </summary>
        ///<param name="source">The stream.</param>
        public StreamOutput(Stream source)
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
