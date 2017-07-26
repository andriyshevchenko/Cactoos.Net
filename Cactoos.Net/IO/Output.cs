using InputValidation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Cactoos.IO
{
    /// <summary>
    /// Reads a bytes one-by-one from first source of data(<see cref="Stream"/>, <see cref="IInput"/>, <see cref="IEnumerable{T}"/>)
    /// and writes them to second(<see cref="Stream"/>, <see cref="IOutput"/>).
    /// </summary>
    public class Output : IEnumerable<byte>, IDisposable
    {
        private Stream _output;
        private DisposableWrap<IEnumerable<byte>> _source;

        /// <summary>
        /// Acts as a raii guard, to dispose _source when needed.
        /// </summary>
        /// <typeparam name="T">Type of item to capture.</typeparam>
        struct DisposableWrap<T> : IDisposable
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


        /// <summary>
        /// Initializes a new instance of <see cref="Output"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="output">Stream to write to.</param>
        public Output(IEnumerable<byte> source, Stream output)
        {
            _source = new DisposableWrap<IEnumerable<byte>>(source);
            _output = output;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Output"/>. 
        /// </summary>
        /// <param name="from">Stream to read from.</param>
        /// <param name="to">Stream to write to.</param>
        public Output(Stream from, Stream to)
            : this(new Input(from), to)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="Output"/>.
        /// </summary>
        /// <param name="from">Input to read from.</param>
        /// <param name="to">Output to write to.</param>
        public Output(IInput from, IOutput to)
            : this(new Input(from.Stream()), to.Stream())
        {

        }

        /// <summary>
        /// Returns a new enumerator.
        /// </summary>
        /// <returns>New enumerator.</returns>
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

        /// <summary>
        /// Will dispose streams it uses.
        /// </summary>
        public void Dispose()
        {
            _output.Dispose();
            _source.Dispose();
        }
    }
}
