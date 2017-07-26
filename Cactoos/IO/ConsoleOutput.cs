using System;
using System.IO;

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
