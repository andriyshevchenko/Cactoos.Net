using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cactoos.IO
{
    public class StreamInput : IInput
    {
        private Stream _source;

        public StreamInput(Stream source)
        {
            _source = source;
        }

        public Stream Stream()
        {
            return _source;
        }
    }
}
