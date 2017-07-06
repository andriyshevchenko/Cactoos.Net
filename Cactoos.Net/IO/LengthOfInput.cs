using static System.Functional.FlowControl;

namespace Cactoos.IO
{
    /// <summary>
    /// Count 
    /// </summary>
    public class LengthOfInput : IScalar<long>
    {
        private IInput _source;
        private int _size;

        /// <summary>
        /// Initializes a new instance of <see cref="LengthOfInput"/>
        /// </summary>
        /// <param name="source">Source input</param>
        /// <param name="size">Required size</param>
        public LengthOfInput(IInput source, int size)
        {
            _source = source;
            _size = size;
        }

        /// <summary>
        /// Converts it to the long value.
        /// </summary>
        /// <returns>Typed value of a scalar</returns>
        public long Value()
        {
            return use(_source.Stream(), stream => stream.Length);    
        }
    }
}
