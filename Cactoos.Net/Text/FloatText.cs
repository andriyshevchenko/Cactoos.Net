using Cactoos.Scalar;

namespace Cactoos.Text
{
    internal class FloatText : IText
    {
        private IScalar<float> _source;

        public FloatText(IScalar<float> source)
        {
            _source = source;
        }

        public FloatText(float source) : this(new ScalarOf<float>(source))
        {

        }

        public string String()
        {
            return _source.Value().ToString();
        }
    }
}
