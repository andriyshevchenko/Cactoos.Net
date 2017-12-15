//using Cactoos.List;
//
//using System.Text;

//

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

//        private static char[] _breaks = System.Linq.Enumerable.ToArray(',', '-', '!', '?', ' ');

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
