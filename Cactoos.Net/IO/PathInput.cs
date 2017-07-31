using System.IO;

namespace Cactoos.IO
{
    /// <summary>
    /// Represents path as Input.
    /// </summary>
    public class PathInput : IInput
    {
        string _path;

        /// <summary>
        /// Initializes a new instance of <see cref="PathInput"/>.
        /// </summary>
        /// <param name="path">The path.</param>
        public PathInput(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Returns input stream.
        /// </summary>
        /// <returns>File input stream.</returns>
        public Stream Stream()
        {
            return new FileStream(_path, FileMode.Open);
        }
    }
}
