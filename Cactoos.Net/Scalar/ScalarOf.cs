namespace Cactoos.Scalar
{
    /// <summary>
    /// Returns the same value all the time
    /// </summary>
    /// <typeparam name="T">The type of the value</typeparam>
    public struct ScalarOf<T> : IScalar<T>
    {
        private T _value;

        public ScalarOf(T value)
        {
            _value = value;
        }

        public T Value()
        {
            return _value;
        }
    }
}
