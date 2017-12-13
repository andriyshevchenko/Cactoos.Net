using System;
using System.Threading.Tasks;

namespace Cactoos.Scalar.Async
{
    [Obsolete("For internal use")]
    public struct TaskScalar<T> : IAsyncScalar<T>
    {
        private Func<Task<T>> _source;

        public TaskScalar(Func<Task<T>> source)
        {
            _source = source;
        }

        public Task<T> Value()
        {
            return _source();
        }
    }
}
