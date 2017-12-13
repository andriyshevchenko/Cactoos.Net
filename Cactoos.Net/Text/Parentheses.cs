namespace Cactoos.Text
{
    public struct Parentheses : IText
    {
        private IText _source;

        public Parentheses(IText source)
        {
            _source = source;
        }
         
        public string String()
        {
            return $"({_source.String()})";
        }
    }
}
