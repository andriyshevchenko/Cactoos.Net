using System.Text;

namespace Cactoos.Text
{
    /// <summary>
    /// Creates a new C# name with a namespace, if target name doesn't have it.
    /// </summary>
    internal struct NamespacedName : IText
    {
        private string _source;
        private string _namespace;

        /// <summary>
        /// Initializes a new instance of <see cref="NamespacedName"/>.
        /// </summary>
        /// <param name="source">The name.</param>
        /// <param name="namespace">The namespace.</param>
        public NamespacedName(string source, ISimpleNamespace @namespace) 
            : this(source, @namespace.Name)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="NamespacedName"/>.
        /// </summary>
        /// <param name="source">The name.</param>
        /// <param name="namespace">The namespace.</param>
        public NamespacedName(string source, string @namespace)
        {
            _source = source;
            _namespace = @namespace;
        }

        /// <summary>
        /// Gets the string value.
        /// </summary>
        /// <returns>New name with namespace.</returns>
        public string String()
        {
            string @namespace = new SimpleName(_source).Namespace;
            string result = _source;
            if (new IsBlank(@namespace).Value())
            {
                result = new StringBuilder()
                       .Append(_namespace)
                       .Append('.')
                       .Append(_source)
                       .ToString();
            }
            return result;
        }
    }
}
