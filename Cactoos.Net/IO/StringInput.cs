using Cactoos.Text;
using System.IO;

namespace Cactoos.IO
{
    /// <summary>
    /// The string input.
    /// </summary>
    public class StringInput : IInput
    {
        string _source;

        /// <summary>
        /// Initializes a new instance of <see cref="StringInput"/>. 
        /// </summary>
        /// <param name="source">The source.</param>
        public StringInput(string source)
        {
            _source = source;
        }

        /// <summary>
        /// Gets the stream.
        /// </summary>
        /// <returns>The stream.</returns>
        public Stream Stream()
        {
            return new ByteInput(new TextBytes(_source)).Stream();
        }
    }
}
