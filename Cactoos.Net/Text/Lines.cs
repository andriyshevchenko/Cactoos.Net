using System.Collections;
using System.Collections.Generic;

namespace Cactoos.Text
{
    public class Lines : IEnumerable<string>
    {
        private IText _source;

        public Lines(IText source)
        {
            _source = source;
        }

        public Lines(string source) : this(new Cactoos.Text.Text(source))
        {

        }

        public IEnumerator<string> GetEnumerator()
        {
            return new StringSplitText(_source, "\n", "\r").GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
