namespace Cactoos.Scalar
{
    public class NotNull<T> : IScalar<T> where T : class
    {
        private IScalar<T> _source;

        public NotNull(IScalar<T> source)
        {
            _source = source;
        }

        public NotNull(T source) : this(new ScalarOf<T>(source))
        {

        }

        public T Value()
        {
            return _source.Value() ??  throw new System.Exception("NULL instead of a valid scalar");
        }
    }
}
