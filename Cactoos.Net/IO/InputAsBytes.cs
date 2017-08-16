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

        private InputAsBytes(Input source)
        {
            _source = source;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="InputAsBytes"/>.
        /// </summary>
        /// <param name="stream">The input.</param>
        public InputAsBytes(Stream stream): this(new Input(stream))
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="InputAsBytes"/>.
        /// </summary>
        /// <param name="input">The input.</param>
        public InputAsBytes(IInput input): this(new Input(input))
        {

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
