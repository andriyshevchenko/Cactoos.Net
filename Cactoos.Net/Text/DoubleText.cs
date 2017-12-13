using Cactoos.Scalar;

namespace Cactoos.Text
{
    public class PrintedDouble : IText
    {
        private IScalar<double> _source;

        public PrintedDouble(IScalar<double> source)
        {
            _source = source;
        }

        public PrintedDouble(double source) : this(new ScalarOf<double>(source))
        {

        }

        public string String()
        {
            return _source.Value().ToString();
        }
    }
}
