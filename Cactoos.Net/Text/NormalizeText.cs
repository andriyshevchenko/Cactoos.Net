using System.Text;

namespace Cactoos.Text
{
    public class NormalizeText : IText
    {
        private IText _source;

        public NormalizeText(IText source)
        {
            _source = source;
        }

        public NormalizeText(string source) : this(new Text(source))
        {

        }

        public string String()
        {
            var builder = new StringBuilder();
            bool sequenceStarted = false;
            string original = _source.String();
            for (int i = 0; i < original.Length; i++)
            {
                char item = original[i];
                if (item == ' ')
                {
                    if (!sequenceStarted)
                    {
                        builder.Append(item);
                        sequenceStarted = true;
                    }
                }
                else
                {
                    sequenceStarted = false;
                    builder.Append(item);
                }
            }
            return builder.ToString();
        }
    }
}
