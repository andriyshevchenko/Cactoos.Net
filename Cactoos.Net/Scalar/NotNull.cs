using InputValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cactoos.Net.Scalar
{
    public class NotNull<T> : IScalar<T> where T : class
    {
        private IScalar<T> _source;

        public NotNull(IScalar<T> source)
        {
            _source = source;
        }

        public NotNull(T source) : this(new CachedScalar<T>(source))
        {

        }

        public T Value()
        {
            return _source.Value().CheckNotNull("NULL instead of a valid scalar");
        }
    }
}
