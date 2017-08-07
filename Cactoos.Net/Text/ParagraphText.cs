//using Cactoos.List;
//using InputValidation;
//using System.Text;

//using static System.Collections.Generic.Create;

//namespace Cactoos.Text
//{
//    /// <summary>
//    /// A text with custom line width.
//    /// </summary>
//    public class ParagraphText : IText
//    {
//        private int _lineWidth;
//        private IText _source;

//        public ParagraphText(int lineWidth, IText source)
//        {
//            _lineWidth = lineWidth.CheckIfNatural("line width");
//            _source = source;
//        }

//        public ParagraphText(int lineWidth, string source) : this(lineWidth, new Text(source))
//        {

//        }

//        private static char[] _breaks = array(',', '-', '!', '?', ' ');

//        public string String()
//        {
//            var lines = 
//                new Indexed<string>(
//                    new CharSplitText(_source, _breaks)
//                );
//            var result = new StringBuilder();
//            int count = 0;
//            foreach (var pair in lines)
//            {
//                count += pair.Item.Length;

//            }
//            throw new System.Exception();
//        }
//    }
//}
