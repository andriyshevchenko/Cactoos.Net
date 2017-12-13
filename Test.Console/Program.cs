using Cactoos.IO;
using Cactoos.Scalar;
using Cactoos.Text;
using System.Linq;
using static System.Functional.Func;

namespace Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            new Output(
                new AttemptAsText(
                    monad(
                        new NoThrow<int>(
                            () => throw new System.NotImplementedException("hello, this is a test"),
                            () => 0
                        ),
                        scalar => scalar.Value()
                    )
                ),
                new ConsoleOutput()
            ).Count();
            System.Console.Read();
        }
    }
}
