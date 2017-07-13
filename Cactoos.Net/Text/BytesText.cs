using System.Collections.Generic;
using System.Text;

namespace Cactoos.Text
{
    public class BytesText : IText
    {
        IBytes _source;
        Encoding _encoding;

        public BytesText(IBytes source, Encoding encoding)
        {
            _source = source;
            _encoding = encoding;
        }

        public BytesText(byte[] source, Encoding encoding): this(new ByteArray(source), encoding)
        {

        }

        public BytesText(IEnumerable<byte> source, Encoding encoding) : this(new ByteArray(source), encoding)
        {

        }

        public string String()
        {
            return _encoding.GetString(_source.Bytes());
        }
    }
}
