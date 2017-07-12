using System.IO;

namespace Cactoos.IO
{
    public class StreamOutput : IOutput 
    {
        private Stream _source;

        public StreamOutput(Stream source)
        {
            _source = source;
        }

        public Stream Stream()
        {
            return _source;
        }
    }
}
