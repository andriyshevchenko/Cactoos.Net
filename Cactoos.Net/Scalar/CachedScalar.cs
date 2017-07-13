namespace Cactoos.Scalar
{
    public class CachedScalar<T> : IScalar<T>
    {
        private bool evaluated;
        private T value;
        private IScalar<T> _scalar;

        public CachedScalar(IScalar<T> scalar)
        {
            _scalar = scalar;
            evaluated = false;
        }

        public CachedScalar(T value) : this(new ValueScalar<T>(value))
        {

        }

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
