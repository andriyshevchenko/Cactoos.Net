namespace Cactoos.Scalar
{
    /// <summary>
    /// Performs a lock operation when calling Value()
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class ThreadSafe<T> : IScalar<T> 
    {
        private readonly object _lock = new object();
        private IScalar<T> _source;

        public ThreadSafe(IScalar<T> source)
        {
            _source = source;
        }

        public T Value()
        {
            lock (_lock)
            {
                return _source.Value();
            }
        }
    }
}
