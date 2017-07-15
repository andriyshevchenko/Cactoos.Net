using System;
using System.IO;
using System.Text;

namespace Cactoos.IO
{
    public class ConsoleOutput : IOutput
    {
        public ConsoleOutput()
        {
        }

        public Stream Stream()
        {
            return Console.OpenStandardOutput();
        }
    }
}
