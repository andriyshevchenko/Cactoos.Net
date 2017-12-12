namespace Cactoos.Text
{
    using Cactoos;

    public struct Spaced : IText
    {
        private readonly IText[] text;

        public Spaced(params IText[] text)
        {
            this.text = text;
        }

        public string String()
        {
            return new JoinedText(' ', text).String();
        }
    }
}
