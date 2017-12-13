using System;

using static System.Functional.FlowControl;

namespace Cactoos.Scalar
{
    /// <summary>
    /// Will dispose value it wraps when calling Value().
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Obsolete("For internal use")]
    internal class Using<T> : IScalar<T>
    {
        private IScalar<T> _value;

        /// <summary>
        /// Initializes a new instance of <see cref="Using{T}"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="getValue">Function to get the value from <paramref name="source"/>.</param>
        public Using(IDisposable source, Func<IDisposable, T> getValue)
        {
            _value = new LazyScalar<T>(() => use(source, getValue));
        }

        /// <summary>
        /// Gets the value of a scalar.
        /// </summary>
        /// <returns>Value of a scalar.</returns>
        public T Value()
        {
            return _value.Value();
        }
    }
}
