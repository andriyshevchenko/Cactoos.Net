namespace Cactoos.Text
{
    /// <summary>
    /// String as text. Keeps the same string value inside.
    /// </summary>
    public class StringText : IText
    {
        string _source;

        /// <summary>
        /// Initializes a new instance of StringText
        /// </summary>
        /// <param name="source"></param>
        public StringText(string source)
        {
            _source = source;
        }

        /// <summary>
        /// Get string value
        /// </summary>
        /// <returns>String value</returns>
        public string String() => _source;

        /// <summary>
        /// Compares IText to another
        /// </summary>
        /// <param name="other"></param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The
        /// return value has these meanings: Value Meaning Less than zero This instance precedes
        /// other in the sort order. Zero This instance occurs in the same position in the
        /// sort order as other. Greater than zero This instance follows other in the sort
        /// order.
        /// </returns>
        public int CompareTo(IText other) => _source.CompareTo(other.String());

        /// <summary>
        /// Indicates whether the current object is equal to another IText.
        /// </summary>
        /// <param name="other">IText to compare</param>
        /// <returns>True if objects are equal</returns>
        public bool Equals(IText other) => _source.Equals(other.String());
    }
}
