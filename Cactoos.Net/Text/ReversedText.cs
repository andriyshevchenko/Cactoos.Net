using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cactoos.Text
{
    public class ReversedText : IText
    {
        private IText _source;

        public ReversedText(IText source)
        {
            _source = source;
        }

        public ReversedText(string source) : this(new Cactoos.Text.Text(source))
        {

        }

        public string String()
        {
            var builder = new StringBuilder();
            var original = _source.String();
            for (int i = original.Length - 1; i >= 0; i--)
            {
                builder.Append(original[i]);
            }
            return builder.ToString();
        }
    }
}
