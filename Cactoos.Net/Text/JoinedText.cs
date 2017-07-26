using System.Collections.Generic;
using System.Linq;
using System.Text;

using static System.Collections.Generic.Create;

namespace Cactoos.Text
{
    public class JoinedText : IText
    {
        private IEnumerable<IText> _strings;
        private string _delimiter;

        public JoinedText(string delimiter, IEnumerable<string> strings)
            : this(delimiter, strings.Select(s => (IText)new Text(s)))
        {

        }

        public JoinedText(char delimiter, IEnumerable<string> strings) : this(delimiter.ToString(), strings)
        {

        }

        public JoinedText(string delimiter, params string[] strings) : this(delimiter, strings.AsEnumerable())
        {

        }

        public JoinedText(char delimiter, params string[] strings) : this(delimiter.ToString(), strings)
        {

        }

        public JoinedText(string delimiter, IEnumerable<IText> strings)
        {
            _delimiter = delimiter;
            _strings = strings;
        }

        public JoinedText(char delimiter, IEnumerable<IText> strings) : this(delimiter.ToString(), strings)
        {

        }

        public JoinedText(IText delimiter, IEnumerable<IText> strings) : this(delimiter.String(), strings)
        {

        }

        public string String()
        {
            var strings = _strings.ToArray();
            int length = strings.Length;

            var body = 
                part(strings, 0, length - 1)
                    .Aggregate(
                         new StringBuilder(),
                         (builder, text) => builder.Append(text.String()).Append(_delimiter)
                     );

            return body.Append(strings[length - 1].String())
                       .ToString();
        }
    }
}
