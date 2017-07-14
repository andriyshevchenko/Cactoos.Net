using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cactoos.List
{
    public enum SortOrder
    {
        Ascending,
        Descending
    }

    public class Ordered<T> : IEnumerable<T> where T : IComparable<T>
    {
        private T[] _items;
        private IEnumerable<T> _source;
        private SortOrder _order;

        public Ordered(IEnumerable<T> source, SortOrder order)
        {
            _source = source;
            _order = order;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (_order == SortOrder.Ascending ?
                    _source.OrderBy(item => item) : 
                    _source.OrderByDescending(item => item)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}