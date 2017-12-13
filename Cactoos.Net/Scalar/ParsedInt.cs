using System.Globalization;

namespace Cactoos.Scalar
{
    public struct ParsedInt : IScalar<int>
    {
        private IScalar<string> _source;

        public ParsedInt(IScalar<string> source)
        {
            _source = source;
        }

        public ParsedInt(string source) : this(new ScalarOf<string>(source))
        {

        }

        public int Value()
        {
            return int.Parse(_source.Value(), CultureInfo.InvariantCulture);
        }
    }
}
