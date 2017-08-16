using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cactoos.Reflection
{
    public struct PublicCtors : IEnumerable<ConstructorInfo>
    {
        private Type _type;

        public PublicCtors(Type source)
        {
            _type = source;
        }

        public IEnumerator<ConstructorInfo> GetEnumerator()
        {
            return _type.GetConstructors().Where(ctor => ctor.IsPublic).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
