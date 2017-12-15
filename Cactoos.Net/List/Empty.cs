using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cactoos.List
{
    public class Empty<T> : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            return System.Linq.Enumerable.Empty<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
