using Cactoos.Scalar;

namespace Cactoos.Text
{
    public class DecodedUrl : IScalar<string>
    {
        private IScalar<string> _source;

        public DecodedUrl(IScalar<string> source)
        {
            _source = source;
        }

        public DecodedUrl(string source) : this(new ValueScalar<string>(source))
        {

        }

        public string Value()
        {
            return System.Uri.UnescapeDataString(_source.Value());
        }
    }
}
