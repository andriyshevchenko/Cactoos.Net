using Cactoos.Scalar;
using Cactoos.Text;
using System.Linq;
using System.Reflection;

namespace Cactoos.Reflection
{
    /// <summary>
    /// Returns the root namespace of an <see cref="Assembly"/>.
    /// </summary>
    public struct AssemblyRootNamespace : IScalar<string>
    {   
        private IScalar<Assembly> _source;

        /// <summary>
        /// Initializes a new instance <see cref="AssemblyRootNamespace"/>.
        /// </summary>
        /// <param name="source">The assembly.</param>
        public AssemblyRootNamespace(Assembly source): this(new ValueScalar<Assembly>(source))
        {

        }

        /// <summary>
        /// Initializes a new instance <see cref="AssemblyRootNamespace"/>.
        /// </summary>
        /// <param name="source">The assembly.</param>
        public AssemblyRootNamespace(IScalar<Assembly> source)
        {
            _source = source;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>The root namespace.</returns>
        public string Value()
        {
            return new SimpleName(_source.Value().ExportedTypes.First().FullName).Namespace;
        }
    }
}
