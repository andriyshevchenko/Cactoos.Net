using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cactoos.Net.Text
{
    public class StringSplitText : IEnumerable<string>
    {
        private string[] _separator;
        private IText _source;

        public StringSplitText(IText source, string[] separator)
        {
            _source = source;
            _separator = separator;
        }

        public StringSplitText(string source, string[] separator) : this(new Cactoos.Text.Text(source), separator)
        {

        }

        public IEnumerator<string> GetEnumerator()
        {
            return _source.String()
                .Split(_separator, StringSplitOptions.RemoveEmptyEntries)
                .AsEnumerable()
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

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
