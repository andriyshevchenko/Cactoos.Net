using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.IO.Async;
using Cactoos.IO;
using Cactoos.Text;
using Cactoos.Scalar.Async;

namespace Test.IO.Async
{
    [TestClass]
    public class AsyncInputTest
    {
        [TestMethod]
        public async System.Threading.Tasks.Task should_read()
        {
            Assert.IsTrue(
                await new SequenceEqual<byte>(
                    new AsyncInput(
                        new StringInput("hello world")
                    ),
                    new TextBytes("hello world").Bytes()
                ).Value()
            );
        }
    }
}
