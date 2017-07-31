using System;
using System.IO;

namespace Cactoos.IO
{
    /// <summary>
    /// The standard input.
    /// </summary>
    public class ConsoleInput : IInput
    {
        /// <summary>
        /// Get stream value
        /// </summary>
        /// <returns>Stream</returns>
        public Stream Stream()
        {
            return Console.OpenStandardInput();
        }
    }
}
