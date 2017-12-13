using Cactoos.Scalar;

namespace Cactoos.Text
{
    /// <summary>
    /// Bool as text.
    /// </summary>
    public class BoolText : IText
    {
        private IScalar<bool> _source;

        /// <summary>
        /// Initializes a new instance of <see cref="BoolText"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public BoolText(IScalar<bool> source)
        {
            _source = source;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="BoolText"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public BoolText(bool source) : this(new ScalarOf<bool>(source))
        {

        }

        /// <summary>
        /// Get string value.
        /// </summary>
        /// <returns>The string value.</returns>
        public string String()
        {
            return _source.Value().ToString();
        }
    }
}
