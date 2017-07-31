using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cactoos.List
{
    /// <summary>
    /// Concatenation of enumerables.
    /// </summary>
    /// <typeparam name="T">The types of the item.</typeparam>
    public class Concat<T> : IEnumerable<T>
    {
        private IEnumerable<T>[] _source;

        /// <summary>
        /// Initializes a new instance of <see cref="Concat{T}"/>.
        /// </summary>
        /// <param name="source">The sequences.</param>
        public Concat(params IEnumerable<T>[] source)
        {
            _source = source;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var first = _source[0];
            for (int i = 1; i < _source.Length; i++)
            {
                first = first.Concat(_source[i]);
            }
            return first.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
