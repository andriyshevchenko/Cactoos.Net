namespace Cactoos.Scalar
{
    public class ParsedByte : IScalar<byte>
    {
        private IScalar<string> _source;

        public ParsedByte(IScalar<string> source)
        {
            _source = source;
        }

        public ParsedByte(string source) : this(new ValueScalar<string>(source))
        {

        }

        public byte Value()
        {
            return byte.Parse(_source.Value());
        }
    }
}
