using System;
using System.IO;

namespace Cactoos.IO
{
    public class StdErrOutput : IOutput
    {
        public Stream Stream()
        {
            return Console.OpenStandardError();
        }
    }
}
