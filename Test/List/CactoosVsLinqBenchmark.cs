using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using Cactoos.List;
using Cactoos.Scalar;

namespace Test.List
{
    [TestClass]
    public class CactoosVsLinqBenchmark
    {
        [TestMethod]
        public void filter_and_map()
        {
            System.Collections.Generic.IEnumerable<int> range = Enumerable.Range(0, 10000000);

            var elapsed1 =
                new Elapsed(() =>
                    range.Where(i => i % 3 == 0)
                         .Select(i => i + 1)
                         .ToArray()
                ).Value();

            var elapsed2 =
                new Elapsed(() =>
                     new MappedEnumerable<int, int>(
                         new FilteredEnumerable<int>(range, i => i % 3 == 0),
                         i => i + 1
                     ).ToArray()
                ).Value();

            Assert.IsTrue(elapsed1 > elapsed2);
        }
    }
}
