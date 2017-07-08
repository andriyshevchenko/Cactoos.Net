using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

namespace Cactoos.IO
{
    public class InputAsBytes : IBytes
    {
        InputCollection enumerator;

        public InputAsBytes(Stream stream)
        {
            enumerator = new InputCollection(stream);
        }


        public InputAsBytes(IInput input)
        {
            enumerator = new InputCollection(input);
        }

        public byte[] Bytes()
        {
            return enumerator.ToArray();
        }
    }

    public class InputCollection : IEnumerable<byte>, IDisposable
    {
        private Stream _stream;

        public InputCollection(Stream stream)
        {
            _stream = stream;
        }

        public InputCollection(IInput stream) : this(stream.Stream())
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
