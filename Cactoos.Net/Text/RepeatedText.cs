using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cactoos.Text
{
    public class RepeatedText : IText
    {
        private IText _source;
        private int _times;

        public RepeatedText(IText source, int times)
        {
            _source = source;
            _times = times;
        }

        public RepeatedText(string source, int times) : this(new Cactoos.Text.Text(source), times)
        {

        }

        public string String()
        {
            string original = _source.String();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < _times; i++)
            {
                builder.Append(original);
            }
            return builder.ToString();
        }
    }
}
