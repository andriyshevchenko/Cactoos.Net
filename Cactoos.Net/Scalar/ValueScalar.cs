namespace Cactoos.Net.Scalar
{
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
