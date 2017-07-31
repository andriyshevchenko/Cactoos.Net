using Cactoos.Scalar;

namespace Cactoos.Text
{
    public class FloatText : IText
    {
        private IScalar<float> _source;

        public FloatText(IScalar<float> source)
        {
            _source = source;
        }

        public FloatText(float source) : this(new ValueScalar<float>(source))
        {

        }

        public string String()
        {
            return _source.Value().ToString();
        }
    }
}
