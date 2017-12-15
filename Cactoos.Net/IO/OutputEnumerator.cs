using System.IO;
using System.Collections.Generic;
using System;
using System.Collections;




namespace Cactoos.IO
{
    /// <summary>
    /// The enumerator for <see cref="Output"/>.
    /// </summary>
    public class OutputEnumerator : IEnumerator<byte[]>
    {
        private Stream _output;
        private int _step;
        private IEnumerator<byte> _source;
        private byte[] buffer;
        private short position;
        private bool started;

        public OutputEnumerator(IEnumerable<byte> from, Stream output, int step)
        {
            _source = from.GetEnumerator();
            _output = output;
            _step = step;
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

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _output.Dispose();
        }

        public bool MoveNext()
        {
            if (!started)
            {
                started = true;
            }
            return MoveNextCore();
        }

        public void Reset()
        {
            position = 0;
            _output.Position = 0;
        }

        internal bool MoveNextCore()
        {
            bool moveNext = _output.CanWrite;

            buffer = new byte[_step];
            for (int i = 0; i < _step; i++)
            {
                moveNext &= _source.MoveNext();
                buffer[i] = _source.Current;
            }

            if (moveNext)
            {
                _output.Write(buffer, 0, _step);
            }
            return moveNext;
        }
    }
}
