namespace Cactoos.Text
{
    /// <summary>
    /// String as text. Keeps the same string value inside.
    /// </summary>
    public struct Text : IText
    {
        string _source;

        /// <summary>
        /// Initializes a new instance of StringText
        /// </summary>
        /// <param name="source"></param>
        public Text(string source)
        {
            _source = source;
        }

        /// <summary>
        /// Get string value
        /// </summary>
        /// <returns>String value</returns>
        public string String() => _source;
    }
}
