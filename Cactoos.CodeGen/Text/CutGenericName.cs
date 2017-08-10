namespace CodeGen
{
    using Cactoos;
    using Cactoos.Text;
    public struct CutGenericName : IText
    {
        private IText _source;

        public CutGenericName(IText source)
        {
            _source = source;
        }

        public CutGenericName(string source) : this(new Text(source))
        {

        }

        public string String()
        {
            var name = _source.String();
            return name.Substring(0, name.Length - 2);
        }
    }
}
