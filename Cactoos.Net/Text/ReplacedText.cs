namespace Cactoos.Text
{
    using Cactoos;

    public struct ReplacedText : IText
    {
        private IText source;
        private readonly char old;
        private readonly char replace;

        public ReplacedText(string source, char old, char replace)
            : this(new Text(source), old, replace)
        {

        }

        public ReplacedText(IText source, char old, char replace)
        {
            this.source = source;
            this.old = old;
            this.replace = replace;
        }

        public string String()
        {
            return source.String().Replace(old, replace);
        }
    }
}
