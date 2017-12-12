namespace Cactoos.Text
{
    using System.Text;

    /// <summary>
    /// A quoted text.
    /// </summary>
    public struct QuotedText : IText
    {
        private IText _text;
        
        public QuotedText(string source) : this(new Text(source))
        {

        }

        public QuotedText(IText source)
        {
            _text = source;
        }

        public string String()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('"')
                   .Append(_text.String())
                   .Append('"');
            return builder.ToString();
        }
    }
}
