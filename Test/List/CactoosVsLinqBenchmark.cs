using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Cactoos.List;
using Cactoos.Scalar;

namespace Test.List
{
    /// <summary>
    /// Performance benchmark
    /// </summary>
    [TestClass]
    public class CactoosVsLinqBenchmark
    {
        private const float MAX_OFFSET = 0.3f;

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
                     new Mapped<int, int>(
                         range,
                         i => i + 1
                     ).ToArray()
                ).Value();

            Assert.IsTrue(new Percents(elapsed1.Milliseconds, elapsed2.Milliseconds).Value() < MAX_OFFSET);
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
                     new Filtered<int>(range, i => i % 3 == 0)
                     .ToArray()
                ).Value();

            Assert.IsTrue(new Percents(elapsed1.Milliseconds, elapsed2.Milliseconds).Value() < MAX_OFFSET);
        }

        [TestMethod]
        public void filter_and_map()
        {
            var range = Enumerable.Range(0, 10000000).ToArray();

            Assert.IsTrue(
                new Percents(
                    new Elapsed(() =>
                        range.Where(i => i % 3 == 0)
                             .Select(i => i + 1)
                             .ToArray()
                    ).Value().Milliseconds, 
                    new Elapsed(() =>
                        new Mapped<int, int>(
                            new Filtered<int>(range, i => i % 3 == 0),
                            i => i + 1
                        ).ToArray()
                    ).Value().Milliseconds
                ).Value() < MAX_OFFSET);
        }
    }
}
