using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.IO;
using System.Linq;
using Cactoos.Text;

namespace Test.IO
{
    [TestClass]
    public class InputAsEnumerableTest
    {
        [TestMethod]
        public void should_read()
        {
            var target =
                new InputCollection(
                       new StringInput("hello world")
                );
 
            byte[] test = new TextBytes("hello world").Bytes();
            Assert.IsTrue(test.SequenceEqual(target)); 
        }
    }
}
