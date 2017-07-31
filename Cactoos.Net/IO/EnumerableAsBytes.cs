using System.Collections.Generic;
using System.Linq;

namespace Cactoos.IO
{
    /// <summary>
    /// Enumerable as bytes.
    /// </summary>
    public class EnumerableAsBytes : IBytes
    {
        IEnumerable<byte> _source;

        /// <summary>
        /// Initializes a new instance of <see cref="EnumerableAsBytes"/>.
        /// </summary>
        /// <param name="source">The enumerable of chunks.</param>
        public EnumerableAsBytes(IEnumerable<byte[]> source)
        {
            _source = source.SelectMany(bt => bt);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="EnumerableAsBytes"/>.
        /// </summary>
        /// <param name="source">The enumerable.</param>
        public EnumerableAsBytes(IEnumerable<byte> source)
        {
            _source = source;
        }

        /// <summary>
        /// Converts it to byte array.
        /// </summary>
        /// <returns>The byte[] value.</returns>
        public byte[] Bytes()
        {
            return _source.ToArray();
        }
    }
}
