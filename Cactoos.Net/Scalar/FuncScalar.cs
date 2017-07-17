using System;

namespace Cactoos.Scalar
{
    public class FuncScalar<T> : IScalar<T>
    {
        private Func<T> _func;

        public FuncScalar(Func<T> func)
        {
            _func = func;
        }

        public T Value()
        {
            return _func();
        }
    }
}
