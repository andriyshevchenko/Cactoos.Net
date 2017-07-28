namespace Cactoos.Scalar
{
    public struct Not : IScalar<bool>
    {
        private IScalar<bool> _value;

        public Not(bool value) : this(new ValueScalar<bool>(value))
        {
            
        }

        public Not(IScalar<bool> value)
        {
            _value = value;
        }

        public bool Value() => !_value.Value();
    }
}
