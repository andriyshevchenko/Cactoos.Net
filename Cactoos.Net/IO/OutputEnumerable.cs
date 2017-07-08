using System;
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

    public class OutputEnumerable : IEnumerable<byte>, IDisposable
    {
        private Stream _output;
        private IEnumerable<byte> _source;

        public OutputEnumerable(IEnumerable<byte> source, Stream output)
        {
            _source = source;
            _output = output;
        }

        public OutputEnumerable(Stream from, Stream to)
            : this(new InputEnumerable  (from), to)
        {

        }

        public OutputEnumerable(IInput from, IOutput to)
            : this(new InputEnumerable(from.Stream()), to.Stream())
        {

        }

        public OutputEnumerable()
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

        public void Dispose()
        {
            _output.Dispose();
        }
    }
}
