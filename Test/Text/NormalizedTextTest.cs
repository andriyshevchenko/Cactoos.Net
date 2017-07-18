using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.Text;

namespace Test.Text
{
    [TestClass]
    public class NormalizedTextTest
    {
        private const string OriginalPhraze = "hello   cactoos";

        [TestMethod]
        public void should_normalize()
        {
            Assert.IsTrue(new NormalizeText(OriginalPhraze).String() == "hello cactoos");
        }

        [TestMethod]
        public void should_not_be_the_same_as_normalized_text()
        {
            Assert.IsFalse(new NormalizeText(OriginalPhraze).String() == OriginalPhraze);
        }

        [TestMethod]
        public void should_normalize_large_sequence()
        {
            Assert.IsTrue(new NormalizeText("1  1   1    1      1").String() == "1 1 1 1 1");
        }
    }
}
