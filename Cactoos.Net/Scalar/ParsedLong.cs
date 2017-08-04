namespace Cactoos.Scalar
{
    public struct ParsedLong : IScalar<long>
    {
        private IScalar<string> _source;

        public ParsedLong(IScalar<string> source)
        {
            _source = source;
        }

        public ParsedLong(string source) : this(new ValueScalar<string>(source))
        {

        }

        public long Value()
        {
            return long.Parse(_source.Value(), System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
