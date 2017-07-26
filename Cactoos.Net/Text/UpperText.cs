namespace Cactoos.Text
{
    public class UpperText : IText
    {
        private IText _source;

        public UpperText(IText source)
        {
            _source = source;
        }

        public UpperText(string source) : this(new Cactoos.Text.Text(source))
        {

        }

        public string String()
        {
            return _source.String().ToUpper();
        }
    }
}
