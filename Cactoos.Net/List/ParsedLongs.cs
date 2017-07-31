using System.Collections;
using System.Collections.Generic;
using System.Globalization;

using static System.Collections.Generic.Create;

namespace Cactoos.List
{
    public class ParsedLongs : IEnumerable<long>
    {
        private IEnumerable<string> _source;

        public ParsedLongs(IEnumerable<string> source)
        {
            _source = source;
        }

        public ParsedLongs(IEnumerable<IText> source)
            : this(map(source, item => item.String()))
        {

        }

        public IEnumerator<long> GetEnumerator()
        {
            return map(_source, item => long.Parse(item, CultureInfo.InvariantCulture)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
