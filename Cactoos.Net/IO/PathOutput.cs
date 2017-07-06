using System.IO;

namespace Cactoos.IO
{
    /// <summary>
    /// Represents path as Output
    /// </summary>
    public class PathOutput : IOutput
    {
        string _path;

        /// <summary>
        /// Initializes a new instance of <see cref="PathOutput"/>
        /// </summary>
        /// <param name="path"></param>
        public PathOutput(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Returns input stream
        /// </summary>
        /// <returns>File output stream</returns>
        public Stream Stream()
        {
            return new FileStream(_path, FileMode.OpenOrCreate);
        }
    }
}
