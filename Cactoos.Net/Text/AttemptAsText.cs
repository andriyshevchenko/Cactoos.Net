using Cactoos.List;

namespace Cactoos.Text
{
    public class AttemptAsText : IText
    {
        private IAttempt _source;

        public AttemptAsText(IAttempt source)
        {
            _source = source;
        }

        public string String()
        {
            return new JoinedText('\n', new ErrorsAsText(_source)).String();
        }
    }
}
