using System.Collections;
using System.Collections.Generic;

namespace Cactoos.List
{
    public class Cycled<T> : IEnumerable<T>
    {
        class Enumerator : IEnumerator<T>
        {
            private T current;
            private int _n;
            private int n;
            private IEnumerator<T> _source;

            public Enumerator(IEnumerable<T> source, int repeat)
            {
                _source = source.GetEnumerator();
                _n = repeat;
                n = 1;
            }

            public T Current => current;

            object IEnumerator.Current => current;

            public void Dispose()
            {
                _source.Dispose();
            }

            public bool MoveNext()
            {
                bool canMoveNext = _source.MoveNext();
                if (canMoveNext)
                {
                    current = _source.Current;
                }
                else
                {
                    if (n < _n)
                    {
                        _source.Reset();
                        n++;
                        return MoveNext();
                    }
                }
                return canMoveNext;
            }

            public void Reset()
            {
                _source.Reset();
            }
        }

        private int _n;
        private IEnumerable<T> _source;

        public Cycled(IEnumerable<T> source, int repeat)
        {
            _source = source;
            _n = repeat;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(_source, _n);
        }

        IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
    }
}
