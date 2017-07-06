using Cactoos.Text;
using System.IO;

namespace Cactoos.IO
{
    /// <summary>
    /// IBytes as IInput
    /// </summary>
    public class ByteInput : IInput
    {
        IBytes _source;

        public ByteInput(string source) : this(new TextBytes(source))
        {

        }

        public ByteInput(byte[] source) : this(new ByteArray(source))
        {

        }

        /// <summary>
        /// Initializes a new instance of ByteInput
        /// </summary>
        /// <param name="source">Source IBytes</param>
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
