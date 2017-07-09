using System.IO;

namespace Cactoos.IO
{
    public class InputAsBytes : IBytes
    {
        InputCollection enumerator;

        public InputAsBytes(Stream stream)
        {
            enumerator = new InputCollection(stream);
        }


        public InputAsBytes(IInput input)
        {
            enumerator = new InputCollection(input);
        }

        public byte[] Bytes()
        {
            return enumerator.ToArray();
        }
    }
}
