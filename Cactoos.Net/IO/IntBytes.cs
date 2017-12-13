using Cactoos.Scalar;
using System;

namespace Cactoos.IO
{
    /// <summary>
    /// The bytes of integer.
    /// </summary>
    public class IntBytes : IBytes
    {
        private IScalar<int> _source;

        /// <summary>
        /// Initializes a new instance of  <see cref="IntBytes"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public IntBytes(IScalar<int> source)
        {
            _source = source;
        }


        /// <summary>
        /// Initializes a new instance of  <see cref="IntBytes"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public IntBytes(int source) : this(new ScalarOf<int>(source))
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
