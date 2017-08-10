using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cactoos.CodeGen.Text
{
    public struct NamespaceDefinition : IText
    {
        private IText _name;
        private IEnumerable<string> _body;

        public NamespaceDefinition(IText name, IEnumerable<string> body)
        {
            _name = name;
            _body = body;
        }

        public NamespaceDefinition(string name, IEnumerable<string> body)
            : this (new Cactoos.Text.Text(name), body)
        {

        }

        public string String()
        {
            var builder = new StringBuilder();
            builder.Append(_name.String())
                   .Append('{')
                   .AppendLine();

            foreach (var item in new WithTabs(_body))
            {
                builder.AppendLine(item);
            }
            builder.Append('}');
            return builder.ToString();
        }
    }
}
