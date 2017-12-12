using System.Collections;
using System.Collections.Generic;
using System.Linq;

using static System.Collections.Generic.Create;

namespace Cactoos.List
{
    public class Empty<T> : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            return array<T>().AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
