using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cactoos.List
{
    public struct ItemIndexPair<T>
    {
        public int Index { get; }
        public T Item { get; }

        public ItemIndexPair(int index, T item)
        {
            Index = index;
            Item = item;
        }

        public ItemIndexPair<T> Next(T item)
        {
            return new ItemIndexPair<T>(Index + 1, item);
        }
    }

    public class Indices<T> : IEnumerable<int>
    {
        private IEnumerable<ItemIndexPair<T>> _source;

        public Indices(IEnumerable<ItemIndexPair<T>> source)
        {
            _source = source;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return _source.Select(item => item.Index).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Indexed<T> : IEnumerable<ItemIndexPair<T>>
    {
        public class Enumerator : IEnumerator<ItemIndexPair<T>>
        {
            private ItemIndexPair<T> current;
            private IEnumerator<T> _source;

            public Enumerator(IEnumerator<T> source)
            {
                _source = source;
                current = new ItemIndexPair<T>(-1, default(T));
            }

            public ItemIndexPair<T> Current => current;

            object IEnumerator.Current => current;

            public void Dispose()
            {
                _source.Dispose();
            }

            public bool MoveNext()
            {
                bool moveNext = _source.MoveNext();
                if (moveNext)
                {
                    if (current.Index == -1)
                    {
                        current = new ItemIndexPair<T>(0, _source.Current);
                    }
                    else
                    {
                        current = current.Next(_source.Current);
                    }
                }
                return moveNext;
            }

            public void Reset()
            {
                _source.Reset();
            }
        }

        private IEnumerable<T> _source;

        public Indexed(IEnumerable<T> source)
        {
            _source = source;
        }

        public IEnumerator<ItemIndexPair<T>> GetEnumerator()
        {
            return new Enumerator(_source.GetEnumerator());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
