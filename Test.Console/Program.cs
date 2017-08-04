using Cactoos.IO;
using Cactoos.Scalar;
using Cactoos.Text;

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
                        new ErrorSafeScalar<int>(
                            () => throw new System.NotImplementedException("hello, this is a test"),
                            () => 0
                        ),
                        scalar => scalar.Value()
                    )
                ),
                new ConsoleOutput()
            );
            System.Console.Read();
        }
    }
}
