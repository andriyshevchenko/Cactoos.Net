using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cactoos.List
{
    public class Joined<T> : IEnumerable<T>
    {
        IEnumerable<IEnumerable<T>> _source;

        public Joined(IEnumerable<IEnumerable<T>> source)
        {
            _source = source;
        }

        public Joined(params IEnumerable<T>[] source)
            : this(source.AsEnumerable())
        {
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new JoinEnumerator<T>(_source);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
