using System;
using System.Collections;
using System.Collections.Generic;
using static System.Functional.FlowControl;
using static System.Collections.Generic.Create;

namespace Cactoos.List
{
    public class JoinEnumerator<T> : IEnumerator<T>
    {
        private IEnumerator<T>[] _source;
        private T current;
        private short currentEnumeratorIdx;
        private short length;
        private bool started;

        public JoinEnumerator(IEnumerable<IEnumerable<T>> source) : this(array(source, ien => ien.GetEnumerator()))
        {

        }

        public JoinEnumerator(params IEnumerator<T>[] source)
        {
            _source = source;
            currentEnumeratorIdx = 0;
            length = (short)_source.Length;
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
            dispose(_source);
        }

        public bool MoveNext()
        {
            if (!started)
            {
                started = true;
            }

            Tuple<bool,T> advance(IEnumerator<T>[] src, short index)
            {
                var etr = src[index];
                bool moveNext = etr.MoveNext();
                var current = moveNext ? etr.Current : default(T); 
                return Tuple.Create(moveNext, current);
            }

            var advanced = advance(_source, currentEnumeratorIdx);
            bool canMoveNext = advanced.Item1;

            if (canMoveNext)
            {
                current = advanced.Item2;
            }
            else if (currentEnumeratorIdx < length - 1)
            {
                currentEnumeratorIdx++;

                advanced = advance(_source, currentEnumeratorIdx);
                canMoveNext = advanced.Item1;
                if (canMoveNext)
                {
                    current = advanced.Item2;
                }
            }
            else
            {
                canMoveNext = false;
            }

            return canMoveNext;
        }

        public void Reset()
        {
            for (int i = 0; i < _source.Length; i++)
            {
                _source[i].Reset();
            }
        }
    }
}
