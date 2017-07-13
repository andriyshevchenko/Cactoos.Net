using System.IO;

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
