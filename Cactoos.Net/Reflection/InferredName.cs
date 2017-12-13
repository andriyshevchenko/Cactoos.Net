using Cactoos.Reflection;
using Cactoos.Scalar;
using InputValidation;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cactoos.Text
{
    /// <summary>
    /// Allows to infer the namespace of a type from given assemblies.
    /// </summary>
    public struct InferredName : IText
    {
        private int _handleDuplicatesIndex;
        private IText _source;
        private IScalar<IReadOnlyDictionary<string, Type[]>> _typeCacheWithoutNamespace;

        /// <summary>
        /// Initializes a new instance of <see cref="InferredName"/>.
        /// </summary>
        /// <param name="typeCache">Type cache without namespaces.</param>
        /// <param name="source">The name to infer.</param>
        /// <param name="handleDuplicatesIndex">If there are duplicate type names in an assembly, this index used to access a particular item from an array.</param>
        public InferredName(IScalar<IReadOnlyDictionary<string, Type[]>> typeCache, IText source, int handleDuplicatesIndex = 0)
        {
            _handleDuplicatesIndex = handleDuplicatesIndex.CheckIfNonNegative(nameof(handleDuplicatesIndex));
            _typeCacheWithoutNamespace = new Cached<IReadOnlyDictionary<string, Type[]>>(typeCache);
            _source = source;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="InferredName"/>.
        /// </summary>
        /// <param name="typeCache">Type cache without namespaces.</param>
        /// <param name="source">The name to infer.</param>
          /// <param name="handleDuplicatesIndex">If there are duplicate type names in an assembly, this index used to access a particular item from an array.</param>
        public InferredName(IScalar<IReadOnlyDictionary<string, Type[]>> typeCache, string source, int handleDuplicatesIndex = 0)
            : this(typeCache, new Text(source), handleDuplicatesIndex)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="InferredName"/>.
        /// </summary>
        /// <param name="assembly">The assembly to get types from.</param>
        /// <param name="source">The name to infer.</param>
          /// <param name="handleDuplicatesIndex">If there are duplicate type names in an assembly, this index used to access a particular item from an array.</param>
        public InferredName(Assembly assembly, string source, int handleDuplicatesIndex = 0)
          : this(
                new SimpleNameTypeCache(
                    new AssemblyTypeCache(assembly)
                ),
                source,
                handleDuplicatesIndex
            )
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="InferredName"/>.
        /// </summary>
        /// <param name="source">The name to infer.</param>
          /// <param name="handleDuplicatesIndex">If there are duplicate type names in an assembly, this index used to access a particular item from an array.</param>
        /// <param name="type">Target type.</param>
        public InferredName(Type type, string source, int handleDuplicatesIndex = 0) 
            : this(new AssemblyOfType(type), source, handleDuplicatesIndex)
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="InferredName"/>.
        /// </summary>
        /// <param name="assembly">The assembly to get types from.</param>
        /// <param name="source">The name to infer.</param>
          /// <param name="handleDuplicatesIndex">If there are duplicate type names in an assembly, this index used to access a particular item from an array.</param>
        public InferredName(IScalar<Assembly> assembly, string source, int handleDuplicatesIndex = 0)
            : this(
                  new SimpleNameTypeCache(
                      new AssemblyTypeCache(assembly)
                  ),
                  source,
                  handleDuplicatesIndex
              )
        {

        }

        /// <summary>
        /// Gets the string value.
        /// </summary>
        /// <returns>New name, with inferred namespace.</returns>
        public string String()
        {
            string result = _source.String();
            string targetNamespace = null;
            if (!new IsNamespaced(result).Value())
            {
                IReadOnlyDictionary<string, Type[]> value = _typeCacheWithoutNamespace.Value();
                if (value.ContainsKey(result))
                {
                    return value[result][_handleDuplicatesIndex].FullName;
                }

                if (new IsBlank(targetNamespace).Value())
                {
                    throw new InvalidOperationException($"Unable to infer the namespace for {result}");
                }
            }
            return result;
        }
    }
}
