using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cactoos.IO
{
    public class FakeInput : IInput
    {
        public Stream Stream()
        {
            return new ByteInput(new EmptyBytes()).Stream();
        }
    }
}
