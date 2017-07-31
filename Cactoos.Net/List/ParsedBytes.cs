using System.Collections;
using System.Collections.Generic;
using System.Globalization;

using static System.Collections.Generic.Create;

namespace Cactoos.List
{
    /// <summary>
    /// Convert collection of strings to collection of bytes.
    /// </summary>
    public class ParsedBytes : IEnumerable<byte>
    {
        private IEnumerable<string> _source;

        public ParsedBytes(IEnumerable<string> source)
        {
            _source = source;
        }

        public ParsedBytes(IEnumerable<IText> source)
            : this(map(source, item => item.String()))
        {

        }

        public IEnumerator<byte> GetEnumerator()
        {
            return map(_source, item => byte.Parse(item, CultureInfo.InvariantCulture)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
