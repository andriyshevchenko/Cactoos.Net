using System.IO;

namespace Cactoos.IO
{
    public class BytesAsOutput : IOutput
    {
        private Stream _source;

        public BytesAsOutput(byte[] source)
        {
            _source = new MemoryStream(source, true);
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
