namespace Cactoos.Scalar
{
    /// <summary>
    /// Performs a lock operation when calling Value()
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ThreadSafeScalar<T> : IScalar<T> 
    {
        private static readonly object _lock = new object();
        private IScalar<T> _source;

        public ThreadSafeScalar(IScalar<T> source)
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
