using Cactoos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static System.Collections.Generic.Create;

namespace Cactoos.Reflection
{
    /// <summary>
    /// Allows to merge different <see cref="AssemblyTypeCache"/> into one dictionary.
    /// </summary>
    public class MergedTypeCache : IScalar<IReadOnlyDictionary<string, Type>>
    {
        private IScalar<IReadOnlyDictionary<string, Type>>[] _items;

        /// <summary>
        /// Initializes a new instance of <see cref="MergedTypeCache"/>.
        /// </summary>
        /// <param name="items">The assemblies.</param>
        public MergedTypeCache(params IScalar<Assembly>[] items)
           : this(array(items, item => new AssemblyTypeCache(item)))
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="MergedTypeCache"/>.
        /// </summary>
        /// <param name="items">The assemblies.</param>
        public MergedTypeCache(params Assembly[] items)
            : this(array(items, item => new AssemblyTypeCache(item)))
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="MergedTypeCache"/>.
        /// </summary>
        /// <param name="items"><see cref="AssemblyTypeCache"/> or any classes which implement underlying interface.</param>
        public MergedTypeCache(params IScalar<IReadOnlyDictionary<string, Type>>[] items)
        {
            _items = items;
        }

        /// <summary>
        /// Gets the dictionary.
        /// </summary>
        /// <returns>New dictionary instance.</returns>
        public IReadOnlyDictionary<string, Type> Value()
        {
            var result = _items[0].Value().AsEnumerable();
            for (int i = 1; i < _items.Length; i++)
            {
                result = result.Concat(_items[i].Value());
            }
            return dictionary(result);
        }
    }
}
