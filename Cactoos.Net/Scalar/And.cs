namespace Cactoos.Scalar
{
    public struct And : IScalar<bool>
    {
        private IScalar<bool> _left;
        private IScalar<bool> _right;

        public And(IScalar<bool> left, IScalar<bool> right)
        {
            _left = left;
            _right = right;
        }

        public And(bool left, bool right) : this(new ScalarOf<bool>(left), new ScalarOf<bool>(right))
        {

        }

        public bool Value() => _left.Value() && _right.Value();
    }
}
