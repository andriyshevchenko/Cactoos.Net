using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.Reflection;
using Cactoos.Text;
using Cactoos;

namespace Test.Reflection
{
    [TestClass]
    public class InferredNameTest
    {
        [TestMethod]
        public void should_infer()
        {
            Assert.AreEqual(
                "Cactoos.IText", 
                new InferredName(
                    new AssemblyOfType<IText>(),
                    nameof(IText)
                ).String()
            );
        }
    }
}
