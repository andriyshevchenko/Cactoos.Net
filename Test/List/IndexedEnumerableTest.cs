using Cactoos.List;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

using static System.Collections.Generic.Create;

namespace Test.List
{
    [TestClass]
    public class IndexedEnumerableTest
    {
        [TestMethod]
        public void should_index()
        {
            Assert.IsTrue(
                new Indices<int>(
                    new Indexed<int>(
                       array(1, 1, 1, 1, 1)
                    )
                ).SequenceEqual(
                    array(0, 1, 2, 3, 4)
                  )
            );
        }
    }
}
