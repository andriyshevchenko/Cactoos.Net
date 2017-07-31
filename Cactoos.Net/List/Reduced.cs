using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cactoos.List
{
    public class Reduced<T> : IScalar<T>
    {
        private IEnumerable<T> _source;
        private Func<T, T, T> _aggregator;

        public Reduced(IEnumerable<T> source, Func<T, T, T> aggregator)
        {
            _source = source;
            _aggregator = aggregator;
        }

        public T Value()
        {
            return _source.Aggregate(_aggregator);
        }
    }
}
