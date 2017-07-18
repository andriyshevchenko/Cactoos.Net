using Cactoos.Scalar;
using System.Web;

namespace Cactoos.Text
{
    public class EncodedUrl : IScalar<string>
    {
        private IScalar<string> _source;

        public EncodedUrl(IScalar<string> source)
        {
            _source = source;
        }

        public EncodedUrl(string source) : this(new ValueScalar<string>(source))
        {

        }

        public string Value()
        {
            return HttpUtility.UrlEncode(_source.Value());
        }
    }
}
