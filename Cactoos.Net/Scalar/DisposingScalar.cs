using System;

namespace Cactoos.Net.Scalar
{
    public class DisposingScalar<T> : IScalar<T>
    {
        private IDisposable _source;
        private Func<IDisposable, T> _getValue;

        public DisposingScalar(IDisposable source, Func<IDisposable, T> getValue)
        {
            _source = source;
            _getValue = getValue;
        }

        public T Value()
        {
            using (_source)
            {
                return _getValue(_source);
            }
        }
    }
}
