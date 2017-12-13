using System.Collections.Generic;
using System.Linq;

namespace Cactoos.Scalar
{
    internal struct NumericSum : IScalar<double>
    {
        private IEnumerable<double> _source;

        public NumericSum(IEnumerable<double> source)
        {
            _source = source;
        }

        public NumericSum(IEnumerable<int> source) : this(source.Cast<double>())
        {

        }

        public NumericSum(IEnumerable<short> source) : this(source.Cast<double>())
        {

        }

        public NumericSum(IEnumerable<float> source) : this(source.Cast<double>())
        {

        }

        public NumericSum(IEnumerable<byte> source) : this(source.Cast<double>())
        {

        }

        public NumericSum(IEnumerable<long> source) : this(source.Cast<double>())
        {

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
