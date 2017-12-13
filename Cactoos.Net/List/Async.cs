using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cactoos.List
{
    internal class Async<T> : IAsyncEnumerable<T>
    {
        private IEnumerable<T> _source;

        public Async(IEnumerable<T> source)
        {
            _source = source;
        }

        public class Enumerator : IAsyncEnumerator<T>
        {
            private IEnumerator<T> _source;

            public Enumerator(IEnumerable<T> source)
            {
                _source = source.GetEnumerator();
            }

            public T Current => _source.Current;

            object IAsyncEnumerator.Current => Current;

            public void Dispose()
            {
                _source.Dispose();
            }

            public Task<bool> MoveNextAsync()
            {
                return Task.FromResult(_source.MoveNext());
            }

            public void Reset()
            {
                _source.Reset();
            }
        }

        public IAsyncEnumerator<T> GetEnumerator()
        {
            return new Enumerator(_source);
        }

        IAsyncEnumerator IAsyncEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
