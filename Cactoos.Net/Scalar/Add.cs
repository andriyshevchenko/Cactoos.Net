namespace Cactoos.Scalar
{
    public struct Add : IScalar<int>
    {
        private IScalar<int> _left;
        private IScalar<int> _right;

        public Add(IScalar<int> left, IScalar<int> right)
        {
            _left = left;
            _right = right;
        }

        public Add(IScalar<int> left, int right)
           : this(left, new ValueScalar<int>(right))
        {

        }

        public Add(int left, int right)
                   : this(new ValueScalar<int>(left), new ValueScalar<int>(right))
        {

        }

        public int Value()
        {
            return _left.Value() + _right.Value();
        }
    }
}
