namespace Cactoos.Text
{
    public class LowerText : IText
    {
        private IText _source;

        public LowerText(IText source)
        {
            _source = source;
        }

        public LowerText(string source):this(new Cactoos.Text.Text(source))
        {
            
        }

        public string String()
        {
            return _source.String().ToLower();
        }
    }
}
