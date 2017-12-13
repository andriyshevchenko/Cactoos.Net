using Cactoos.Scalar;
using System;

namespace Cactoos.IO
{
    /// <summary>
    /// The bytes of float.
    /// </summary>
    public class FloatBytes : IBytes
    {
        private IScalar<float> _source;

        /// <summary>
        /// Initializes a new instance of  <see cref="FloatBytes"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public FloatBytes(IScalar<float> source)
        {
            _source = source;
        }


        /// <summary>
        /// Initializes a new instance of  <see cref="FloatBytes"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public FloatBytes(float source) : this(new ScalarOf<float>(source))
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
