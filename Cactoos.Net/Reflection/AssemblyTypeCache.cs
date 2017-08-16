using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Cactoos.Scalar;

namespace Cactoos.Reflection
{
    /// <summary>
    /// Allows to cache types of assembly.
    /// </summary>
    public class AssemblyTypeCache : IScalar<IReadOnlyDictionary<string, Type>>
    {
        private IScalar<Assembly> _assembly;

        /// <summary>
        /// Initializes a new instance of <see cref="AssemblyTypeCache"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public AssemblyTypeCache(IScalar<Assembly> assembly)
        {
            _assembly = assembly;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="AssemblyTypeCache"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public AssemblyTypeCache(Assembly assembly) : this(new ValueScalar<Assembly>(assembly))
        {

        }

        /// <summary>
        /// Gets the dictionary.
        /// </summary>
        /// <returns>New dictionary instance.</returns>
        public IReadOnlyDictionary<string, Type> Value()
        {
            return new UsefulTypes(_assembly)
                .ToDictionary(type => type.FullName, type => type);
        }
    }
}
