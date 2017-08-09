using Cactoos.List;
using InputValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using static System.Collections.Generic.Create;

namespace Cactoos.IO.Async
{ /// <summary>
  /// The enumerator for <see cref="AsyncOutput"/>.
  /// </summary>
    public class AsyncOutputEnumerator : IAsyncEnumerator<byte[]>
    {
        private Stream _output;
        private int _step;
        private IAsyncEnumerator<byte> _source;
        private byte[] buffer;
        private short position;
        private bool started;

        public AsyncOutputEnumerator(IEnumerable<byte> from, Stream output, int step)
            : this(new Async<byte>(from), output, step)
        {

        }

        public AsyncOutputEnumerator(IAsyncEnumerable<byte> from, Stream output, int step)
        {
            _source = from.GetEnumerator();
            _output = output;
            _step = step.CheckIfNatural(nameof(step));
        }

        public byte[] Current
        {
            get
            {
                if (started)
                {
                    return buffer;
                }
                throw new InvalidOperationException("Enumeration hasn't started");
            }
        }

        object IAsyncEnumerator.Current => Current;

        public void Dispose()
        {
            _output.Dispose();
        }

        public async Task<bool> MoveNextAsync()
        {
            if (!started)
            {
                started = true;
            }
            bool moveNext = _output.CanWrite;

            buffer = array<byte>(_step);
            for (int i = 0; i < _step; i++)
            {
                moveNext &= await _source.MoveNextAsync().ConfigureAwait(false);
                buffer[i] = _source.Current;
            }

            if (moveNext)
            {
                await _output.WriteAsync(buffer, 0, _step).ConfigureAwait(false);
            }
            return moveNext;
        }

        public void Reset()
        {
            position = 0;
            _output.Position = 0;
        }
    }
}
