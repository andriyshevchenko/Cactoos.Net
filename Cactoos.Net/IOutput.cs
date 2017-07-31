using System.IO;

namespace Cactoos
{
    /// <summary>
    /// Output.
    /// </summary>
    public interface IOutput
    {
        /// <summary>
        /// Get the stream value.
        /// </summary>
        /// <returns>The stream.</returns>
        Stream Stream();
    }
}
