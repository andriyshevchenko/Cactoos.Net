using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Cactoos.IO
{
    public class InputAsBytes : IBytes
    {
        InputAsEnumerable enumerator;

        public InputAsBytes(Stream stream)
        {
            enumerator = new InputAsEnumerable(stream);
        }


        public InputAsBytes(IInput input)
        {
            enumerator = new InputAsEnumerable(input);
        }

        public byte[] Bytes()
        {
            return enumerator.ToArray();
        }
    }

    public class InputAsEnumerable : IEnumerable<byte>
    {
        private Stream _stream;

        public InputAsEnumerable(Stream stream)
        {
            _stream = stream;
        }

        public InputAsEnumerable(IInput stream) : this(stream.Stream())
        {
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
