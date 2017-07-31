using System.IO;

namespace Cactoos.IO
{
    /// <summary>
    /// The text input.
    /// </summary>
    public class TextInput : IInput
    {
        private IText _source;

        /// <summary>
        /// Initializes a new instance of <see cref="TextInput"/>. 
        /// </summary>
        /// <param name="source">The source.</param>
        public TextInput(IText source)
        {
            _source = source;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextInput"/>. 
        /// </summary>
        /// <param name="source">The source.</param>
        public TextInput(string source) : this(new Text.Text(source))
        {

        }


        /// <summary>
        /// Gets the stream.
        /// </summary>
        /// <returns>The stream.</returns>
        public Stream Stream()
        {
            return new StringInput(_source.String()).Stream();
        }
    }
}
