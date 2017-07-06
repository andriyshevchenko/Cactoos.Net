using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.IO;
using System.IO;

using static System.Functional.Func;
using static System.Collections.Generic.Create;
using static System.Collections.Generic.SeriesCreate;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Test.IO
{
    [TestClass]
    public class InputEnumeratorTest
    {
        class FakeEnumerable : IEnumerable<byte[]>
        {
            Stream _source;
            int _step;

            public FakeEnumerable(Stream source, int step)
            {
                _step = step;
                _source = source;
            }

            public IEnumerator<byte[]> GetEnumerator()
            {
                return new InputEnumerator(_source, _step);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        [TestMethod]
        public void should_read_memory_stream()
        {
            IEnumerable<byte> source = series(0, 4, i => (byte)i);
            byte[] arr = new FakeEnumerable(
                        new MemoryStream(array(source)), 1)
                            .SelectMany(b => b)
                            .ToArray();
            Assert.IsTrue(source.SequenceEqual(arr));
        }

        [TestMethod]
        public void should_get_current()
        {
            var enumerator =
                new InputEnumerator(
                    new MemoryStream(array(series(0, 256, i => (byte)i))), 1
                );
            Assert.IsTrue(array((byte)0).SequenceEqual(
                monad(enumerator, e => e.MoveNext()).Current));
        }

        [TestMethod]
        public void should_get_current_move_next_two_times()
        {
            var enumerator =
                monad(
                   monad(
                        new InputEnumerator(
                            new MemoryStream(array(series(0, 256, i => (byte)i))), 1
                        ),
                   e => e.MoveNext()),
                e => e.MoveNext());
            byte[] current = enumerator.Current;
            Assert.IsTrue(array((byte)1).SequenceEqual(current));
        }

        [TestMethod]
        public void should_get_current_move_next_two_times_step_2()
        {
            var enumerator =
                monad(
                   monad(
                        new InputEnumerator(
                            new MemoryStream(array(series(0, 256, i => (byte)i))), 2
                        ),
                   e => e.MoveNext()),
                e => e.MoveNext());
            byte[] current = enumerator.Current;
            Assert.IsTrue(array((byte)2, (byte)3).SequenceEqual(current));
        }

        [TestMethod]
        public void should_get_current_move_next_step_2()
        {
            var enumerator =
                new InputEnumerator(
                    new MemoryStream(array(series(0, 256, i => (byte)i))), 2
                );

            byte[] current = monad(enumerator, e => e.MoveNext()).Current;
            Assert.IsTrue(array((byte)0, (byte)1).SequenceEqual(current));
        }

        [TestMethod]
        public void should_get_current_move_next_two_times_step_64()
        {
            var enumerator =
                 new InputEnumerator(
                     new MemoryStream(
                         array(series(0, 256, index => (byte)index))), 64);


            byte[] current = monad(monad(enumerator, e => e.MoveNext()), e => e.MoveNext()).Current;
            Assert.IsTrue(current.SequenceEqual(Enumerable.Range(64, 64).Select(i => (byte)i)));
        }

        [TestMethod]
        public void should_get_current_move_next_three_times_step_64()
        {
            var enumerator =
                 new InputEnumerator(
                     new MemoryStream(
                         array(series(0, 256, index => (byte)index))), 64);

            byte[] current =
                monad(
                    monad(
                        monad(enumerator, e => e.MoveNext()), 
                        e => e.MoveNext()), 
                    e => e.MoveNext()
                ).Current;
            byte[] test = Enumerable.Range(128, 64).Select(i => (byte)i).ToArray();
            Assert.IsTrue(current.SequenceEqual(test));
        }
    }
}
