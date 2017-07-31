using Cactoos.Scalar;
using System;

namespace Cactoos.IO
{
    public class DoubleBytes : IBytes
    {
        private IScalar<double> _source;

        public DoubleBytes(IScalar<double> source)
        {
            _source = source;
        }

        public DoubleBytes(double source) : this(new ValueScalar<double>(source))
        {

        }

        public byte[] Bytes()
        {
            return BitConverter.GetBytes(_source.Value());
        }
    }

    public class IntBytes : IBytes
    {
        private IScalar<int> _source;

        public IntBytes(IScalar<int> source)
        {
            _source = source;
        }

        public IntBytes(int source) : this(new ValueScalar<int>(source))
        {

        }

        public byte[] Bytes()
        {
            return BitConverter.GetBytes(_source.Value());
        }
    }

    public class FloatBytes : IBytes
    {
        private IScalar<float> _source;

        public FloatBytes(IScalar<float> source)
        {
            _source = source;
        }

        public FloatBytes(float source) : this(new ValueScalar<float>(source))
        {

        }

        public byte[] Bytes()
        {
            return BitConverter.GetBytes(_source.Value());
        }
    }

    public class ShortBytes : IBytes
    {
        private IScalar<short> _source;

        public ShortBytes(IScalar<short> source)
        {
            _source = source;
        }

        public ShortBytes(short source) : this(new ValueScalar<short>(source))
        {

        }

        public byte[] Bytes()
        {
            return BitConverter.GetBytes(_source.Value());
        }
    }
}
