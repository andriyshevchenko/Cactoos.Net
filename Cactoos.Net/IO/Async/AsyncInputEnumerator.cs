using InputValidation;
using System;
using System.IO;
using System.Threading.Tasks;

using static System.Collections.Generic.Create;

namespace Cactoos.IO.Async
{
    public class AsyncInputEnumerator : IAsyncEnumerator<byte[]>
    {
        private Stream _target;
        private byte[] buffer;
        private bool _started;
        private int _step;

        public AsyncInputEnumerator(Stream from, int step)
        {
            _target = from;
            _target.Position = 0;
            _step = step.CheckIfNatural(nameof(step));
            buffer = array<byte>(_step);
        }

        public byte[] Current
        {
            get
            {
                if (_started)
                {
                    return buffer;
                }
                throw new InvalidOperationException("Enumeration hasn't started");
            }
        }

        object IAsyncEnumerator.Current => Current;

        public void Dispose()
        {
            _target.Dispose();
        }

        public async Task<bool> MoveNextAsync()
        {
            if (!_started)
            {
                _started = true;
            }
            bool canMoveNext = _target.Length > _target.Position;
            if (canMoveNext)
            {
                await _target.ReadAsync(buffer, 0, _step).ConfigureAwait(false);
            }
            return canMoveNext;
        }

        public void Reset()
        {
            _target.Position = 0;
        }
    }
}
