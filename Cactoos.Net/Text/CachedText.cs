namespace Cactoos.Text
{
    using Cactoos;

    public class CachedText : IText
    {
        private IText _source;
        private string actual;
        private bool enabled;

        public CachedText(IText source)
        {
            actual = string.Empty;
            enabled = false;
            _source = source;
        }

        public string String()
        {
            if (!enabled)
            {
                enabled = true;
                actual = _source.String();
            }
            return actual;
        }
    }
}
