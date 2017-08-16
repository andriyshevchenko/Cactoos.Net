using Cactoos.Reflection;
using Cactoos.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using static System.Collections.Generic.Create;

namespace Test.Reflection
{
    [TestClass]
    public class NotGeneratedTypesTest
    {
        [TestMethod]
        public void should_not_contain_generated_types_in_mscorlib()
        {
            var types =
                array<Type>(
                    new UsefulTypes(
                        new AssemblyTypes(
                            new AssemblyOfType<string>()
                        )
                    )
                 );
            var dictionary = dictionary<string, Type>();
            var duplicates = set<string>();
            foreach (var item in types)
            {
                string name = new SimpleName(item.FullName).Name;
                if (dictionary.ContainsKey(name))
                {
                    duplicates.Add(name);
                }
                else
                { 
                    dictionary.Add(name, item);
                }
            }
            ;
        }
    }
}
