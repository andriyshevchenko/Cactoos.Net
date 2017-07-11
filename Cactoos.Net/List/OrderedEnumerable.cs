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

    public class OrderedEnumerable<T> : IEnumerable<T> where T : IComparable<T>
    {
        private T[] _items;
        private IEnumerable<T> _source;
        private SortOrder _order;

        public OrderedEnumerable(IEnumerable<T> source, SortOrder order)
        {
            _source = source;
            _order = order;
        }

        public IEnumerator<T> GetEnumerator()
        {
            _items = _source.ToArray();
            if (_order == SortOrder.Ascending)
            {
                Array.Sort(_items);
            }

            if (_order == SortOrder.Descending)
            {
                Array.Sort(_items, (first, second) => - first.CompareTo(second));
            }

            for (int i = 0; i < _items.Length; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}