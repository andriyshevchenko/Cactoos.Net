using Cactoos.IO;
using System.IO;
using System.Text;

namespace Cactoos.Text
{
    public class InputText : IText
    {
        private IInput _source;
        private Encoding _encoding;

        public InputText(IInput source, Encoding encoding)
        {
            _source = source;
            _encoding = encoding;
        }

        public InputText(Stream source, Encoding encoding) : this(new StreamInput(source), encoding)
        {

        }

        public string String()
        {
            return new BytesText(new InputAsBytes(_source), _encoding).String();
        }
    }
}
