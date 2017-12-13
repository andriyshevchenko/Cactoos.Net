using System.Globalization;

namespace Cactoos.Scalar
{
    public struct ParsedByte : IScalar<byte>
    {
        private IScalar<string> _source;

        public ParsedByte(IScalar<string> source)
        {
            _source = source;
        }

        public ParsedByte(string source) : this(new ScalarOf<string>(source))
        {

        }

        public byte Value()
        {
            return byte.Parse(_source.Value(), CultureInfo.InvariantCulture);
        }
    }
}
