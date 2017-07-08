using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cactoos.IO
{
    public class BytesAsOutput : IOutput
    {
        private Stream _source;

        public BytesAsOutput(byte[] source)
        {
            _source = new MemoryStream(source);
        }

        public BytesAsOutput(IBytes source) : this(source.Bytes())
        {

        }

        public Stream Stream()
        {
            return _source;
        }
    }
}
