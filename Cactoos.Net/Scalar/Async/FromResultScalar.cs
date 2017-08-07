using System;
using System.Threading.Tasks;

namespace Cactoos.Scalar.Async
{
    public struct FromResultScalar<T> : IAsyncScalar<T>
    {
        private IScalar<T> _source;

        public FromResultScalar(IScalar<T> source)
        {
            _source = source;
        }

        public FromResultScalar(Func<T> source)
            : this(new FuncScalar<T>(source))
        {

        }

        public Task<T> Value()
        {
            return Task.FromResult(_source.Value());
        }
    }
}
