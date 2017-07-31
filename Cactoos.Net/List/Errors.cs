using System.Collections;
using System.Collections.Generic;

using static System.Collections.Generic.Create;

namespace Cactoos.List
{
    /// <summary>
    /// Get the errors from <see cref="IAttempt"/> as strings.
    /// </summary>
    public class Errors : IEnumerable<string>
    {
        private IAttempt _source;

        /// <summary>
        /// Initializes a new instance of <see cref="Errors"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public Errors(IAttempt source)
        {
            _source = source;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<string> GetEnumerator()
        {
            return  map(_source.Errors(), error => error.ToString()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
