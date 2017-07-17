using System;
using System.IO;

namespace Cactoos.Net.IO
{
    public class StdErrOutput : IOutput
    {
        public Stream Stream()
        {
            return Console.OpenStandardError();
        }
    }
}
