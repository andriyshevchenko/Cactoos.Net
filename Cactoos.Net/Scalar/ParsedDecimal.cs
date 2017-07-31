using System.Globalization;

namespace Cactoos.Scalar
{
    public struct ParsedDecimal : IScalar<decimal>
    {
        private IScalar<string> _source;

        public ParsedDecimal(IScalar<string> source)
        {
            _source = source;
        }

        public ParsedDecimal(string source) : this(new ValueScalar<string>(source))
        {

        }

        public decimal Value()
        {
            return decimal.Parse(_source.Value(), CultureInfo.InvariantCulture);
        }
    }
}
