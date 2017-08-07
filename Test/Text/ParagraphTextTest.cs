//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Cactoos.Text;

//using static System.Collections.Generic.Create;
//using Cactoos.Scalar;

//namespace Test.Text
//{
//    [TestClass]
//    public class ParagraphTextTest
//    {
//        private const string ExampleText = "I said a hip hop the hippie the hippie " +
//                            "To the hip hip hop and you don't stop " +
//                            "The rock it to the bang bang boogie " +
//                            "Say up jump the boogie to the rhythm of the boogie, the beat";

//        [TestMethod]
//        public void should_not_exceed_line_length_limit()
//        {
//            Assert.IsTrue(
//                new MaxInt(
//                    map(
//                        new Lines(
//                            new ParagraphText(
//                                  10,
//                                  ExampleText
//                            )
//                        ),
//                        text => text.Length
//                    )
//                ).Value() < 11
//            ); 
//        }

//        [TestMethod]
//        public void should_insert_breaks()
//        {
//            Assert.AreEqual(    
//                "I said a\n hip hop \nthe \nhippie \nthe hippie\nTo the\n hip hip\n" +
//                " hop and\n you \ndon't\n stop\nThe rock\n it to\n the bang\n bang \n" +
//                "boogie\nSay up\n jump \nthe \nboogie \nto the \nrhythm \nof the \n" +
//                "boogie, \nthe beat\n",
//                new ParagraphText(
//                    10,
//                    ExampleText
//                ).String()
//            );
//        }

//        [TestMethod]
//        public void should_insert_breaks_inside_a_two_line_text()
//        {
//            Assert.AreEqual(
//               "Добре \nвідомо",
//               new ParagraphText(
//                   10,
//                   "Добре відомо"
//               ).String()
//           );
//        }

//        [TestMethod]
//        public void should_insert_breaks_inside_a_simple_text()
//        {
//            Assert.AreEqual(
//               "Добре \nвідомо, що \nбудь який \nрозв’язок \nкрайової \nзадачі",
//               new ParagraphText(
//                   10,
//                   "Добре відомо, що будь який розв’язок крайової задачі"
//               ).String()
//           );
//        }

//        [TestMethod]
//        public void should_break_a_phraze()
//        {
//            Assert.AreEqual("Hello ggwp\n!", new ParagraphText(10, "Hello ggwp!").String());
//        }
//    }
//}
