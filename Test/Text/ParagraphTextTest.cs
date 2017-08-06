using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.Text;
using Cactoos.List;

using static System.Collections.Generic.Create;
using Cactoos.Scalar;

namespace Test.Text
{
    [TestClass]
    public class ParagraphTextTest
    {
        private const string ExampleText = "I said a hip hop the hippie the hippie " +
                            "To the hip hip hop and you don't stop " +
                            "The rock it to the bang bang boogie " +
                            "Say up jump the boogie to the rhythm of the boogie, the beat";

        [TestMethod]
        public void should_not_exceed_line_length_limit()
        {
            Assert.IsTrue(
                new MaxInt(
                    map(
                        new Lines(
                            new ParagraphText(
                                  10,
                                  ExampleText
                            )
                        ),
                        text => text.Length
                    )
                ).Value() < 11
            ); 
        }

        [TestMethod]
        public void should_insert_breaks()
        {
            Assert.AreEqual(
                "I said a\n hip hop \nthe \nhippie \nthe \nhippie\nTo the\n hip hip\n" +
                " hop and\n you \ndon't\n stop\nThe rock\n it to\n the bang\n bang \n" +
                "boogie\nSay up\n jump \nthe \nboogie \nto the \nrhythm \nof the \n" +
                "boogie, \nthe beat\n",
                new ParagraphText(
                    10,
                    ExampleText
                ).String()
            );
        }
    }
}
