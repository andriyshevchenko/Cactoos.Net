namespace Cactoos.Text
{
    using Cactoos;
    using Cactoos.Text;

    public struct WithEndline : IText
    {
        private IText _source;

        public WithEndline(string source) : this(new Text(source))
        {

        }

        public WithEndline(IText source)
        {
            _source = source;
        }

        public string String()
        {
            return _source.String() + '\r' + '\n';
        }
    }
}
