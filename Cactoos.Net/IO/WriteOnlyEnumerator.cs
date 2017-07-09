using System;
using System.Collections;
using System.Collections.Generic;

namespace Cactoos.IO
{
    /// <summary>
    /// Allows only to enumerate a sequence, but not read from it.
    /// </summary>
    /// <typeparam name="T">The type of objects to enumerate.</typeparam>
    public class WriteOnlyEnumerator<T> : IEnumerator<T>
    {
        IEnumerator<T> _source;

        public WriteOnlyEnumerator(IEnumerator<T> source)
        {
            _source = source;
        }

        public T Current => throw new NotSupportedException("Cant read Current in write-only enumerator");

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _source.Dispose();
        }

        public bool MoveNext()
        {
            return _source.MoveNext();
        }

        public void Reset()
        {
            _source.Reset();
        }
    }
}
