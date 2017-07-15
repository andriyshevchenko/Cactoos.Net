using System.Linq;
using Cactoos.IO;

namespace Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            new Output(
                new StringInput("hello world"),
                new ConsoleOutput()
            ).Count();
            
            new Output(
                new ConsoleInput(),
                new PathOutput("file.txt")
            );
        }
    }
}
