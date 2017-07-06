using InputValidation;
using System.IO;

namespace Cactoos.IO
{
    /// <summary>
    /// Input with null check
    /// </summary>
    public class NotNullInput : IInput
    {
        readonly IInput _source;

        /// <summary>
        /// Initializes a new instance of <see cref="NotNullInput"/>
        /// </summary>
        /// <param name="source"></param>
        public NotNullInput(IInput source)
        {
            _source = source;
        }

        /// <summary>
        /// Get stream value
        /// </summary>
        /// <returns>Stream</returns>
        public Stream Stream()
        {
            return _source.CheckNotNull("NULL instead of a valid input")
                          .Stream();
        }
    }
}
