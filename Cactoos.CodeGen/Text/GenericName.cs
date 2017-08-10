namespace CodeGen
{
    using Cactoos;
    using System;
    using System.Text;

    public struct GenericName : IText
    {
        private Type _source;

        public GenericName(Type source)
        {
            _source = source;
        }

        public string String()
        {
            StringBuilder build = new StringBuilder();
            build.Append(new CutGenericName(_source.Name).String());
            build.Append("<");

            var parameters = _source.GetGenericArguments();
            for (int j = 0; j < parameters.Length; j++)
            {
                var parameter = parameters[j];
                build.Append(parameter.Name);
                if (j != parameters.Length - 1)
                {
                    build.Append(", ");
                }
            }
            build.Append(">");
            return build.ToString();
        }
    }
}
