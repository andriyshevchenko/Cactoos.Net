using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cactoos.IO;
using System.IO;

using static System.Functional.FlowControl;
using static System.Functional.Func;
using static System.Functional.Action;
using static System.IO.Path;

namespace Test.IO
{
    [TestClass]
    public class PathOutputTest
    {
        [TestMethod]
        public void should_write()
        {
            var output =
                monad(
                    new PathOutput(GetTempFileName()),
                    @out =>
                        use(
                            @out.Stream(),
                            fun(act((Stream stream) => stream.WriteByte(1)))
                        )
                );
            Assert.AreEqual(use(output.Stream(), stream => stream.ReadByte()), 1);
        }
    }
}
