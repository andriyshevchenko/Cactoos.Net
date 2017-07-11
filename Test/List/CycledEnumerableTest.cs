using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.List;
using System.Linq;

using static System.Collections.Generic.Create;

namespace Test.List
{
    [TestClass]
    public class CycledEnumerableTest
    {
        [TestMethod]
        public void should_loop()
        {
            Assert.IsTrue(array(1, 2, 3, 1, 2, 3).SequenceEqual(new CycledEnumerable<int>(array(1, 2, 3), 2)));
        }
    }
}
    