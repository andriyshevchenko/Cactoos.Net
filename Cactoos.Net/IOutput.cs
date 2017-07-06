using System.IO;

namespace Cactoos
{
    /// <summary>
    /// Output
    /// </summary>
    public interface IOutput
    {
        /// <summary>
        /// Get stream value
        /// </summary>
        /// <returns>Stream</returns>
        Stream Stream();
    }
}
