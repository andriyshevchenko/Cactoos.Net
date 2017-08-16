using System.Threading.Tasks;

namespace Cactoos
{
    /// <summary>
    /// A scalar which value can be retrieved asynchronously.
    /// </summary>
    /// <typeparam name="T">The of the item.</typeparam>
    public interface IAsyncScalar<T>
    {
        /// <summary>
        /// Gets the task.
        /// </summary>
        /// <returns>The task instance.</returns>
        Task<T> Value();
    }
}
