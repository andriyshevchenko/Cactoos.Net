using System;
using System.Collections.Generic;
using System.Text;

namespace Cactoos.Net.Scalar
{
    public class CachedScalar<T> : IScalar<T>
    {
        private T _value;

        public CachedScalar()
        {

        }

        public CachedScalar(T value)
        {
            _value = value;
        }

        public T Value()
        {
            return _value;
        }
    }
}
