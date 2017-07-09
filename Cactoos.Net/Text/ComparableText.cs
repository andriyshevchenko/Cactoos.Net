using System;
namespace Cactoos.Text
{
    public class ComparableText : IText, IComparable<IText>
    {
        private IText _source;

        public ComparableText(IText source)
        {
            _source = source;
        }

        public int CompareTo(IText other)
        {
            return String().CompareTo(other.String());
        }

        public bool Equals(IText other)
        {
            return String().Equals(other.String());
        }

        public string String()
        {
            return _source.String();
        }
    }
}
