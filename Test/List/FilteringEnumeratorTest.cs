using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.List;
using System.Linq;

using static System.Collections.Generic.Create;
using static System.Functional.Func;

namespace Test.List
{
    [TestClass]
    public class FilteringEnumeratorTest
    {
        [TestMethod]
        public void should_move_next_filtering_enumerator()
        {
            Assert.AreEqual(4,
                monad(
                    new FilteringEnumerator<int>(
                        array(1, 2, 3, 4, 5, 6),
                        item => item > 3),
                    e => e.MoveNext()
                ).Current
            );
        }

        [TestMethod]
        public void should_move_next_two_times_filtering_enumerator()
        {
            Assert.AreEqual(5,
                monad(
                    monad(
                        new FilteringEnumerator<int>(
                            array(1, 2, 3, 4, 5, 6),
                            item => item > 3),
                        e => e.MoveNext()),
                    e => e.MoveNext()
                ).Current
            );
        }

        [TestMethod]
        public void should_move_next_three_times_filtering_enumerator()
        {
            Assert.AreEqual(6,
                monad(
                    monad(
                        monad(
                            new FilteringEnumerator<int>(
                                array(1, 2, 3, 4, 5, 6),
                                item => item > 3),
                            e => e.MoveNext()),
                        e => e.MoveNext()),
                    e => e.MoveNext()
                ).Current
            );
        }

            [TestMethod]
        public void should_not_move_next_four_times_filtering_enumerator()
        {
            Assert.AreEqual(false,
                monad(
                    monad(
                        monad(
                            new FilteringEnumerator<int>(
                                array(1, 2, 3, 4, 5, 6),
                                item => item > 3),
                            e => e.MoveNext()),
                        e => e.MoveNext()),
                    e => e.MoveNext()
                ).MoveNext()
            );
        }
    }
}
