namespace Cactoos.Text
{
    using Cactoos;
    using Cactoos.Text;

    public struct TextEqual : IScalar<bool>
    {
        private IText expected;
        private IText actual;

        public TextEqual(string actual, string expected)
            : this(new Text(actual), expected)
        {

        }

        public TextEqual(IText actual, string expected)
            : this(actual, new Text(expected))
        {

        }

        public TextEqual(IText actual, IText expected)
        {
            this.expected = new RemoveEndLine(new Collapsed(expected, '\r'));
            this.actual = new RemoveEndLine(new Collapsed(actual, '\r'));
        }

        public bool Value()
        {
            string actualString = actual.String();
            string expectedString = expected.String();
            bool ret = true;
            if (actualString.Length != expectedString.Length)
            {
                ret = false;
            }
            else
            {
                for (int i = 0; i < actualString.Length; i++)
                {
                    if (expectedString[i] != actualString[i])
                    {
                        ret = false;
                        break;
                    }
                } 
            }
            return ret;
        }
    }
}
