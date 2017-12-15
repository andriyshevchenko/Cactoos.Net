
using System.IO;

namespace Cactoos.IO
{
    /// <summary>
    /// Output with null check.
    /// </summary>
    public class NotNullOutput : IOutput
    {
        readonly IOutput _source;

        /// <summary>
        /// Initializes a new instance of <see cref="NotNullOutput"/>.
        /// </summary>
        /// <param name="source">The output.</param>
        public NotNullOutput(IOutput source)
        {
            _source = source;
        }

        /// <summary>
        /// Get stream value.
        /// </summary>
        /// <returns>The stream.</returns>
        public Stream Stream()
        {
            return (_source ?? throw new System.Exception("NULL instead of a valid output"))
                        .Stream();
        }
    }
}
