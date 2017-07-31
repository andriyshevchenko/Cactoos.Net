using System;
using System.IO;

namespace Cactoos.IO
{
    /// <summary>
    /// The standard error output.
    /// </summary>
    public class StdErrOutput : IOutput
    {
        /// <summary>
        /// Get stream value
        /// </summary>
        /// <returns>Stream</returns>
        public Stream Stream()
        {
            return Console.OpenStandardError();
        }
    }
}
