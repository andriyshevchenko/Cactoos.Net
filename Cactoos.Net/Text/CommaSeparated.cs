using Cactoos.List;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cactoos.Text
{
    public struct CommaSeparated : IText
    {
        private IEnumerable<IText> _values;

        public CommaSeparated(IEnumerable<string> values)
            : this(new TextCollection(values))
        {

        }

        public CommaSeparated(IEnumerable<IText> values)
        {
            _values = values;
        }

        public string String()
        {
            StringBuilder builder = new StringBuilder();
            var values = _values.ToArray();
            int length = values.Length - 1;
            for (int i = 0; i < length; i++)
            {
                builder.Append(values[i].String())
                       .Append(',')
                       .Append(' ');
            }
            if (length > -1)
            {
                builder.Append(values[length].String());
            }
            return builder.ToString();
        }
    }
}
