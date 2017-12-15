using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cactoos.Text;



namespace Cactoos.Reflection
{
    /// <summary>
    /// Allows to cache only type names of assembly.
    /// </summary>
    public struct SimpleNameTypeCache : IScalar<IReadOnlyDictionary<string, Type[]>>
    {
        private IScalar<IReadOnlyDictionary<string, Type>> _source;

        /// <summary>
        /// Initializes a new instance of <see cref="SimpleNameTypeCache"/>.
        /// </summary>
        /// <param name="source">Type cache with namespaces.</param>
        public SimpleNameTypeCache(IScalar<IReadOnlyDictionary<string, Type>> source)
        {
            _source = source;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SimpleNameTypeCache"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public SimpleNameTypeCache(IScalar<Assembly> assembly) : this(new AssemblyTypeCache(assembly))
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="SimpleNameTypeCache"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public SimpleNameTypeCache(Assembly assembly) : this(new AssemblyTypeCache(assembly))
        {

        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>New dictionary instance.</returns>
        public IReadOnlyDictionary<string, Type[]> Value()
        {
            var types = _source.Value()
                .Select(item => (new SimpleName(item.Key).Name, item.Value))
                .ToArray();

            var dictionary = new Dictionary<string, Type[]>();

            for (int i = 0; i < types.Length; i++)
            {
                (var key, var value) = types[i];
                if (dictionary.ContainsKey(key))
                {
                    Type[] type = dictionary[key];
                    var newitem = new Type[type.Length + 1];
                    for (int j = 0; j < type.Length; j++)
                    {
                        newitem[j] = type[j];
                    }
                    newitem[type.Length] = value;
                    dictionary[key] = newitem;
                }
                else
                {
                    dictionary[key] = new Type[] { value };
                }
            }
            return dictionary;
        }
    }
}
