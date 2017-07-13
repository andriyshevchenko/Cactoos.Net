using System;

namespace Cactoos
{
    public interface IAttempt
    {
        bool HasErrors();
        Exception[] Errors();
    }
}
