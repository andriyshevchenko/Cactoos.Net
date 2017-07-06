using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.IO;
using System.IO;
using System.Linq;

using static System.Functional.Func;
using static System.Collections.Generic.Create;
using static System.Collections.Generic.SeriesCreate;


namespace Test.IO
{
    [TestClass]
    public class OutputEnumeratorTest
    {
        [TestMethod]
        public void should_move_next()
        {
            var memoryStream = new MemoryStream();
            var test = series(0, 256, i => (byte)i);
            var enumerator = new OutputEnumerator(test, memoryStream, 1);

            while (enumerator.MoveNext())
            {
            }

            byte[] target =
                monad(
                    array<byte>(256),
                    buffer =>
                        monad(
                            memoryStream, 
                            stream => stream.Position = 0
                        ).Read(buffer, 0, (int)memoryStream.Length)
                );
            Assert.IsTrue(
                test.SequenceEqual(
                    target
                ));
        }
    }
}
