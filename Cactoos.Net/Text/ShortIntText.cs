using Cactoos.Scalar;

namespace Cactoos.Text
{
    public class ShortIntText : IText
    {
        private IScalar<short> _source;
        
        public ShortIntText(IScalar<short> source)
        {
            _source = source;
        }

        public ShortIntText(short source) : this(new ValueScalar<short>(source))
        {

        }

        public string String()
        {
            return _source.Value().ToString();
        }
    }
}
