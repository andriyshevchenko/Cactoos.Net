using System;
using System.Collections.Generic;
using System.Text;

namespace Cactoos.Net.Scalar
{
    public class ThreadSafeScalar<T> : IScalar<T> 
    {
        private static readonly object _lock = new object();
        private IScalar<T> _source;

        public ThreadSafeScalar(IScalar<T> source)
        {
            _source = source;
        }

        public T Value()
        {
            lock (_lock)
            {
                return _source.Value();
            }
        }
    }
}
