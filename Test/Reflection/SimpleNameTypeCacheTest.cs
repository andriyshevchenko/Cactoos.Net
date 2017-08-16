using Cactoos.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Reflection
{
    [TestClass]
    public class SimpleNameTypeCacheTest
    {
        [TestMethod]
        public void should_create_simple_name_type_cache_from_mscorlib()
        {
            new SimpleNameTypeCache(
                new AssemblyOfType<string>()
            ).Value();
        }
    }
}
