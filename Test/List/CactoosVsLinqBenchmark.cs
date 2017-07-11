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
        public void should_map()
        {
            var range = Enumerable.Range(0, 10000000).ToArray();

            var elapsed1 =
                new Elapsed(() =>
                    range.Select(i => i + 1)
                         .ToArray()
                ).Value();

            var elapsed2 =
                new Elapsed(() =>
                     new MappedEnumerable<int, int>(
                         range,
                         i => i + 1
                     ).ToArray()
                ).Value();

            Assert.IsTrue(elapsed1 > elapsed2);
        }

        [TestMethod]
        public void should_filter()
        {
            var range = Enumerable.Range(0, 10000000).ToArray();

            var elapsed1 =
                new Elapsed(() =>
                    range.Where(i => i % 3 == 0)
                         .ToArray()
                ).Value();

            var elapsed2 =
                new Elapsed(() =>
                     new FilteredEnumerable<int>(range, i => i % 3 == 0)
                     .ToArray()
                ).Value();

            Assert.IsTrue(elapsed1 > elapsed2);
        }

        [TestMethod]
        public void filter_and_map()
        {
            var range = Enumerable.Range(0, 10000000).ToArray();

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
