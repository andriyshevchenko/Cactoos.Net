using Cactoos.IO;
using Cactoos.Scalar;
using Cactoos.Text;

namespace Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            new Output(
                new AttemptAsText(
                    new ErrorSafeScalar<int>(
                        () => throw new System.NotImplementedException("hello"),
                        () => 0
                    )
                ),
                new ConsoleOutput()
            );
            System.Console.Read();
        }
    }
}
