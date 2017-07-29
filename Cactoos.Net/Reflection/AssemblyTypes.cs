using Cactoos.Scalar;
using System;
using System.Linq;
using System.Reflection;

namespace Cactoos.Reflection
{
    /// <summary>
    /// Gets the types of an <see cref="Assembly"/>.
    /// </summary>
    public struct AssemblyTypes : IScalar<Type[]>
    {
        private IScalar<Assembly> _assembly;

        /// <summary>
        /// Initializes a new instance of <see cref="AssemblyTypes"/>.
        /// </summary>
        /// <param name="assembly">The assembly</param>
        public AssemblyTypes(IScalar<Assembly> assembly)
        {
            _assembly = assembly;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="AssemblyTypes"/>.
        /// </summary>
        /// <param name="assembly">The assembly</param>
        public AssemblyTypes(Assembly assembly) : this(new ValueScalar<Assembly>(assembly))
        {

        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>New array of <see cref="Type"/>.</returns>
        public Type[] Value()
        {
            Assembly assembly = _assembly.Value();
            return assembly.DefinedTypes
                    .Cast<Type>()
                    .Concat(assembly.ExportedTypes)
                    .Distinct()
                    .ToArray();
        }
    }
}
