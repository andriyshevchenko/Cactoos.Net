using System.Collections.Generic;
using System.Linq;

namespace Cactoos.Scalar
{
    public struct MaxInt : IScalar<int>
    {
        private IEnumerable<int> _source;

        public MaxInt(IEnumerable<int> source)
        {
            _source = source;
        }


        public int Value()
        {
            var source = _source.ToArray();
            int max = source[0];
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] > max)
                {
                    max = source[i];
                }
            }
            return max;
        }
    }

    public struct MaxDouble : IScalar<double>
    {
        private IEnumerable<double> _source;

        public MaxDouble(IEnumerable<double> source)
        {
            _source = source;
        }


        public double Value()
        {
            var source = _source.ToArray();
            double max = source[0];
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] > max)
                {
                    max = source[i];
                }
            }
            return max;
        }
    }

}
