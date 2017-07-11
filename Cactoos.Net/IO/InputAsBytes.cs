using System.IO;
using System.Linq;

namespace Cactoos.IO
{
    public class InputAsBytes : IBytes
    {
        Input _source;

        public InputAsBytes(Stream stream)
        {
            _source = new Input(stream);
        }


        public InputAsBytes(IInput input)
        {
            _source = new Input(input);
        }

        public byte[] Bytes()
        {
            return _source.ToArray();
        }
    }
}
