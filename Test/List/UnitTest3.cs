using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.List;
using System.Linq;

using static System.Collections.Generic.Create;

namespace Test.List
{
    [TestClass]
    public class LimitedTest
    {
        [TestMethod]
        public void should_limit()
        {
            Assert.IsTrue(array(1, 2, 3).SequenceEqual(new LimitedEnumerable<int>(array(1, 2, 3, 4), 3)));
        }
    }
}
