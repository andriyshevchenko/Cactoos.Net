using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cactoos.IO
{
    public class EnumerableAsBytes : IBytes
    {
        IEnumerable<byte> _source;

        public EnumerableAsBytes(IEnumerable<byte[]> source)
        {
            _source = source.SelectMany(bt => bt);
        }

        public EnumerableAsBytes(IEnumerable<byte> source)
        {
            _source = source;
        }

        public byte[] Bytes()
        {
            return _source.ToArray();
        }
    }

    public class OutputAsEnumerable : IEnumerable<byte>
    {
        private Stream _output;
        private IEnumerable<byte> _source;

        public OutputAsEnumerable(IEnumerable<byte> source, Stream output)
        {
            _source = source;
            _output = output;
        }

        public OutputAsEnumerable(Stream from, Stream to)
            : this(new InputAsEnumerable(from), to)
        {

        }

        public OutputAsEnumerable(IInput from, IOutput to)
            : this(new InputAsEnumerable(from.Stream()), to.Stream())
        {

        }

        public OutputAsEnumerable()
        {

        }

        public IEnumerator<byte> GetEnumerator()
        {
            return new SingleByteEnumerator(
                       new OutputEnumerator(_source, _output, 1)
                   );
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
