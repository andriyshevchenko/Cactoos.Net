using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Cactoos.Text
{
    public class BytesAsText : IText
    {
        IBytes _source;
        Encoding _encoding;

        public BytesAsText(IBytes source, Encoding encoding)
        {
            _source = source;
            _encoding = encoding;
        }

        public BytesAsText(byte[] source, Encoding encoding): this(new ByteArray(source), encoding)
        {

        }

        public BytesAsText(IEnumerable<byte> source, Encoding encoding) : this(new ByteArray(source), encoding)
        {

        }

        public string String()
        {
            return _encoding.GetString(_source.Bytes());
        }

        public int CompareTo(IText other)
        {
            return String().CompareTo(other.String());
        }

        public bool Equals(IText other)
        {
            return String().Equals(other.String());
        }
    }
}
