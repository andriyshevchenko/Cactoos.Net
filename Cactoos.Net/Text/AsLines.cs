using System.Collections;
using System.Collections.Generic;

namespace Cactoos.Text
{
    public class AsLines : IEnumerable<string>
    {
        private IText _source;

        public AsLines(IText source)
        {
            _source = source;
        }

        public AsLines(string source) : this(new Cactoos.Text.Text(source))
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
