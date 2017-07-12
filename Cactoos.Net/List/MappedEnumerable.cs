using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            return _source.Select(_selector).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
