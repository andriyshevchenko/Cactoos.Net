using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
