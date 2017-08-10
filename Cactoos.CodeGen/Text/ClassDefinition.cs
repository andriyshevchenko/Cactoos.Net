using Cactoos;
using System.Collections.Generic;
using System.Text;

using static System.Collections.Generic.Create;

namespace CodeGen.Text
{
    public struct ClassDefinition : IText
    {
        private IText _accessModifier;
        private IText _name;
        private IText _isStatic;
        private IEnumerable<string> _body;
        private IEnumerable<string> _attributes;
        private IEnumerable<string> _baseTypes;

        public ClassDefinition(
            IText accessModifier,
            IText isStaticQualifier, 
            string name,
            IEnumerable<string> attributes,
            IEnumerable<string> body,
            IEnumerable<string> baseTypes)
            : this(accessModifier, isStaticQualifier, new Cactoos.Text.Text(name), attributes, body, baseTypes)
        {

        }

        public ClassDefinition(
            IText accessModifier,
            IText isStaticQualifier, 
            IText name,
            IEnumerable<string> attributes,
            IEnumerable<string> body,
            IEnumerable<string> baseTypes)
        {
            _accessModifier = accessModifier;
            _isStatic = isStaticQualifier;
            _name = name;
            _body = body;
            _baseTypes = baseTypes;
            _attributes = attributes;
        }

        public string String()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(':');
            var baseTypes = array(_baseTypes);
            int last = baseTypes.Length - 1;
            for (int i = 0; i < last; i++)
            {
                builder.Append(' ');
                builder.Append(baseTypes[i]);
                builder.Append(',');
            }
            builder.Append(' ');
            builder.Append(baseTypes[last]);

            return
                new Definition(
                    _attributes,
                    "class",
                    _accessModifier, 
                    _isStatic, 
                    _name, 
                    builder.ToString(),
                    _body
                ).String();
        }
    }
}
