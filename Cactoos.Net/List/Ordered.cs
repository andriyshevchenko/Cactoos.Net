using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cactoos.List
{
    /// <summary>
    /// Sort order.
    /// </summary>
    public enum SortOrder
    {
        /// <summary>
        /// Ascending.
        /// </summary>
        Ascending,

        /// <summary>
        /// Descending.
        /// </summary>
        Descending
    }

    /// <summary>
    /// The ordered enumerable.
    /// </summary>
    /// <typeparam name="T">The type of the item.</typeparam>
    internal class Ordered<T> : IEnumerable<T> where T : IComparable<T>
    {
        private IEnumerable<T> _source;
        private SortOrder _order;

        /// <summary>
        /// Initializes a new instance of <see cref="Ordered{T}"/>.
        /// </summary>
        /// <param name="source">The source enumerable.</param>
        /// <param name="order">The sort order.</param>
        public Ordered(IEnumerable<T> source, SortOrder order)
        {
            _source = source;
            _order = order;
        }

        /// <summary>
        ///  Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
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

        public static Ordered<T> Create(IEnumerable<T> source, SortOrder sortOrder)
        {
            return new Ordered<T>(source, sortOrder);
        }
    }
}