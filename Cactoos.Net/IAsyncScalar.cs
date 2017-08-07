using System.Threading.Tasks;

namespace Cactoos
{
    public interface IAsyncScalar<T>
    {
        Task<T> Value();
    }
}
