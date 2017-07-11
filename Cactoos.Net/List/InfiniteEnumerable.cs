using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using static System.Functional.Func;

namespace Cactoos.List
{
    public class InfiniteEnumerable<T> : IEnumerable<T>
    {
        private Func<int, T> _generator;

        public InfiniteEnumerable(Func<int, T> next)
        {
            _generator = next;
        }

        public InfiniteEnumerable(Func<T> next)
        {
            _generator = (int i) => next();
        }

        public IEnumerator<T> GetEnumerator()
        {
            int i = 0;
            while (true)
            {
                yield return _generator(i++);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
