using System;
using System.Collections.Generic;
using System.Text;

namespace Cactoos.Scalar
{
    public class Percents : IScalar<double>
    {
        private double _first;
        private double _second;

        public Percents(IScalar<double> first, IScalar<double> second)
        {
            _first = first.Value();
            _second = second.Value();
        }

        public Percents(IScalar<float> first, IScalar<float> second) : this(first.Value(), second.Value())
        {

        }

        public Percents(IScalar<int> first, IScalar<int> second) : this(first.Value(), second.Value())
        {

        }

        public Percents(IScalar<decimal> first, IScalar<decimal> second) : this(first.Value(), second.Value())
        {

        }

        public Percents(IScalar<long> first, IScalar<long> second) : this(first.Value(), second.Value())
        {

        }

        public Percents(IScalar<short> first, IScalar<short> second) : this(first.Value(), second.Value())
        {

        }

        public Percents(IScalar<byte> first, IScalar<byte> second) : this(first.Value(), second.Value())
        {

        }

        public Percents(IScalar<char> first, IScalar<char> second) : this(first.Value(), second.Value())
        {

        }

        public Percents(double first, double second)
        {
            _first = first;
            _second = second;
        }

        public Percents(float first, float second) : this((double)first, second)
        {

        }

        public Percents(int first, int second) : this((double)first, second)
        {

        }

        public Percents(decimal first, decimal second) : this((double)first, (double)second)
        {

        }

        public Percents(long first, long second) : this((double)first, second)
        {

        }

        public Percents(short first, short second) : this((double)first, second)
        {

        }

        public Percents(byte first, byte second) : this((double)first, second)
        {

        }

        public Percents(char first, char second) : this((double)first, second)
        {

        }

        public double Value()
        {
            return Math.Abs(_first / _second - 1.0);
        }
    }
}
