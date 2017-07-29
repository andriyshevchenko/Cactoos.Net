namespace Cactoos.Reflection
{
    /// <summary>
    /// Declares a C# struct or class name.
    /// </summary>
    public interface ICSharpName
    {
        /// <summary>
        /// Own name without a namespace.
        /// </summary>
        string OwnName { get; }

        /// <summary>
        /// The namespace.
        /// </summary>
        string Namespace { get; }
    }
}
