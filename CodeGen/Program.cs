namespace CodeGen
{
    using Cactoos;
    using Cactoos.Reflection;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Will generate a code to be able to create any Cactoos object with a static method 
    /// (using static import required).
    /// </summary>
    class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            var types =
                new NotGeneratedTypes(
                    new AssemblyTypes(
                        new AssemblyOfType<IText>(),
                        true
                    )
                ).ToArray();

            StringBuilder code = new StringBuilder();
            code.AppendLine("public static class Create");
            code.AppendLine("{");

            foreach (var type in types)
            {
                var constructors = type
                    .GetConstructors()
                    .Where(ctor => ctor.IsPublic)
                    .ToArray();
                for (int i = 0; i < constructors.Length; i++)
                {
                    var ctor = constructors[i];
                    code.Append("    public static ");
                    string name = type.Name;
                    //the method definition

                    if (type.IsGenericType)
                    {
                        code.Append(new GenericName(type).String());
                    }
                    else
                    {
                        code.Append(name);
                    }
                    code.Append(" ");

                    //the method name
                    IText method;
                    if (type.IsGenericType)
                    {
                        method = new LowerCaseName(new GenericName(type));
                    }
                    else
                    {
                        method = new LowerCaseName(name);
                    }

                    code.Append(method.String());
                    code.Append("(");
                    //the method parameters

                    code.Append(")");

                    code.AppendLine();
                    code.AppendLine("    {");
                    //the method body

                    code.Append("        return new ");

                    if (type.IsGenericType)
                    {
                        code.Append(new GenericName(type).String());
                    }
                    else
                    {
                        code.Append(name);
                    }
                    code.Append("(");
                    //the constructor params
                    code.AppendLine(");");

                    code.AppendLine("    }");
                    code.AppendLine(" ");
                }
            }

            code.Append("}");
            File.WriteAllText(@"C:\projects\Cactoos.Net\Cactoos.Net\Create.cs", code.ToString());
        }
    }
}
