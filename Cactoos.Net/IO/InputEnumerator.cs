using System.IO;
using System;
using System.Collections.Generic;
using System.Collections;




namespace Cactoos.IO
{
    public class InputEnumerator : IEnumerator<byte[]>
    {
        private Stream _target;
        private byte[] buffer; 
        private bool _started;
        private int _step;

        public InputEnumerator(Stream from, int step)
        {
            _target = from;
            _target.Position = 0;
            _step = step;
            buffer = new byte[_step];
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

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _target.Dispose();
        }

        public bool MoveNext()
        {
            if (!_started)
            {
                _started = true;
            }
            bool canMoveNext = _target.Length > _target.Position;
            if (canMoveNext)
            {
                _target.Read(buffer, 0, _step);
            }
            return canMoveNext;
        }

        public void Reset()
        {
            _target.Position = 0;
        } 
    }
}
