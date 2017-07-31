using System;

namespace Cactoos
{
    /// <summary>
    /// An attempt.
    /// </summary>
    public interface IAttempt
    {
        /// <summary>
        /// Determines if attempt wasn't succesful.
        /// </summary>
        /// <returns>True, if attemt has errors.</returns>
        bool HasErrors();

        /// <summary>
        /// Returns the errors.
        /// </summary>
        /// <returns>The errors.</returns>
        Exception[] Errors();
    }
}
