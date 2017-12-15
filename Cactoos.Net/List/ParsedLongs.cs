using System.Collections;
using System.Collections.Generic;
using System.Globalization;



namespace Cactoos.List
{
    internal class ParsedLongs : IEnumerable<long>
    {
        private IEnumerable<string> _source;

        public ParsedLongs(IEnumerable<string> source)
        {
            _source = source;
        }

        public ParsedLongs(IEnumerable<IText> source)
            : this(System.Linq.Enumerable.Select(source, item => item.String()))
        {

        }

        public IEnumerator<long> GetEnumerator()
        {
            return System.Linq.Enumerable.Select(_source, item => long.Parse(item, CultureInfo.InvariantCulture)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
