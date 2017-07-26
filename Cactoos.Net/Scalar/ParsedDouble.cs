namespace Cactoos.Scalar
{
    public class ParsedDouble : IScalar<double>
    {
        private IScalar<string> _source;

        public ParsedDouble(IScalar<string> source)
        {
            _source = source;
        }

        public ParsedDouble(string source) : this(new ValueScalar<string>(source))
        {

        }

        public double Value()
        {
            return double.Parse(_source.Value());
        }
    }
}
