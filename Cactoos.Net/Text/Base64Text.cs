using System;
using System.Collections.Generic;
using System.Text;

namespace Cactoos.Text
{
    /// <summary>
    /// Converts 64 byte string to 8 byte string
    /// </summary>
    public class Base64Text : IText
    {
        private IText _source;
        private Encoding _encoding;

        public Base64Text(IText source, Encoding encoding)
        {
            _source = source;
            _encoding = encoding;
        }

        public Base64Text(string source, Encoding encoding) : this(new Text(source), encoding)
        {

        }

        public string String()
        {
            return new BytesAsText(Convert.FromBase64String(_source.String()), _encoding).String();
        }
    }
}
