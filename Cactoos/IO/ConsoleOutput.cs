using System;
using System.IO;

namespace Cactoos.IO
{
    /// <summary>
    /// The standard output.
    /// </summary>
    public class ConsoleOutput : IOutput
    {
        /// <summary>
        /// Get stream value
        /// </summary>
        /// <returns>Stream</returns>
        public Stream Stream()
        {
            return Console.OpenStandardOutput();
        }
    }
}
