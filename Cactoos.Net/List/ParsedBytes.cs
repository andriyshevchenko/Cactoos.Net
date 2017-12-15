using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Cactoos.List
{
    /// <summary>
    /// Convert collection of strings to collection of bytes.
    /// </summary>
    internal class ParsedBytes : IEnumerable<byte>
    {
        private IEnumerable<string> _source;

        public ParsedBytes(IEnumerable<string> source)
        {
            _source = source;
        }

        public ParsedBytes(IEnumerable<IText> source)
            : this(source.Select(item => item.String()))
        {

        }

        public IEnumerator<byte> GetEnumerator()
        {
            return System.Linq.Enumerable.Select(_source, item => byte.Parse(item, CultureInfo.InvariantCulture)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
