using Cactoos.Scalar;
using System;

namespace Cactoos.IO
{
    /// <summary>
    /// The bytes of double.
    /// </summary>
    public class DoubleBytes : IBytes
    {
        private IScalar<double> _source;

        /// <summary>
        /// Initializes a new instance of  <see cref="DoubleBytes"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public DoubleBytes(IScalar<double> source)
        {
            _source = source;
        }


        /// <summary>
        /// Initializes a new instance of  <see cref="DoubleBytes"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public DoubleBytes(double source) : this(new ScalarOf<double>(source))
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
