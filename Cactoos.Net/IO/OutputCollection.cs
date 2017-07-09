using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Cactoos.IO
{
    /// <summary>
    /// Reads a bytes one-by-one from first source of data(<see cref="Stream"/>, <see cref="IInput"/>, <see cref="IEnumerable{T}"/>)
    /// and writes them to second(<see cref="Stream"/>, <see cref="IOutput"/>)
    /// </summary>
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
            : this(new InputCollection(from), to)
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
            return new WriteOnlyEnumerator<byte>(
                       new SingleByteEnumerator(
                           new OutputEnumerator(_source, _output, 1)
                       )
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
