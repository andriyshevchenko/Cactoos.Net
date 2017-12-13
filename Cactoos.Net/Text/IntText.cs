using Cactoos.Scalar;

namespace Cactoos.Text
{
    public class PrintedInt : IText
    {
        private IScalar<long> _source;

        public PrintedInt(IScalar<long> source)
        {
            _source = source;
        }

        public PrintedInt(long source) : this(new ScalarOf<long>(source))
        {

        }

        public PrintedInt(int source) : this((long)source)
        {

        }


        public string String()
        {
            return _source.Value().ToString();
        }
    }
}
