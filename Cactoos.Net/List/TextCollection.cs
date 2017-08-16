using System.Collections;
using System.Collections.Generic;

namespace Cactoos.List
{
    /// <summary>
    /// Allows to convert collection of strings to collection of equivalent text.
    /// </summary>
    public class TextCollection : IEnumerable<IText>
    {
        private IEnumerable<string> _source;

        public TextCollection(IEnumerable<string> source)
        {
            _source = source;
        }

        public IEnumerator<IText> GetEnumerator()
        {
            foreach (var item in _source)
            {
                yield return new Text.Text(item);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
