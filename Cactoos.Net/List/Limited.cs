using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cactoos.List
{
    public class Limited<T> : IEnumerable<T>
    {
        private IEnumerable<T> _source;
        private int _items;
 
        public Limited(IEnumerable<T> source, int items)
        {
            _source = source;
            _items = items;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _source.Take(_items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
