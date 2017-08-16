namespace Cactoos.Text
{
    /// <summary>
    /// Determines if text is C# name with a namespace.
    /// </summary>
    public struct IsNamespaced : IScalar<bool>
    {
        private IText _source;

        /// <summary>
        /// Initializes a new instance of <see cref="IsNamespaced"/>.
        /// </summary>
        /// <param name="source">The text.</param>
        public IsNamespaced(string source) : this(new Cactoos.Text.Text(source))
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="IsNamespaced"/>.
        /// </summary>
        /// <param name="source">The text.</param>
        public IsNamespaced(IText source)
        {
            _source = source;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>True if c# name has a namespace.</returns>
        public bool Value()
        {
            return _source.String().Contains(".");
        }
    }
}
