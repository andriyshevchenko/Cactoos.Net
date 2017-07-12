using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            return _source.Where(_predicate).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
