namespace Cactoos.Text
{
    using Cactoos;

    public struct ToString : IText
    {
        private readonly object source;

        public ToString(object source)
        {
            this.source = source;
        }

        public string String()
        {
            return source.ToString();
        }
    }
}
