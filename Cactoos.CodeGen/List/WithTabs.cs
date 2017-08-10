using System.Collections.Generic;
using System.Collections;

namespace CodeGen.Text
{
    public struct WithTabs : IEnumerable<string>
    {
        private const string Space = "    ";
        private IEnumerable<string> _source;

        public WithTabs(IEnumerable<string> source)
        {
            _source = source;
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (var item in _source)
            {
                yield return Space + item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
