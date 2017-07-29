namespace Cactoos.Text
{
    /// <summary>
    /// Represents a simple namespace.
    /// </summary>
    public struct SimpleNamespace : ISimpleNamespace
    {
        /// <summary>
        /// Initializes a new instance of <see cref="SimpleNamespace"/>.
        /// </summary>
        /// <param name="name">The <see cref="ICSharpName"/> instance.</param>
        public SimpleNamespace(ICSharpName name) :this(name.Namespace)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="SimpleNamespace"/>.
        /// </summary>
        /// <param name="other">Other instance of <see cref="ISimpleNamespace"/>.</param>
        public SimpleNamespace(ISimpleNamespace other) : this(other.Name)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="SimpleNamespace"/>.
        /// </summary>
        /// <param name="name">The value.</param>
        public SimpleNamespace(string name)
        {
            Name = name;
        }

        /// <summary>
        /// The name.
        /// </summary>
        public string Name { get; }
    }
}
