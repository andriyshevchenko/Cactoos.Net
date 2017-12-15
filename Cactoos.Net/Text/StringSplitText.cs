using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq; 
namespace Cactoos.Text
{
    /// <summary>
    /// String which can be split by string entries
    /// </summary>
    public class StringSplitText : IEnumerable<string>
    {
        private string[] _separator;
        private IText _source;

        public StringSplitText(IText source, params string[] separator)
        {
            _source = source;
            _separator = separator;
        }

        public StringSplitText(string source, params string[] separator) : this(new Cactoos.Text.Text(source), separator)
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
}
