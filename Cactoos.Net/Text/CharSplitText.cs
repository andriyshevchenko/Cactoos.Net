using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cactoos.Text
{
    /// <summary>
    /// String which can be split by char entries
    /// </summary>
    public class CharSplitText : IEnumerable<string>
    {
        private char[] _separator;
        private IText _source;

        public CharSplitText(IText source, char[] separator)
        {
            _source = source;
            _separator = separator;
        }

        public CharSplitText(string source, char[] separator) : this(new Cactoos.Text.Text(source), separator)
        {

        }

        public IEnumerator<string> GetEnumerator()
        {
            return _source.String()
                .Split(_separator)
                .AsEnumerable()
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
