using Cactoos.Scalar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cactoos.Reflection
{
    /// <summary>
    /// Gets the types of an <see cref="Assembly"/>.
    /// </summary>
    public struct AssemblyTypes : IEnumerable<Type>
    {
        private bool _omitAbstract;
        private IScalar<Assembly> _assembly;

        /// <summary>
        /// Initializes a new instance of <see cref="AssemblyTypes"/>.
        /// </summary>
        /// <param name="assembly">The assembly</param>
        /// <param name="omitAbstractTypes">Ignore interfaces and abstract classes.</param>
        public AssemblyTypes(IScalar<Assembly> assembly, bool omitAbstractTypes = false)
        {
            _omitAbstract = omitAbstractTypes;
            _assembly = assembly;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="AssemblyTypes"/>.
        /// </summary>
        /// <param name="assembly">The assembly</param>
        /// <param name="omitAbstractTypes">Ignore interfaces and abstract classes.</param>
        public AssemblyTypes(Assembly assembly, bool omitAbstractTypes = false) : this(new ValueScalar<Assembly>(assembly), omitAbstractTypes)
        {

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<Type> GetEnumerator()
        {
            Assembly assembly = _assembly.Value();
            var types = assembly.DefinedTypes
                    .Cast<Type>()
                    .Concat(assembly.ExportedTypes);
            if (_omitAbstract)
            {
                types = types.Where(type => !type.Name.StartsWith("I"));
            }
            return types.GetEnumerator();
        }
    }
}
