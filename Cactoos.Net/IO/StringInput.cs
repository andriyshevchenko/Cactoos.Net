using Cactoos.Text;
using System.IO;

namespace Cactoos.IO
{
    public class StringInput : IInput
    {
        string _source;

        public StringInput(string source)
        {
            _source = source;
        }

        public Stream Stream()
        {
            return new ByteInput(new TextBytes(_source)).Stream();
        }
    }
}
