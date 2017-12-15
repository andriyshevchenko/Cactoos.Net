namespace Cactoos.Text
{
    using Cactoos;

    public struct RemoveEndLine : IText
    {
        private readonly IText text;

        public RemoveEndLine(IText text)
        {
            this.text = text;
        }

        public string String()
        {
            string str = text.String();
            if (str[str.Length-1] == '\n')
            {
                int m_shift = 1;
                if (str[str.Length-2] == '\r')
                {
                    m_shift = 2;
                }
                return str.Substring(0, str.Length - m_shift);
            }
            return str;
        }
    }
}
