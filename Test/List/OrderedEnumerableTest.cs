using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.List;
using System.Linq;

using static System.Collections.Generic.Create;

namespace Test.List
{
    [TestClass]
    public class OrderedEnumerableTest
    {
        [TestMethod]
        public void should_sort()
        {
            Assert.IsTrue(array(1, 2, 3, 4, 5, 6).SequenceEqual(new Ordered<int>(array(1, 3, 2, 6, 4, 5), SortOrder.Ascending)));
        }

        [TestMethod]
        public void should_sort_descending()
        {
            Assert.IsTrue(array(6, 5, 4, 3, 2, 1).SequenceEqual(new Ordered<int>(array(1, 3, 2, 6, 4, 5), SortOrder.Descending)));
        }
    }
}
