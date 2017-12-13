using Cactoos.Scalar;

namespace Cactoos.Text
{
    internal class ByteText : IText
    {
        private IScalar<byte> _source;

        public ByteText(IScalar<byte> source)
        {
            _source = source;
        }

        public ByteText(byte source) : this(new ScalarOf<byte>(source))
        {

        }

        public string String()
        {
            return _source.Value().ToString();
        }
    }
}
