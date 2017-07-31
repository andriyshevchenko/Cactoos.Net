using System.IO;

namespace Cactoos.IO
{
    /// <summary>
    /// Represents path as Output.
    /// </summary>
    public class PathOutput : IOutput
    {
        FileMode _mode;
        string _path;

        /// <summary>
        /// Initializes a new instance of <see cref="PathOutput"/>.
        /// </summary>
        /// <param name="path">The file path.</param>
        /// <param name="mode">Specifies a <see cref="FileMode"/> to open a stream.</param>
        public PathOutput(string path, FileMode mode = FileMode.OpenOrCreate)
        {
            _path = path;
            _mode = mode;
        }

        /// <summary>
        /// Returns output stream.
        /// </summary>
        /// <returns>The file output stream.</returns>
        public Stream Stream()
        {
            return new FileStream(_path, _mode);
        }
    }
}
