using System.Globalization;

namespace Cactoos.Scalar
{
    public struct ParsedFloat : IScalar<float>
    {
        private IScalar<string> _source;

        public ParsedFloat(IScalar<string> source)
        {
            _source = source;
        }

        public ParsedFloat(string source) : this(new ScalarOf<string>(source))
        {

        }

        public float Value()
        {
            return float.Parse(_source.Value(), CultureInfo.InvariantCulture);
        }
    }
}
