using System;
using System.Collections;
using System.Collections.Generic;

namespace Cactoos.List
{
    public class FilteringEnumerator<T> : IEnumerator<T>
    {
        private IEnumerator<T> _source;
        private Func<T, bool> _predicate;
        private T current;
        private bool started;

        public FilteringEnumerator(IEnumerable<T> source, Func<T, bool> predicate)
        {
            _source = source.GetEnumerator();
            _predicate = predicate;
        }

        public T Current
        {
            get
            {
                if (started)
                {
                    return current;
                }
                throw new InvalidOperationException("Enumeration hasn't started");
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _source.Dispose();
        }

        public bool MoveNext()
        {
            if (!started)
            {
                started = true;
            }

            bool canMoveNext = true;

            while (canMoveNext = _source.MoveNext())
            {
                if (_predicate(_source.Current))
                {
                    current = _source.Current;
                    break;
                }
            }
            return canMoveNext;
        }

        public void Reset()
        {
            _source.Reset();
        }
    }
}
