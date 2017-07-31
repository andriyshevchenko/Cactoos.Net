using System.IO;

namespace Cactoos.IO
{
    public class TextInput : IInput
    {
        private IText _source;

        public TextInput(IText source)
        {
            _source = source;
        }

        public TextInput(string source) : this(new Text.Text(source))
        {

        }

        public Stream Stream()
        {
            return new StringInput(_source.String()).Stream();
        }
    }
}
