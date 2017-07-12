using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.IO;

using static System.Collections.Generic.Create;
using static System.Functional.FlowControl;
using System.IO;
using Cactoos.Text;
using System.Linq;
using System.Text;

namespace Test.IO
{
    [TestClass]
    public class OutputAsEnumerableTest
    {
        [TestMethod]
        public void should_write_to_output()
        {
            new Output(
                new StringInput("nice try fascist"),
                new PathOutput("file2.txt", FileMode.Truncate)
            ).Count();

            Assert.AreEqual(
                "nice try fascist",
                new BytesText(
                    new Input(
                        new PathInput("file2.txt")
                    ),
                    Encoding.UTF8
                ).String());
        }

        [TestMethod]
        public void should_read_from_input()
        {
            byte[] trg = array<byte>(1024);
            var name = Path.GetTempFileName();
            File.WriteAllBytes(name, array<byte>(0, 1, 2, 2, 2, 5));
            
            use(
                new Output(
                    new PathInput(name),
                    new BytesAsOutput(trg)
                ),
                Enumerable.Count
            );
            var test = new Input(new PathInput(name)).ToArray();

            Assert.IsTrue(test.SequenceEqual(part(trg, 0, test.Length)));
        }
    }
}
