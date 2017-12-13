using System.Collections;
using System.Collections.Generic;
using System.Globalization;

using static System.Collections.Generic.Create;

namespace Cactoos.List
{
    internal class ParsedDoubles : IEnumerable<double>
    {
        private IEnumerable<string> _source;

        public ParsedDoubles(IEnumerable<string> source)
        {
            _source = source;
        }

        public ParsedDoubles(IEnumerable<IText> source)
            : this(map(source, item => item.String()))
        {
                
        }

        public IEnumerator<double> GetEnumerator()
        {
            return map(_source, item => double.Parse(item, CultureInfo.InvariantCulture)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
