using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cactoos.Scalar.Async
{
    public class RetryAsyncScalar<T> : IAsyncScalar<T>, IAttempt
    {
        private List<Exception> _errors = new List<Exception>();
        private int _attempts;
        private IAsyncScalar<T> _source;

        public RetryAsyncScalar(IAsyncScalar<T> source)
        {
            _source = source;
        }

        public RetryAsyncScalar(Task<T> source) : this(new TaskScalar<T>(source))
        {

        }

        public Exception[] Errors()
        {
            return _errors.ToArray();
        }

        public bool HasErrors()
        {
            return _errors.Count != 0;
        }

        public async Task<T> Value()
        {
            T value = default(T);
            for (int i = 0; i < _attempts; i++)
            {
                try
                {
                    value = await _source.Value();
                }
                catch (Exception e)
                {
                    _errors.Add(e);
                    if (i == _attempts - 1)
                    {
                        throw;
                    }
                }
            }

            return value;
        }
    }
}
