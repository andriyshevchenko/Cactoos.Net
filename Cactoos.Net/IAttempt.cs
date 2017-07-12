using System;
using System.Collections.Generic;
using System.Text;

namespace Cactoos.Net
{
    public interface IAttempt
    {
        bool HasErrors();
        Exception[] Errors();
    }
}
