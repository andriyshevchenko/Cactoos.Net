using System.IO;

namespace Cactoos
{
    /// <summary>
    /// Input
    /// </summary>
    public interface IInput
    {
        /// <summary>
        /// Get stream value
        /// </summary>
        /// <returns>Stream</returns>
        Stream Stream();
    }
}
