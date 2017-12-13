using System;

namespace Cactoos.Scalar
{
    /// <summary>
    /// Gets the value by calling the function.
    /// </summary>
    /// <typeparam name="T">Type of the value to return.</typeparam>
    public class FuncOf<T> : IScalar<T>
    {
        private Func<T> _func;

        /// <summary>
        /// Initializes a new instance of <see cref="FuncOf{T}"/>
        /// </summary>
        /// <param name="func">Function to get values from.</param>
        public FuncOf(Func<T> func)
        {
            _func = func;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>The value.</returns>
        public T Value()
        {
            return _func();
        }
    }
}
