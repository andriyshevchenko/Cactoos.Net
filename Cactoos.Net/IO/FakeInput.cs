using System.IO;

namespace Cactoos.IO
{
    /// <summary>
    /// The fake input. To use with unit tests.
    /// </summary>
    public class FakeInput : IInput
    {
        /// <summary>
        /// Gets the input stream.
        /// </summary>
        /// <returns>The stream.</returns>
        public Stream Stream()
        {
            return new ByteInput(new EmptyBytes()).Stream();
        }
    }
}
