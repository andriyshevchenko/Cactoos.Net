using System;
using System.Threading.Tasks;

namespace Cactoos.Scalar.Async
{
    public struct FromResult<T> : IAsyncScalar<T>
    {
        private IScalar<T> _source;

        public FromResult(IScalar<T> source)
        {
            _source = source;
        }

        public FromResult(Func<T> source)
            : this(new FuncOf<T>(source))
        {

        }

        public Task<T> Value()
        {
            return Task.FromResult(_source.Value());
        }
    }
}
