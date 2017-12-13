using Cactoos.Scalar;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using static System.Collections.Generic.Create;

namespace Cactoos.List
{
    internal class Distinct<T> : IEnumerable<T>
    {
        private IScalar<ISet<T>> _items;
        private IEnumerable<T> _source;

        public Distinct(IEnumerable<T> source)
        {
            _source = source;
            _items = new LazyScalar<ISet<T>>(() => set(_source));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.Value().AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
