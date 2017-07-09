using System;
using System.Collections;
using System.Collections.Generic;

namespace Cactoos.List
{
    public class MappingEnumerator<T, TResult> : IEnumerator<TResult>
    {
        private IEnumerator<T> _source;
        private Func<T, TResult> _selector;
        private TResult current;
        private bool started;

        public MappingEnumerator(IEnumerable<T> source, Func<T, TResult> selector)
        {
            _source = source.GetEnumerator();
            _selector = selector;
        }

        public TResult Current
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

            bool canMoveNext = _source.MoveNext();
            if (canMoveNext)
            {
                current = _selector(_source.Current);
            }
            return canMoveNext;
        }

        public void Reset()
        {
            _source.Reset();
        }
    }
}
