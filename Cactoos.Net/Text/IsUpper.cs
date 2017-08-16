namespace Cactoos.Text
{
    public struct IsUpper : IScalar<bool>
    {
        private IText _source;

        public IsUpper(IText source)
        {
            _source = source;
        }

        public IsUpper(string source) : this(new Text(source))
        {

        }


        public bool Value()
        {
            string source = _source.String();
            for (int i = 0; i < source.Length; i++)
            {
                if (char.IsLower(source[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
