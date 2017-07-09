using System.Collections.Generic;
using System.Linq;

namespace Cactoos.IO
{
    public class EnumerableAsBytes : IBytes
    {
        IEnumerable<byte> _source;

        public EnumerableAsBytes(IEnumerable<byte[]> source)
        {
            _source = source.SelectMany(bt => bt);
        }

        public EnumerableAsBytes(IEnumerable<byte> source)
        {
            _source = source;
        }

        public byte[] Bytes()
        {
            return _source.ToArray();
        }
    }
}
