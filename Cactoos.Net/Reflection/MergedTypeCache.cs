using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


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
           : this(items.Select(item => new AssemblyTypeCache(item)).ToArray())
        {

        }

        /// <summary>
        /// Initializes a new instance of <see cref="MergedTypeCache"/>.
        /// </summary>
        /// <param name="items">The assemblies.</param>
        public MergedTypeCache(params Assembly[] items)
            : this(items.Select(item => new AssemblyTypeCache(item)).ToArray())
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
            Dictionary<string, Type> ret = new Dictionary<string, Type>(256);
            for (int i = 0; i < _items.Length; i++)
            {
                var m_value = _items[i].Value();
                foreach (var item in m_value)
                {
                    ret[item.Key] = item.Value;
                }
            }
            return ret;
        }
    }
}
