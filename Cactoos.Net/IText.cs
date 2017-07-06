using System;

namespace Cactoos
{
    /// <summary>
    /// Represents a value, which can be converted to string
    /// </summary>
    public interface IText : IComparable<IText>, IEquatable<IText>
    {
        /// <summary>
        /// Get string value
        /// </summary>
        /// <returns>String value</returns>
        string AsString();
    }
}
