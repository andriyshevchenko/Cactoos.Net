using System;
using System.Collections;
using System.Collections.Generic;



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
            return 
                new TextCollection(
                    new Mapped<Exception, string>(
                        _source.Errors(),
                        err => err.ToString()
                    )
                ).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
