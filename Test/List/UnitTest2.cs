using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.List;
using System.Linq;

namespace Test.List
{
    [TestClass]
    public class InfiniteTest
    {
        [TestMethod]
        public void should_not_end()
        {
            Assert.ThrowsException<InvalidOperationException>(() => 
            {
                new Infinite<int>(i =>
                {
                    if (i > 1000000)
                    {
                        throw new InvalidOperationException();
                    }
                    return i;
                }).ToArray();
            });
        }
    }
}
