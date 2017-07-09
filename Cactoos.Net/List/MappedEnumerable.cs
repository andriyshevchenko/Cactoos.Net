using System;
using System.Collections;
using System.Collections.Generic;

namespace Cactoos.List
{
    public class MappedEnumerable<T, TResult> : IEnumerable<TResult>
    {
        private IEnumerable<T> _source;
        private Func<T, TResult> _selector;

        public MappedEnumerable(IEnumerable<T> source, Func<T, TResult> selector)
        {
            _source = source;
            _selector = selector;
        }

        public IEnumerator<TResult> GetEnumerator()
        {
            return new MappingEnumerator<T, TResult>(_source, _selector);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
