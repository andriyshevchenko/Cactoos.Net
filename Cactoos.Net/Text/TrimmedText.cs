namespace Cactoos.Text
{
    public class TrimmedText : IText
    {
        private IText _source;

        public TrimmedText(IText source)
        {
            _source = source;
        }

        public TrimmedText(string source) : this(new Cactoos.Text.Text(source))
        {

        }

        public string String()
        {
            return _source.String().Trim();
        }
    }
}
