using System.Collections;
using System.Collections.Generic;

using static System.Collections.Generic.Create;

namespace Cactoos.List
{
    /// <summary>
    /// Get the errors from <see cref="IAttempt"/> as strings.
    /// </summary>
    public class ErrorsAsText : IEnumerable<IText>
    {
        private IAttempt _source;

        /// <summary>
        /// Initializes a new instance of <see cref="ErrorsAsText"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        public ErrorsAsText(IAttempt source)
        {
            _source = source;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<IText> GetEnumerator()
        {
            return  map(_source.Errors(), error => (IText)new Text.Text(error.ToString())).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
