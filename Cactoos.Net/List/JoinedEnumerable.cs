using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cactoos.List
{
    public class JoinedEnumerable<T> : IEnumerable<T>
    {
        IEnumerable<IEnumerable<T>> _source;

        public JoinedEnumerable(IEnumerable<IEnumerable<T>> source)
        {
            _source = source;
        }

        public JoinedEnumerable(params IEnumerable<T>[] source)
            : this(source.AsEnumerable())
        {
        }

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
