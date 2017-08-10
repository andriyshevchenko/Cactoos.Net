using Cactoos;
using System.Collections.Generic;

namespace CodeGen.Text
{
    public struct StructDefinition : IText
    {
        private IText _accessModifier;
        private IText _name;
        private IText _isStatic;
        private IEnumerable<string> _body;
        private IEnumerable<string> _attributes;

        public StructDefinition(
            IText accessModifier, 
            IText isStaticQualifier, 
            string name, 
            IEnumerable<string> body,
            IEnumerable<string> attributes)
            : this(accessModifier, isStaticQualifier, new Cactoos.Text.Text(name), body, attributes)
        {

        }

        public StructDefinition(
            IText accessModifier,
            IText isStaticQualifier, 
            IText name, 
            IEnumerable<string> body,
            IEnumerable<string> attributes)
        {
            _accessModifier = accessModifier;
            _isStatic = isStaticQualifier;
            _name = name;
            _body = body;
            _attributes = attributes;
        }

        public string String()
        {
            return 
                new Definition(
                    _attributes, 
                    "struct", 
                    _accessModifier, 
                    _isStatic, 
                    _name, 
                    string.Empty,
                    _body
                ).String();
        }
    }
}
