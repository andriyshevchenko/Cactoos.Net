namespace FastXml
{
    using System.Collections.Generic;
    using Cactoos.Text;
    using Cactoos;

    public struct Lines : IText
    {
        private IList<IText> list;

        public Lines(params IText[] strings) : this((IList<IText>)strings)
        {
            
        }

        public Lines(IList<IText> list)
        {
            this.list = list;
        }

        public string String()
        {
            return new JoinedText("\r\n", list).String();
        }
    }
}
