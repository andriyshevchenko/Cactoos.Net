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
    public class Output : IEnumerable<byte>, IDisposable
    {
        private Stream _output;
        private IEnumerable<byte> _source;

        public Output(IEnumerable<byte> source, Stream output)
        {
            _source = source;
            _output = output;
        }

        public Output(Stream from, Stream to)
            : this(new Input(from), to)
        {

        }

        public Output(IInput from, IOutput to)
            : this(new Input(from.Stream()), to.Stream())
        {

        }

        public Output()
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
