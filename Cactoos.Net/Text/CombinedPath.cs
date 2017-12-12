namespace Cactoos.Text
{
    using Cactoos;
    using Cactoos.List;
    using System.Collections.Generic;
    using System.Text;

    public struct CombinedPath : IText
    {
        private IList<IText> _strings;

        public CombinedPath(params IText[] text):this((IList<IText>)text)
        {

        }

        public CombinedPath(params string[] strings)
            : this(new List<IText>(new TextCollection(strings)))
        {

        }

        public CombinedPath(IList<IText> strings)
        {
            _strings = strings;
        }

        public string String()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < _strings.Count - 1; i++)
            {
                stringBuilder.Append(_strings[i].String())
                             .Append('\\');
            }
            stringBuilder.Append(_strings[_strings.Count - 1].String());
            return stringBuilder.ToString();
        }
    }
}
