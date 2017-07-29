using Cactoos.Reflection;
using Cactoos.Scalar;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cactoos.Text
{
    /// <summary>
    /// Allows to infer the namespace of a type from given assemblies.
    /// </summary>
    public struct InferredName : IScalar<string>
    {
        private string _source;
        private IScalar<IReadOnlyDictionary<string, Type>> _typeCacheWithoutNamespace;

        /// <summary>
        /// Initializes a new instance of <see cref="InferredName"/>.
        /// </summary>
        /// <param name="typeCache">Type cache without namespaces.</param>
        /// <param name="source">The name to infer.</param>
        public InferredName(IScalar<IReadOnlyDictionary<string, Type>> typeCache, string source)
        {
            _typeCacheWithoutNamespace = new CachedScalar<IReadOnlyDictionary<string, Type>>(typeCache);
            _source = source;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="InferredName"/>.
        /// </summary>
        /// <param name="assembly">The assembly to get types from.</param>
        /// <param name="source">The name to infer.</param>
        public InferredName(Assembly assembly, string source)
          : this(
                new TypeCacheWithoutNamespace(
                    new AssemblyTypeCache(assembly)
                ),
                source
            )
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="InferredName"/>.
        /// </summary>
        /// <param name="assembly">The assembly to get types from.</param>
        /// <param name="source">The name to infer.</param>
        public InferredName(IScalar<Assembly> assembly, string source) 
            : this(
                  new TypeCacheWithoutNamespace(
                      new AssemblyTypeCache(assembly)
                  ),
                  source
              )
        {

        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>New name, with inferred namespace.</returns>
        public string Value()
        {
            string result = _source;
            string targetNamespace = null;
            if (!new IsNamespaced(result).Value())
            {
                IReadOnlyDictionary<string, Type> value = _typeCacheWithoutNamespace.Value();
                if (value.ContainsKey(result))
                {
                    return value[result].FullName;
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
