using Cactoos.List;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cactoos.Scalar.Async
{
    [Obsolete("For internal use")]
    internal class SequenceEqual<T> : IAsyncScalar<bool>
    {
        private IAsyncEnumerable<T> _left;
        private IAsyncEnumerable<T> _right;

        public SequenceEqual(IAsyncEnumerable<T> left, IAsyncEnumerable<T> right)
        {
            _left = left;
            _right = right;
        }

        public SequenceEqual(IAsyncEnumerable<T> left, IEnumerable<T> right) : this(left, new Async<T>(right))
        {

        }

        public async Task<bool> Value()
        {
            var left = _left.GetEnumerator();
            var right = _right.GetEnumerator();
            EqualityComparer<T> @default = EqualityComparer<T>.Default;
            while (await left.MoveNextAsync().ConfigureAwait(false)
                && await right.MoveNextAsync().ConfigureAwait(false))
            {
                if (!@default.Equals(left.Current, right.Current))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
