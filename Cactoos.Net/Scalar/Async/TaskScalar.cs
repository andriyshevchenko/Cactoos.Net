using System.Threading.Tasks;

namespace Cactoos.Scalar.Async
{
    public struct TaskScalar<T> : IAsyncScalar<T>
    {
        private Task<T> _source;

        public TaskScalar(Task<T> source)
        {
            _source = source;
        }

        public Task<T> Value()
        {
            return _source;
        }
    }
}
