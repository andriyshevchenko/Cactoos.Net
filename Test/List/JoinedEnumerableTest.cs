using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.List;

using static System.Collections.Generic.Create;
using System.Linq;

namespace Test.List
{
    [TestClass]
    public class JoinedEnumerableTest
    {
        [TestMethod]
        public void should_join()
        {
            var enumerable = new Concat<int>(array(1, 2, 3), array(4, 5, 6)).ToArray();
            Assert.IsTrue(enumerable.SequenceEqual(array(1, 2, 3, 4, 5, 6)));
        }
    }
}
