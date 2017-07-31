using Cactoos.Text;
using System.IO;

namespace Cactoos.IO
{
    /// <summary>
    /// IBytes as input.
    /// </summary>
    public class ByteInput : IInput
    {
        IBytes _source;

        /// <summary>
        /// Initializes a new instance of <see cref="ByteInput"/>.
        /// </summary>
        /// <param name="source">Source string.</param>
        public ByteInput(string source) : this(new TextBytes(source))
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="ByteInput"/>.
        /// </summary>
        /// <param name="source">Source bytes.</param>
        public ByteInput(byte[] source) : this(new ByteArray(source))
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="ByteInput"/>.
        /// </summary>
        /// <param name="source">Source <see cref="IBytes"/>.</param>
        public ByteInput(IBytes source)
        {
            _source = source;
        }

        /// <summary>
        /// Get stream value
        /// </summary>
        /// <returns>Stream</returns>
        public Stream Stream()
        {
            return new MemoryStream(_source.Bytes());
        }
    }
}
