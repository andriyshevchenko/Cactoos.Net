namespace Cactoos.Scalar
{
    public struct ParsedFloat : IScalar<float>
    {
        private IScalar<string> _source;

        public ParsedFloat(IScalar<string> source)
        {
            _source = source;
        }

        public ParsedFloat(string source) : this(new ValueScalar<string>(source))
        {

        }

        public float Value()
        {
            return float.Parse(_source.Value());
        }
    }

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
            return long.Parse(_source.Value());
        }
    }
}
