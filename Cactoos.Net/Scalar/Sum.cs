using System.Collections.Generic;

namespace Cactoos.Scalar
{
    public class DoubleSum : IScalar<double>
    {
        private IEnumerable<double> _source;

        public DoubleSum(IEnumerable<double> source)
        {
            _source = source;
        }

        public double Value()
        {
            double result = 0.0;
            foreach (var item in _source)
            {
                result += item;
            }
            return result;
        }
    }
}
