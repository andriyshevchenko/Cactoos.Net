using System.Globalization;

namespace Cactoos.Scalar
{
    public struct ParsedDouble : IScalar<double>
    {
        private IScalar<string> _source;

        public ParsedDouble(IScalar<string> source)
        {
            _source = source;
        }

        public ParsedDouble(string source) : this(new ScalarOf<string>(source))
        {
            
        }

        public double Value()
        {
            return double.Parse(_source.Value(), CultureInfo.InvariantCulture);
        }
    }
}
