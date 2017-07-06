using Cactoos;
using static System.Collections.Generic.Create;

public class EmptyBytes : IBytes
{
    public byte[] Bytes()
    {
        return array<byte>(0);
    }
}