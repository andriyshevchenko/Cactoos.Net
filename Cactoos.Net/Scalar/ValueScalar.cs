namespace Cactoos.Scalar
{
    /// <summary>
    /// Returns the same value all the time
    /// </summary>
    /// <typeparam name="T">The type of the value</typeparam>
    public struct ValueScalar<T> : IScalar<T>
    {
        private T _value;

        public ValueScalar(T value)
        {
            _value = value;
        }

        public T Value()
        {
            return _value;
        }
    }
}
