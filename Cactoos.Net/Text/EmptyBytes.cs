using Cactoos;

public class EmptyBytes : IBytes
{
    public byte[] Bytes()
    {
        return new byte[0];
    }
}