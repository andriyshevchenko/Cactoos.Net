using System.Text;

namespace Cactoos.Text
{
    /// <summary>
    /// Text as bytes
    /// </summary>
    public class TextBytes : IBytes
    {
        Encoding _encoding;
        IText _source;

        /// <summary>
        /// Initializes a new instance of <see cref="TextBytes"/>
        /// </summary>
        /// <param name="source">Source IText</param>
        /// <param name="encoding">String encoding</param>
        public TextBytes(IText source, Encoding encoding)
        {
            _source = source;
            _encoding = encoding;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextBytes"/>
        /// </summary>
        /// <param name="source">Source IText</param>
        public TextBytes(IText source) : this(source, Encoding.UTF8)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="TextBytes"/>
        /// </summary>
        /// <param name="source">Source string</param>
        public TextBytes(string source) : this(new StringText(source))
        {

        }
        
        /// <summary>
        /// Converts it to byte array
        /// </summary>
        /// <returns>Byte value</returns>
        public byte[] Bytes()
        {
            return _encoding.GetBytes(_source.AsString());
        }
    }
}
