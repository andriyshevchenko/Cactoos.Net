namespace Cactoos.Text
{
    using Cactoos;
    using System.Text;

    public struct FormatText : IText
    {
        private readonly string format;
        private readonly IText[] text;

        public FormatText(string format, params IText[] text)
        {
            this.format = format;
            this.text = text;
        }
        enum State { begin, end, no }
        public string String()
        {
            var builder = new StringBuilder();
            State state = State.no;
            int position;
            foreach (var item in format)
            {
                if (item == '{')
                {
                    state = State.begin;
                }
                else if (item == '}')
                {
                    state = State.end;
                }
                else if (state == State.begin)
                {
                    position = (int)char.GetNumericValue(item);
                    builder.Append(text[position].String());
                }
                else
                {
                    builder.Append(item);
                    state = State.no;
                }
            }
            return builder.ToString();
        }
    }
}
