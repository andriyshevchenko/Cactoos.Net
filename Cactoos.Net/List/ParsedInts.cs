using System.Collections;
using System.Collections.Generic;
using System.Globalization;



namespace Cactoos.List
{
    internal class ParsedInts : IEnumerable<int>
    {
        private IEnumerable<string> _source;

        public ParsedInts(IEnumerable<string> source)
        {
            _source = source;
        }

        public ParsedInts(IEnumerable<IText> source)
            : this(System.Linq.Enumerable.Select(source, item => item.String()))
        {

        }

        public IEnumerator<int> GetEnumerator()
        {
            return System.Linq.Enumerable.Select(_source, item => int.Parse(item, CultureInfo.InvariantCulture)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
