using Cactoos.Scalar;

namespace Cactoos.Text
{
    public class IntText : IText
    {
        private IScalar<int> _source;

        public IntText(IScalar<int> source)
        {
            _source = source;
        }

        public IntText(int source) : this(new ValueScalar<int>(source))
        {

        }

        public string String()
        {
            return _source.Value().ToString();
        }
    }
}
