using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.IO;

using static System.Collections.Generic.Create;

namespace Test.IO
{
    [TestClass]
    public class OutputAsEnumerableTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            array<byte>(
                new OutputAsEnumerable(
                    new StringInput("nice try nigga"),
                    new PathOutput("file2.txt")
                )
            );
        }
    }
}
