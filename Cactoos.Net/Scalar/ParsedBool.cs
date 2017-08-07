namespace Cactoos.Scalar
{
    public class ParsedBool : IScalar<bool>
    {
        private IScalar<string> _source;

        public ParsedBool(IScalar<string> source)
        {
            _source = source;
        }

        public ParsedBool(string source) : this(new ValueScalar<string>(source))
        {

        }

        public bool Value()
        {
            return bool.Parse(_source.Value());
        }
    }
}
