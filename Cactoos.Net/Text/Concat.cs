namespace Cactoos.Text
{
    using Cactoos;
    using Cactoos.List;
    using System.Collections.Generic;
    using System.Text;

    public struct Concat : IText
    {
        private IList<IText> _strings;
 

        public Concat(params string[] strings)
            : this(new List<IText>(new TextCollection(strings)))
        {

        }

        public Concat(IList<IText> strings)
        {
            _strings = strings;
        }

        public Concat(params IText[] strings):this((IList<IText>)strings)
        {

        }

        public string String()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < _strings.Count; i++)
            {
                stringBuilder.Append(_strings[i].String());
            }

            return stringBuilder.ToString();
        }
    }
}
