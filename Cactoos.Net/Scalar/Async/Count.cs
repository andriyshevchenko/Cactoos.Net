using System;
using System.Threading.Tasks;

namespace Cactoos.Scalar.Async
{
    /// <summary>
    /// Counts the number of elements in <see cref="IAsyncEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the item.</typeparam>
    [Obsolete("For internal use")]
    internal class Count<T> : IAsyncScalar<int>
    {
        private IAsyncEnumerable<T> _source;

        public Count(IAsyncEnumerable<T> source)
        {
            _source = source;
        }

        public async Task<int> Value()
        {
            int count = 0;
            var e = _source.GetEnumerator();
            while (await e.MoveNextAsync().ConfigureAwait(false))
            {
                count++;
            }
            return count;
        }
    }
}
