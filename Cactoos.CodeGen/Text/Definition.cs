using Cactoos;
using System.Collections.Generic;
using System.Text;

namespace CodeGen.Text
{
    public struct Definition : IText
    {
        private IText _definitionType;
        private IText _accessModifier;
        private IText _name;
        private IText _beforeBody;
        private IText _isStatic;

        private IEnumerable<string> _attributes;
        private IEnumerable<string> _body;

        public Definition(
            IEnumerable<string> attributes, 
            string definitionType, 
            IText accessModifier, 
            IText isStatic, 
            IText name, 
            string beforeBody, 
            IEnumerable<string> body)
            : this(attributes, new Cactoos.Text.Text(definitionType), accessModifier, isStatic, name, new Cactoos.Text.Text(beforeBody), body)
        {

        }

        public Definition(
            IEnumerable<string> attributes, 
            IText definitionType, 
            IText accessModifier, 
            IText isStatic, 
            IText name,
            IText beforeBody, 
            IEnumerable<string> body)
        {
            _attributes = attributes;
            _definitionType = definitionType;
            _accessModifier = accessModifier;
            _isStatic = isStatic;
            _name = name;
            _body = body;
            _beforeBody = beforeBody;
        }

        public string String()
        {
            StringBuilder build = new StringBuilder();
            foreach (var item in _attributes)
            {
                build.Append('[')
                     .Append(item)
                     .Append(']')
                     .Append('\n');
            }
            build.Append(_accessModifier.String())
                 .Append(' ')
                 .Append(_isStatic.String())
                 .Append(' ')
                 .Append(_definitionType.String())
                 .Append(' ')
                 .Append(_name.String())
                 .Append(' ')
                 .Append(_beforeBody.String())
                 .AppendLine()
                 .Append('{')
                 .AppendLine();
            foreach (var item in new WithTabs(_body))
            {
                build.AppendLine(item);
            }
            build.Append('}');
            return build.ToString();
        }
    }
}
