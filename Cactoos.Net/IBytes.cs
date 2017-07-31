namespace Cactoos
{
    /// <summary>
    /// Represent a value, which can be treated as byte array.
    /// </summary>
    public interface IBytes
    {
        /// <summary>
        /// Converts it to byte array.
        /// </summary>
        /// <returns>The byte[] value.</returns>
        byte[] Bytes();
    }
}
