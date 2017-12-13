using System;
using System.Threading.Tasks;

namespace Cactoos.Scalar.Async
{
    public struct LazyAsync<T> : IAsyncScalar<T>
    {
        private Func<Task<T>> _source;
        private T _value;
        bool activated;

        public LazyAsync(Func<Task<T>> source)
        {
            activated = false;
            _value = default(T);
            _source = source;
        }

        public async Task<T> Value()
        {
            if (activated)
            {
                return _value;
            }
            activated = true;
            return _value = await _source().ConfigureAwait(false);
        }
    }
}
