using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cactoos.List
{
    public class Mapped<T, TResult> : IEnumerable<TResult>
    {
        private IEnumerable<T> _source;
        private Func<T, TResult> _selector;

        public Mapped(IEnumerable<T> source, Func<T, TResult> selector)
        {
            _source = source;
            _selector = selector;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<TResult> GetEnumerator()
        {
            return _source.Select(_selector).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
