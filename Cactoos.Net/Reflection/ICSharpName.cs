using System;

namespace Cactoos.Text
{
    /// <summary>
    /// Declares a C# struct or class name.
    /// </summary>
    public interface ICSharpName
    {
        /// <summary>
        /// Own name without a namespace.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The namespace.
        /// </summary>
        string Namespace { get; }
    }
}
