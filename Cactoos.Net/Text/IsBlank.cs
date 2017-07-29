using Cactoos;

namespace Cactoos.Reflection 
{
    /// <summary>
    /// Determines if text is null, empty or whitespace.
    /// </summary>
    public struct IsBlank : IScalar<bool>
    {
        private IText _source;

        /// <summary>
        /// Initializes a new instance of <see cref="IsBlank"/>.
        /// </summary>
        /// <param name="source">The text.</param>
        public IsBlank(string source) : this(new Cactoos.Text.Text(source))
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="IsBlank"/>.
        /// </summary>
        /// <param name="source">The text.</param>
        public IsBlank(IText source)
        {
            _source = source;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>True if string is null, empty or whitespace.</returns>
        public bool Value()
        {
            string source = _source.String();
            return source == string.Empty
                || string.IsNullOrWhiteSpace(source);
        }
    }
}
