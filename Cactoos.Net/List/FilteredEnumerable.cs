using System;
using System.Collections;
using System.Collections.Generic;

namespace Cactoos.List
{
    public partial class FilteredEnumerable<T> : IEnumerable<T>
    {
        private IEnumerable<T> _source;
        private Func<T, bool> _predicate;

        public FilteredEnumerable(IEnumerable<T> source, Func<T, bool> predicate)
        {
            _source = source;
            _predicate = predicate;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new FilteringEnumerator<T>(_source, _predicate);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
