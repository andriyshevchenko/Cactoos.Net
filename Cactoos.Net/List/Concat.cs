using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cactoos.List
{
    public class Concat<T> : IEnumerable<T>
    {
        private IEnumerable<T>[] _source; 
 
        public Concat(params IEnumerable<T>[] source)
        {
            _source = source; 
        }

        public IEnumerator<T> GetEnumerator()
        {
            var first = _source[0];
            for (int i = 1; i < _source.Length; i++)
            {
                first = first.Concat(_source[i]);
            }
            return first.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
