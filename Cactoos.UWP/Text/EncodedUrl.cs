using Cactoos.Scalar;

namespace Cactoos.Text
{
    public class EncodedUrl : IScalar<string>
    {
        private IScalar<string> _source;

        public EncodedUrl(IScalar<string> source)
        {
            _source = source;
        }

        public EncodedUrl(string source) : this(new ScalarOf<string>(source))
        {

        }

        public string Value()
        {
            return System.Uri.EscapeDataString(_source.Value());
        }
    }
}
