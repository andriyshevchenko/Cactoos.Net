using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Cactoos.Text
{
    public class BytesAsText : IText
    {
        IBytes _source;

        public BytesAsText(IBytes source)
        {
            _source = source;
        }

        public BytesAsText(byte[] source): this(new ByteArray(source))
        {

        }

        public BytesAsText(IEnumerable<byte> source) : this(new ByteArray(source))
        {

        }

        public string String()
        { 
            return Convert.ToBase64String(_source.Bytes(), Base64FormattingOptions.InsertLineBreaks);
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
