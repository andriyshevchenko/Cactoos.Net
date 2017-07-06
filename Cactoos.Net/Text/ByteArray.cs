namespace Cactoos.Text
{
    /// <summary>
    /// Array as Bytes
    /// </summary>
    public class ByteArray : IBytes
    {
        byte[] _source;

        /// <summary>
        /// Initializes a new instance of ByteArray
        /// </summary>
        /// <param name="source">Parameter list</param>
        public ByteArray(params byte[] source)
        {
            _source = source;
        }

        /// <summary>
        /// Converts it to byte array
        /// </summary>
        /// <returns>Byte value</returns>
        public byte[] Bytes() => _source;
    }
}
