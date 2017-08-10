using Cactoos.Text;
using System;
using System.Collections.Generic;
using System.Reflection;

using static System.Collections.Generic.Create;

namespace Cactoos.Reflection
{
    /// <summary>
    /// Gets all namespaces of an <see cref="Assembly"/>.
    /// </summary>
    public struct NamespacesOfAssembly : IScalar<IEnumerable<SimpleNamespace>>
    {
        private IEnumerable<Type> _types;

        /// <summary>
        /// Initializes a new instance of <see cref="NamespacedName"/>.
        /// </summary>
        /// <param name="types">The types of an assembly.</param>
        public NamespacesOfAssembly(IEnumerable<Type> types)
        {
            _types = types;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="NamespacedName"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public NamespacesOfAssembly(IScalar<Assembly> assembly)
            : this(new AssemblyTypes(assembly))
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="NamespacedName"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public NamespacesOfAssembly(Assembly assembly)
          : this(new AssemblyTypes(assembly))
        {

        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>All the namespaces inside of <see cref="Assembly"/>.</returns>
        public IEnumerable<SimpleNamespace> Value()
        {
            return
                set(
                    map(
                        _types,
                        type =>
                            new SimpleNamespace(
                                new SimpleName(type.FullName)
                            )
                    )
                );
        }
    }
}
