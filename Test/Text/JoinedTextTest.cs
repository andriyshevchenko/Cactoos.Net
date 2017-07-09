using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.Text;
using System.Linq;

using static System.Collections.Generic.Create;

namespace Test.Text
{
    [TestClass]
    public class JoinedTextTest
    {
        [TestMethod]
        public void should_join_strings()
        {
            Assert.AreEqual("hello-cactoos", new JoinedText("-", "hello", "cactoos").String());
        }

        [TestMethod]
        public void should_join_three_strings()
        {
            Assert.AreEqual("hello-cactoos-net", new JoinedText("-", "hello", "cactoos", "net").String());
        }

        [TestMethod]
        public void should_join_a_lot_of_strings()
        {
            var strings = Enumerable.Repeat("cactoos", 100).ToArray();
            Assert.IsTrue(
                new JoinedText("--", strings)
                    .String()
                    .Split(array("--"), StringSplitOptions.None)
                    .SequenceEqual(strings));
        }
    }
}
