namespace Cactoos.Text
{
    using Cactoos;
    using System.Text;

    public struct Collapsed : IText
    {
        private readonly IText text;
        private char[] collapse;

        public Collapsed(IText text, params char[] collapse)
        {
            this.text = text;
            this.collapse = collapse;
        }

        public string String()
        {
            StringBuilder builder = new StringBuilder();
            string str = text.String();
            for (int i = 0; i < str.Length; i++)
            {
                bool append = true;
                for (int j = 0; j < collapse.Length; j++)
                {
                    if (str[i] == collapse[j])
                    {
                        append = false;
                        break;
                    }
                }
                if (append)
                {
                    builder.Append(str[i]);
                }
            }
            return builder.ToString();
        }
    }
}
