using System;


namespace Cactoos.Scalar
{
    /// <summary>
    /// Scalar, which doesn't throw <see cref="Exception"/>.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public class NoThrow<T> : IScalar<T>, IAttempt 
    {
        private Exception _error;
        private IScalar<T> _value;
        private IScalar<T> _fallback;
        private bool failed;
        
        /// <summary>
        /// Initializes a new instance of <see cref="NoThrow{T}"/>.
        /// </summary>
        /// <param name="source">The source scalar.</param>
        /// <param name="fallback">The fallback scalar.</param>
        public NoThrow(IScalar<T> source, IScalar<T> fallback)
        {
            _value = source;
            _fallback = fallback;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="NoThrow{T}"/>.
        /// </summary>
        /// <param name="source">The source function.</param>
        /// <param name="fallback">The fallback function.</param>
        public NoThrow(Func<T> source, Func<T> fallback) : this(new LazyScalar<T>(source), new LazyScalar<T>(fallback))
        {
         
        }

        /// <summary>
        /// Initializes a new instance of <see cref="NoThrow{T}"/>.
        /// </summary>
        /// <param name="source">The source scalar.</param>
        /// <param name="fallback">The fallback function.</param>
        public NoThrow(IScalar<T> source, Func<T> fallback) : this(source, new LazyScalar<T>(fallback))
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="NoThrow{T}"/>.
        /// </summary>
        /// <param name="source">The source function.</param>
        /// <param name="fallback">The fallback scalar.</param>
        public NoThrow(Func<T> source, IScalar<T> fallback) : this(new LazyScalar<T>(source), fallback)
        {

        }

        public Exception[] Errors()
        {
            return new Exception[] { _error };
        }

        public bool HasErrors()
        {
            return failed;
        }

        public T Value()
        {
            try
            {
                return _value.Value();
            }
            catch (Exception e)
            {
                failed = true;
                _error = e;
                return _fallback.Value();
            }
        }
    }
}
