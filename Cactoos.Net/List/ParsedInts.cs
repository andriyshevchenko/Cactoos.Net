using System.Collections;
using System.Collections.Generic;
using System.Globalization;

using static System.Collections.Generic.Create;

namespace Cactoos.List
{
    public class ParsedInts : IEnumerable<int>
    {
        private IEnumerable<string> _source;

        public ParsedInts(IEnumerable<string> source)
        {
            _source = source;
        }

        public ParsedInts(IEnumerable<IText> source)
            : this(map(source, item => item.String()))
        {

        }

        public IEnumerator<int> GetEnumerator()
        {
            return map(_source, item => int.Parse(item, CultureInfo.InvariantCulture)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
