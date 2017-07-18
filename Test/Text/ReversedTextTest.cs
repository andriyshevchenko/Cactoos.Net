using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.Text;

namespace Test.Text
{
    [TestClass]
    public class ReversedTextTest
    {
        [TestMethod]
        public void should_reverse()
        {
            Assert.IsTrue(new ReversedText("cactoos").String() == "sootcac");
        }
    }
}
