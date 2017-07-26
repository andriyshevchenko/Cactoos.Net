namespace Cactoos.Scalar
{
    public class ParsedFloat : IScalar<float>
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
}
