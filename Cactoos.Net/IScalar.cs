namespace Cactoos
{
    /// <summary>
    /// Represents a scalar value
    /// </summary>
    public interface IScalar<T>
    {
        /// <summary>
        /// Converts it to the value.
        /// </summary>
        /// <returns>Typed value of a scalar</returns>
        T Value();
    }
}
