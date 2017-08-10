namespace CodeGen
{
    using Cactoos;
    using Cactoos.Text;
    public struct LowerCaseName : IText
    {
        private IText _source;

        public LowerCaseName(IText source)
        {
            _source = source;
        }

        public LowerCaseName(string source) : this(new Text(source))
        {

        }

        public string String()
        {
            var name = _source.String();
            return name[0].ToString().ToLower() + name.Substring(1, name.Length - 1);
        }
    }
}
