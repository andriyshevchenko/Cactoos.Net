using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cactoos.List
{
    public class LimitedEnumerable<T> : IEnumerable<T>
    {
        private IEnumerable<T> _source;
        private int _items;

        class Enumerator : IEnumerator<T>
        {
            private IEnumerator<T> _source;
            private int _items;
            private T current;
            private int n;

            public Enumerator(IEnumerable<T> source, int items)
            {
                _source = source.GetEnumerator();
                _items = items;
                n = 0;
            }

            public T Current => current;

            object IEnumerator.Current => current;

            public void Dispose()
            {
                _source.Dispose();
            }

            public bool MoveNext()
            {
                bool canMoveNext = _source.MoveNext() && n < _items;
                if (canMoveNext)
                {
                    current = _source.Current;
                    n++;
                }
                return canMoveNext;
            }

            public void Reset()
            {
                _source.Reset();
            }
        }

        public LimitedEnumerable(IEnumerable<T> source, int items)
        {
            _source = source;
            _items = items;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _source.Take(_items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
