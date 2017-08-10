using Cactoos;

namespace CodeGen.Text
{
    public struct Public : IText
    {
        public string String() => "public";
    }

    public struct Private : IText
    {
        public string String() => "private";
    }

    public struct Internal : IText
    {
        public string String() => "internal";
    }

    public struct Protected : IText
    {
        public string String() => "public";
    }

    public struct None : IText
    {
        public string String() => string.Empty;
    }

    public struct Static : IText
    {
        public string String() => "static";
    }
}
