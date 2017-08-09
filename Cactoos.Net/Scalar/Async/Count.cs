using System.Threading.Tasks;

namespace Cactoos.Scalar.Async
{
    /// <summary>
    /// Counts the numbre of elements in <see cref="IAsyncEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the item.</typeparam>
    public class Count<T> : IAsyncScalar<int>
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
