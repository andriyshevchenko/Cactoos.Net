using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.Scalar;
using System.Linq;

using static System.Collections.Generic.Create;

namespace Test.Scalar
{
    [TestClass]
    public class CachedScalarTest
    {
        [TestMethod]
        public void should_cache()
        {
            int i = 0;
            var scalar =
                new CachedScalar<int>(
                    new FuncScalar<int>(() => i++)
                );
            Assert.IsTrue(
                array(scalar.Value(), scalar.Value())
                .SequenceEqual(array(0, 0))
            );
        }
    }
}
