using System;
using System.Threading.Tasks;

namespace Cactoos.IO.Async
{
    public class SingleByteAsyncEnumerator : IAsyncEnumerator<byte>
    {
        IAsyncEnumerator<byte[]> _source;
        bool _started;
        byte[] current;
        short size;
        short position;

        public SingleByteAsyncEnumerator(IAsyncEnumerator<byte[]> source)
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

        object IAsyncEnumerator.Current => Current;

        public void Dispose()
        {
            _source.Dispose();
        }

        public async Task<bool> MoveNextAsync()
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
                moveNext = await _source.MoveNextAsync().ConfigureAwait(false)   ;
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
