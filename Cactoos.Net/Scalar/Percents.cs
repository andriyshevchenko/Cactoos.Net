using System;
using System.Collections.Generic;
using System.Text;

namespace Cactoos.Scalar
{
    public class Percents : IScalar<double>
    {
        private double _first;
        private double _second;

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
