using Cactoos.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cactoos.IO.Async
{
    /// <summary>
    /// Reads a bytes one-by-one asynchronously from first source of data(<see cref="Stream"/>, <see cref="IInput"/>, <see cref="IEnumerable{T}"/>)
    /// and writes them asynchronously to second(<see cref="Stream"/>, <see cref="IOutput"/>).
    /// </summary>
    public partial class AsyncOutput : IAsyncEnumerable<byte>, IDisposable
    {
        private Stream _output;
        private DisposableWrap<IEnumerable<byte>> _source;

        /// <summary>
        /// Initializes a new instance of <see cref="AsyncOutput"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="output">Stream to write to.</param>
        public AsyncOutput(IEnumerable<byte> source, Stream output)
        {
            _source = new DisposableWrap<IEnumerable<byte>>(source);
            _output = output;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="AsyncOutput"/>. 
        /// </summary>
        /// <param name="from">Stream to read from.</param>
        /// <param name="to">Stream to write to.</param>
        public AsyncOutput(Stream from, Stream to)
            : this(new Input(from), to)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="AsyncOutput"/>.
        /// </summary>
        /// <param name="from">Input to read from.</param>
        /// <param name="to">AsyncOutput to write to.</param>
        public AsyncOutput(IInput from, IOutput to)
            : this(new Input(from.Stream()), to.Stream())
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="AsyncOutput"/>. 
        /// </summary>
        /// <param name="from">String to read from.</param>
        /// <param name="to">AsyncOutput to write to.</param>
        public AsyncOutput(string from, IOutput to) : this(new StringInput(from), to)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="AsyncOutput"/>. 
        /// </summary>
        /// <param name="from">Text to read from.</param>
        /// <param name="to">AsyncOutput to write to.</param>
        public AsyncOutput(IText from, IOutput to) : this(new TextInput(from), to)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="AsyncOutput"/>. 
        /// </summary>
        /// <param name="from">Bytes to read from.</param>
        /// <param name="to">AsyncOutput to write to.</param>
        public AsyncOutput(IBytes from, IOutput to) : this(new ByteInput(from), to)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="AsyncOutput"/>. 
        /// </summary>
        /// <param name="from">Bytes to read from.</param>
        /// <param name="encoding">The input encoding.</param>
        /// <param name="to">AsyncOutput to write to.</param>
        public AsyncOutput(IBytes from, Encoding encoding, IOutput to) : this(new BytesText(from, encoding), to)
        {

        }

        /// <summary>
        /// Returns a new enumerator.
        /// </summary>
        /// <returns>New enumerator.</returns>
        public IAsyncEnumerator<byte> GetEnumerator()
        {
            return new SingleByteAsyncEnumerator(
                new AsyncOutputEnumerator(_source.Value(), _output, 1)
            );
        }

        IAsyncEnumerator IAsyncEnumerable.GetEnumerator()
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
