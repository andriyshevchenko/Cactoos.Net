using Cactoos.Scalar;

namespace Cactoos.Text
{
    public class LongIntText : IText
    {
        private IScalar<long> _source;

        public LongIntText(IScalar<long> source)
        {
            _source = source;
        }

        public LongIntText(long source) : this(new ValueScalar<long>(source))
        {

        }

        public string String()
        {
            return _source.Value().ToString();
        }
    }
}
