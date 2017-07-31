using System.Linq;
using Cactoos.IO;
using Cactoos.Scalar;
using Cactoos.Text;
using System.Text;

namespace Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            new Output(
               new DoubleText(
                   new DoubleSum(
                       new ParsedDoubles(
                           new Lines(
                               new InputText(
                                   new PathInput(@"C:\Users\user\Desktop\apteka.txt"),
                                   Encoding.Default
                               )
                           )
                       )
                   )
               ),
               new ConsoleOutput()
           ).Count();
        }
    }
}
