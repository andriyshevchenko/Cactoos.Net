using System;
using System.Collections.Generic;
using System.Collections;

namespace Cactoos.IO
{
    public class SingleByteEnumerator : IEnumerator<byte>
    {
        IEnumerator<byte[]> _source;
        bool _started;
        byte[] current;
        short size;
        short position;

        public SingleByteEnumerator(IEnumerator<byte[]> source)
        {
            _source = source;
            position = 0;
        }

        public byte Current
        {
            get
            {
                if (_started)
                {
                    return current[position];
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
            if (!_started)
            {
                _started = true;
            }
            bool moveNext = true;
            if (position < size - 1)
            {
                position++;
            }
            else
            {
                position = 0;
                moveNext = _source.MoveNext();
                if (moveNext)
                {
                    current = _source.Current;
                    size = (short)current.Length;
                }
            }

            return moveNext; 
        }

        public void Reset()
        {
            _source.Reset();
        }
    }
}
