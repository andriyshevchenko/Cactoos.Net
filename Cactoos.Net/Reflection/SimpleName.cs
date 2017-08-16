using Cactoos.Scalar;

namespace Cactoos.Text
{
    /// <summary>
    /// Allows to extract namespace and own name from a full name.
    /// </summary>
    public struct SimpleName : ICSharpName
    {
        private string source;
        private IScalar<int> _lastOccurence;

        /// <summary>
        /// Initializes a new instance of <see cref="SimpleName"/>.
        /// </summary>
        /// <param name="nameWithNamespace">C# name with namespace.</param>
        public SimpleName(string nameWithNamespace)
        {
            source = nameWithNamespace;
            _lastOccurence = new LazyScalar<int>(() =>
            {
                int lastOccurence = 0;
                for (int i = 0; i < nameWithNamespace.Length; i++)
                {
                    if (nameWithNamespace[i] == '.')
                    {
                        lastOccurence = i;
                    }
                }
                return lastOccurence;
            });
        }

        /// <summary>
        /// Gets the own name, without namespace.
        /// </summary>
        public string Name
        {
            get
            {
                int value = _lastOccurence.Value();
                string result = source;
                if (value != 0)
                {
                    result = source.Substring(value + 1, source.Length - value - 1);
                }
                return result;
            }
        }

        /// <summary>
        /// Gets the namespace.
        /// </summary>
        public string Namespace
        {
            get
            {
                int value = _lastOccurence.Value();
                string result = string.Empty;
                if (value != 0)
                {
                    result = source.Substring(0, value);
                }
                return result;
            }
        }
    }
}
