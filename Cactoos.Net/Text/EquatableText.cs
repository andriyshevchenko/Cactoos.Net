using System;

namespace Cactoos.Text
{
    public class EquatableText : IText, IEquatable<IText>
    {
        private IText _source;

        public EquatableText(IText source)
        {
            _source = source;
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
