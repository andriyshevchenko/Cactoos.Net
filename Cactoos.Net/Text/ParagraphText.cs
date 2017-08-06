using InputValidation;
using System;
using System.Text;

using static System.Collections.Generic.Create;

namespace Cactoos.Text
{
    /// <summary>
    /// A text with custom line width.
    /// </summary>
    public class ParagraphText : IText
    {
        private int _lineWidth;
        private IText _source;

        public ParagraphText(int lineWidth, IText source)
        {
            _lineWidth = lineWidth.CheckIfNatural("line width");
            _source = source;
        }

        public ParagraphText(int lineWidth, string source) : this(lineWidth, new Text(source))
        {

        }

        public string String()
        {
            var source = _source.String();
            int wordStart = 0;
            int wordStartBefore = 0;
            int wordIdx = 0;
            char[] word = new char[source.Length];
            var newString = new StringBuilder();
            for (int i = 0; i < source.Length; i++)
            {
                char @char = source[i];
                word[wordIdx++] = @char;

                if (@char == ' ')
                {
                    wordStart = i + 1;
                    for (int j = 0; j < wordIdx; j++)
                    {
                        newString.Append(word[j]);
                    }
                    if (wordStartBefore + wordIdx + 1 >= _lineWidth)
                    {
                        newString.Append('\n');
                    }
                    wordIdx = 0;
                    wordStartBefore = wordStart; 
                }
            }

            return newString.ToString();
        }
    }
}
