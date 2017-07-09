using System.IO;
using System.Linq;

namespace Cactoos.IO
{
    public class InputAsBytes : IBytes
    {
        InputCollection _source;

        public InputAsBytes(Stream stream)
        {
            _source = new InputCollection(stream);
        }


        public InputAsBytes(IInput input)
        {
            _source = new InputCollection(input);
        }

        public byte[] Bytes()
        {
            return _source.ToArray();
        }
    }
}
