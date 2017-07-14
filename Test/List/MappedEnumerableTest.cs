using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Cactoos.List;

using static System.Collections.Generic.Create;


namespace Test.List
{
    [TestClass]
    public class MappedEnumerableTest
    {
        [TestMethod]
        public void should_map()
        {
            var test = array(1, 2, 3, 4, 5, 6);
            var enumerable = new Mapped<int, string>(test, item => item.ToString());
            Assert.IsTrue(enumerable.SequenceEqual(array("1", "2", "3", "4", "5", "6")));
        }
    }
}
