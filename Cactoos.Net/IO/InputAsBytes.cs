using System.IO;
using System.Linq;

namespace Cactoos.IO
{
    /// <summary>
    /// Input as bytes.
    /// </summary>
    public class InputAsBytes : IBytes
    {
        Input _source;

        /// <summary>
        /// Initializes a new instance of <see cref="InputAsBytes"/>.
        /// </summary>
        /// <param name="stream">The input.</param>
        public InputAsBytes(Stream stream)
        {
            _source = new Input(stream);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="InputAsBytes"/>.
        /// </summary>
        /// <param name="input">The input.</param>
        public InputAsBytes(IInput input)
        {
            _source = new Input(input);
        }

        /// <summary>
        /// Gets the bytes.
        /// </summary>
        /// <returns>The bytes.</returns>
        public byte[] Bytes()
        {
            return _source.ToArray();
        }
    }
}
