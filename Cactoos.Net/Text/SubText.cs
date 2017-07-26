namespace Cactoos.Text
{
    public class SubText : IText
    {
        private IText _source;
        private int _start;
        private int _length;

        public SubText(IText source, int start, int length)
        {
            _source = source;
            _start = start;
            _length = length;
        }

        public SubText(string source, int start, int length) : this(new Text(source), start, length)
        {

        }

        public string String()
        {
            return _source.String().Substring(_start, _length);
        }
    }
}
