using Cactoos.Scalar;
using System;

namespace Cactoos.IO
{
    /// <summary>
    /// The bytes of short.
    /// </summary>
    public class ShortBytes : IBytes
    {
        private IScalar<short> _source;

        /// <summary>
        /// Initializes a new instance of  <see cref="ShortBytes"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public ShortBytes(IScalar<short> source)
        {
            _source = source;
        }


        /// <summary>
        /// Initializes a new instance of  <see cref="ShortBytes"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public ShortBytes(short source) : this(new ScalarOf<short>(source))
        {

        }

        /// <summary>
        /// Gets the bytes.
        /// </summary>
        /// <returns>The bytes.</returns>
        public byte[] Bytes()
        {
            return BitConverter.GetBytes(_source.Value());
        }
    }
}
