using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cactoos.IO;
using Cactoos.Text;

namespace Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            new Output(
                new StringInput("hello world"),
                new ConsoleOutput(Encoding.UTF8)
            ).Count();
            
            var str = new InputText(new ConsoleInput(), Encoding.Default).String();
        }
    }
}
