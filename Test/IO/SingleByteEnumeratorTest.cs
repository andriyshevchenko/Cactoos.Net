using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.IO;
using System.IO;

using static System.Functional.Func;
using static System.Collections.Generic.SeriesCreate;

namespace Test.IO
{
    [TestClass]
    public class SingleByteEnumeratorTest
    {
        [TestMethod]
        public void should_get_current_equal_to_zero()
        {
            var enumerator =
                new SingleByteEnumerator(
                    new OutputEnumerator(series(0, 256, index => (byte)index), new MemoryStream(), 4)
                );

            var buffer = monad(enumerator, e => e.MoveNext()).Current;
            Assert.AreEqual((byte)0, buffer);
        }

        [TestMethod]
        public void should_move_next_two_times()
        {
            var enumerator =
                 new SingleByteEnumerator(
                     new OutputEnumerator(series(0, 256, index => (byte)index), new MemoryStream(), 4)
                 );

            var buffer = 
                monad(
                    monad(enumerator, e => e.MoveNext()), 
                    e => e.MoveNext()
                ).Current;
            Assert.AreEqual(1, buffer);
        }

        [TestMethod]
        public void should_move_next_three_times()
        {
            var enumerator =
             new SingleByteEnumerator(
                 new OutputEnumerator(series(0, 256, index => (byte)index), new MemoryStream(), 4)
             );

            for (int i = 0; i < 3; i++)
            {
                enumerator.MoveNext();
            } 

            Assert.AreEqual(2, enumerator.Current);
        }
    }
}
