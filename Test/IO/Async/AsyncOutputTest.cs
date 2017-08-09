using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.IO;
using System.IO;
using Cactoos.Text;
using System.Linq;
using System.Text;
using Cactoos.IO.Async;
using Cactoos.Scalar.Async;

using static System.Collections.Generic.Create;

namespace Test.IO.Async
{
    [TestClass]
    public class AsyncOutputTest
    {
        [TestMethod]
        public async System.Threading.Tasks.Task should_write_to_output()
        {
            using (var output = new AsyncOutput(
                    new StringInput("nice try fascist"),
                    new PathOutput("async_output_test.txt", FileMode.Truncate)
                ))
            {
                await new Count<byte>(output).Value();
            }

            Assert.AreEqual(
                "nice try fascist",
                new BytesText(
                    new Input(
                        new PathInput("async_output_test.txt")
                    ),
                    Encoding.UTF8
                ).String());
        }

        [TestMethod]
        public async System.Threading.Tasks.Task should_read_from_input()
        {
            byte[] trg = array<byte>(1024);
            var name = Path.GetTempFileName();
            File.WriteAllBytes(name, array<byte>(0, 1, 2, 2, 2, 5));

            using (var output = new AsyncOutput(
                    new PathInput(name),
                    new BytesAsOutput(trg)
                ))
            {
                await new Count<byte>(output).Value();
            }

            var test = new Input(new PathInput(name)).ToArray();

            Assert.IsTrue(test.SequenceEqual(part(trg, 0, test.Length)));
        }
    }
}
