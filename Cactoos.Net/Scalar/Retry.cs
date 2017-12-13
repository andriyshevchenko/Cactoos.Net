using System;
using System.Collections.Generic;

namespace Cactoos.Scalar
{
    public class Retry<T> : IScalar<T>, IAttempt
    {
        private List<Exception> _errors = new List<Exception>();
        private int _attempts;
        private IScalar<T> _source;

        public Retry(IScalar<T> source, int times)
        {
            _attempts = times;
            _source = source;
        }

        public Exception[] Errors()
        {
            return _errors.ToArray();
        }

        public bool HasErrors()
        {
            return _errors.Count != 0;
        }

        public T Value()
        {
            T value = default(T);
            for (int i = 0; i < _attempts; i++)
            {
                try
                {
                    value = _source.Value();
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
