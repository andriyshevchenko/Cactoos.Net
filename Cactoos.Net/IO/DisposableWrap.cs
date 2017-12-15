
using System;

namespace Cactoos.IO
{
    /// <summary>
    /// Acts as a raii guard, to dispose _source when needed.
    /// </summary>
    /// <typeparam name="T">Type of item to capture.</typeparam>
    public struct DisposableWrap<T> : IScalar<T>
    {
        private T _wrapee;

        public DisposableWrap(T wrapee)
        {
            _wrapee = wrapee;
        }

        public void Dispose()
        {
            (_wrapee as IDisposable)?.Dispose();
        }

        public T Value()
        {
            return _wrapee;
        }
    }
}

