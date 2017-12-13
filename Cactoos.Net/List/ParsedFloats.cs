using System.Collections;
using System.Collections.Generic;
using System.Globalization;

using static System.Collections.Generic.Create;

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
            : this(map(source, item => item.String()))
        {

        }

        public IEnumerator<float> GetEnumerator()
        {
            return map(_source, item => float.Parse(item, CultureInfo.InvariantCulture)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
