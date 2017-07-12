using InputValidation;
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
        private DisposableWrap<IEnumerable<byte>> _source;

        /// <summary>
        /// Acts as a raii guard, to dispose _source when needed
        /// </summary>
        /// <typeparam name="T">Type of item to capture</typeparam>
        class DisposableWrap<T> : IDisposable
        {
            public T Item { get { return _wrapee; } }
            private T _wrapee;

            public DisposableWrap(T wrapee)
            {
                _wrapee = wrapee;
            }

            public void Dispose()
            {
                _wrapee.As<IDisposable>()?.Dispose();
            }
        }

        public Output(IEnumerable<byte> source, Stream output)
        {
            _source = new DisposableWrap<IEnumerable<byte>>(source);
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
                           new OutputEnumerator(_source.Item, _output, 1)
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
            _source.Dispose();
        }
    }
}
