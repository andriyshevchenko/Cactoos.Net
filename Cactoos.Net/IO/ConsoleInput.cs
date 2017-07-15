using Cactoos.Scalar;
using System;
using System.IO;

namespace Cactoos.IO
{
    public class ConsoleInput : IInput
    {
        public Stream Stream()
        {
            return Console.OpenStandardInput();
        }
    }
}
