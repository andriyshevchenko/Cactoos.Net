using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.List;
using System.Linq;

using static System.Collections.Generic.Create;

namespace Test.List
{
    [TestClass]
    public class FilteredEnumerableTest
    {
        [TestMethod]
        public void should_filter()
        {
            Assert.IsTrue(
                new Filtered<int>(
                    array(1, 2, 3, 4, 5, 6), 
                    item => item > 3)
                    .SequenceEqual(array(4, 5, 6)));
        }
    }
}
