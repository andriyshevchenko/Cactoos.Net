namespace Cactoos.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Char array as input.
    /// </summary>
    public struct CharsInput : IInput
    {
        private Encoding _encoding;
        private char[] _source;

        /// <summary>
        /// Initializes a new instance of <see cref="CharsInput"/>.
        /// </summary>
        /// <param name="source">The char array.</param>
        /// <param name="encoding">The encoding.</param>
        public CharsInput(ref char[] source, Encoding encoding)
        {
            _encoding = encoding;
            _source = source;
        }

        /// <summary>
        /// Gets the stream.
        /// </summary>
        /// <returns>The stream.</returns>
        public Stream Stream()
        {
            return new ByteInput(_encoding.GetBytes(_source)).Stream();
        }
    }
}
