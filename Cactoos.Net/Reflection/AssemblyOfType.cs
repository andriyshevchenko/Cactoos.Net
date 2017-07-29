using Cactoos;
using System.Reflection;
using System;

namespace Cactoos.Reflection
{
    /// <summary>
    /// Gets the assembly of required type.
    /// </summary>
    /// <typeparam name="T">Target type.</typeparam>
    public struct AssemblyOfType<T> : IScalar<Assembly>
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>Assembly of T.</returns>
        public Assembly Value()
        {
            return new TypeOf<T>().Value().GetTypeInfo().Assembly;
        }
    }

    /// <summary>
    /// Gets the assembly of required type.
    /// </summary>
    public struct AssemblyOfType : IScalar<Assembly>
    {
        private Type _type;

        /// <summary>
        /// Initializes a new instance of <see cref="AssemblyOfType"/>.
        /// </summary>
        /// <param name="type">Target System.<see cref="Type"/></param>
        public AssemblyOfType(Type type)
        {
            _type = type;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>Assembly of Type.</returns>
        public Assembly Value()
        {
            return _type.GetTypeInfo().Assembly;
        }
    }
}
