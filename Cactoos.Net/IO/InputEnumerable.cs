using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

namespace Cactoos.IO
{
    public class InputAsBytes : IBytes
    {
        InputEnumerable enumerator;

        public InputAsBytes(Stream stream)
        {
            enumerator = new InputEnumerable(stream);
        }


        public InputAsBytes(IInput input)
        {
            enumerator = new InputEnumerable(input);
        }

        public byte[] Bytes()
        {
            return enumerator.ToArray();
        }
    }

    public class InputEnumerable : IEnumerable<byte>, IDisposable
    {
        private Stream _stream;

        public InputEnumerable(Stream stream)
        {
            _stream = stream;
        }

        public InputEnumerable(IInput stream) : this(stream.Stream())
        {
        }

        public void Dispose()
        {
            _stream.Dispose();
        }

        public IEnumerator<byte> GetEnumerator()
        {
            return new SingleByteEnumerator(
                       new InputEnumerator(_stream, 1)
                   );
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
