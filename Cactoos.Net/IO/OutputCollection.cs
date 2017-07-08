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

    public class OutputCollection : IEnumerable<byte>, IDisposable
    {
        private Stream _output;
        private IEnumerable<byte> _source;

        public OutputCollection(IEnumerable<byte> source, Stream output)
        {
            _source = source;
            _output = output;
        }

        public OutputCollection(Stream from, Stream to)
            : this(new InputCollection  (from), to)
        {

        }

        public OutputCollection(IInput from, IOutput to)
            : this(new InputCollection(from.Stream()), to.Stream())
        {

        }

        public OutputCollection()
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
