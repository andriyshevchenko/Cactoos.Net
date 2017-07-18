using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.Text;

namespace Test.Text
{
    [TestClass]
    public class RepeatedTextTest
    {
        [TestMethod]
        public void should_repeat()
        {
            Assert.IsTrue(new RepeatedText("nice", 5).String() == "nicenicenicenicenice");
        }
    }
}
