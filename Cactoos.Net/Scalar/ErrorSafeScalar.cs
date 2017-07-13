using System;
using static System.Collections.Generic.Create;

namespace Cactoos.Scalar
{
    public class ErrorSafeScalar<T> : IScalar<T>, IAttempt 
    {
        private Exception _error;
        private IScalar<T> _value;
        private IScalar<T> _fallback;
        private bool failed;
        
        public ErrorSafeScalar(IScalar<T> source, IScalar<T> fallback)
        {
            _value = source;
        }

        public ErrorSafeScalar(Func<T> source, Func<T> fallback) : this(new LazyScalar<T>(source), new LazyScalar<T>(fallback))
        {
         
        }

        public ErrorSafeScalar(IScalar<T> source, Func<T> fallback) : this(source, new LazyScalar<T>(fallback))
        {

        }


        public ErrorSafeScalar(Func<T> source, IScalar<T> fallback) : this(new LazyScalar<T>(source), fallback)
        {

        }

        public Exception[] Errors()
        {
            return array(_error);
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
