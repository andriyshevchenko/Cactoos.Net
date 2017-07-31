using System.Collections;
using System.Collections.Generic;

using static System.Collections.Generic.Create;

namespace Cactoos.Scalar
{
    public class ParsedDoubles : IEnumerable<double>
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
            return map(_source, item => new ParsedDouble(item).Value()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
