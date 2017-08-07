using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cactoos.Scalar.Async
{
    public class ErrorSafeAsyncScalar<T> : IAsyncScalar<T>, IAttempt
    {
        private List<Exception> _errors = new List<Exception>();
        private IAsyncScalar<T> _source;
        private IAsyncScalar<T> _fallback;

        public ErrorSafeAsyncScalar(IAsyncScalar<T> source, IAsyncScalar<T> fallback)
        {
            _source = source;
            _fallback = fallback;
        }

        public ErrorSafeAsyncScalar(Func<Task<T>> source, Func<Task<T>> fallback)
            : this(new TaskScalar<T>(source), new TaskScalar<T>(fallback))
        {

        }

        public ErrorSafeAsyncScalar(IAsyncScalar<T> source, IScalar<T> fallback)
            : this(source, new FromResultScalar<T>(fallback))
        {
            
        }

        public ErrorSafeAsyncScalar(Func<Task<T>> source, Func<T> fallback)
            : this(new TaskScalar<T>(source), new FromResultScalar<T>(fallback))
        {

        }

        public Exception[] Errors()
        {
            return _errors.ToArray();
        }

        public bool HasErrors()
        {
            return _errors.Count > 0;
        }

        public async Task<T> Value()
        {
            try
            {
                return await _source.Value();
            }
            catch (Exception e)
            {
                _errors.Add(e);
                return await _fallback.Value();
            }
        }

        public ErrorSafeAsyncScalar<T> Create(IAsyncScalar<T> source, IAsyncScalar<T> fallback)
            => new ErrorSafeAsyncScalar<T>(source, fallback);

        public ErrorSafeAsyncScalar<T> Create(Func<Task<T>> source, Func<Task<T>> fallback)
            => new ErrorSafeAsyncScalar<T>(source, fallback);

        public ErrorSafeAsyncScalar<T> Create(IAsyncScalar<T> source, IScalar<T> fallback)
            => new ErrorSafeAsyncScalar<T>(source, fallback);

        public ErrorSafeAsyncScalar<T> Create(Func<Task<T>> source, Func<T> fallback)
            => new ErrorSafeAsyncScalar<T>(source, fallback);
    }
}
