using System;
using System.Threading.Tasks;

namespace Cactoos
{
    /// <summary>
    /// Defines a strongly typed enumerator, which enumerates the sequence asynchronously.
    /// </summary>
    [Obsolete("For internal use")]
    public interface IAsyncEnumerator<T> : IAsyncEnumerator, IDisposable
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        /// <summary>
        /// Returns the current element of the enumeration.
        /// </summary>
        T Current { get; }
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    }

    /// <summary>
    /// Defines an enumerator, which enumerates the sequence asynchronously.
    /// </summary>
    public interface IAsyncEnumerator
    {
        /// <summary>
        /// Advances the enumerator to next element.
        /// </summary>
        /// <returns>A <see cref="Task"/> instance.</returns>
        Task<bool> MoveNextAsync();

        /// <summary>
        /// Returns the current element of the enumeration.
        /// </summary>
        object Current { get; }

        /// <summary>
        /// Resets the enumerator to its initial state.
        /// </summary>
        void Reset();
    }

    /// <summary>
    /// Defines a sequence, which can be enumerated asynchronously.
    /// </summary>
    public interface IAsyncEnumerable 
    {
        /// <summary>
        ///  Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IAsyncEnumerator GetEnumerator();
    }

    /// <summary>
    /// Defines a strongly typed sequence, which can be enumerated asynchronously.
    /// </summary>
    public interface IAsyncEnumerable<T> : IAsyncEnumerable
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        /// <summary>
        ///  Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IAsyncEnumerator<T> GetEnumerator();
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    }
}
