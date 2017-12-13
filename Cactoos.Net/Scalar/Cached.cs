namespace Cactoos.Scalar
{
    /// <summary>
    /// Same as <see cref="LazyScalar{T}"/> but captures only values and other scalars.
    /// </summary>
    /// <typeparam name="T">Type of the item to cache</typeparam>.
    public class Cached<T> : IScalar<T>
    {
        private bool evaluated;
        private T value;
        private IScalar<T> _scalar;

        /// <summary>
        /// Initializes a new instance of <see cref="Cached{T}"/>.
        /// </summary>
        /// <param name="scalar">Scalar to get value from.</param>
        public Cached(IScalar<T> scalar)
        {
            _scalar = scalar;
            evaluated = false;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Cached{T}"/>.
        /// </summary>
        /// <param name="value">Value to cache.</param>
        public Cached(T value) : this(new ScalarOf<T>(value))
        {

        }

        /// <summary>
        /// Gets the cached value.
        /// </summary>
        /// <returns>Cached value.</returns>
        public T Value()
        {
            if (!evaluated)
            {
                evaluated = true;
                value = _scalar.Value();
            }
            return value;
        }
    }
}
