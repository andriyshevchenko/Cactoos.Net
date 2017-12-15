using System.Collections;
using System.Collections.Generic;
using System.Globalization;



namespace Cactoos.List
{
    internal class ParsedFloats : IEnumerable<float>
    {
        private IEnumerable<string> _source;

        public ParsedFloats(IEnumerable<string> source)
        {
            _source = source;
        }

        public ParsedFloats(IEnumerable<IText> source)
            : this(System.Linq.Enumerable.Select(source, item => item.String()))
        {

        }

        public IEnumerator<float> GetEnumerator()
        {
            return System.Linq.Enumerable.Select(_source, item => float.Parse(item, CultureInfo.InvariantCulture)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
