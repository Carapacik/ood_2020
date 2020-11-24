using System;
using System.IO;

namespace Adapter.ModernGraphicsLib
{
    public class ModernGraphicsRenderer
    {
        private readonly TextWriter _textWriter;
        private bool _drawing;

        public ModernGraphicsRenderer(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public void BeginDraw()
        {
            if (_drawing)
                throw new Exception("Drawing has already begun");

            _textWriter.WriteLine("<draw>");
            _drawing = true;
        }

        public void DrawLine(Point start, Point end, RgbaColor color)
        {
            if (!_drawing)
                throw new Exception("DrawLine is allowed between BeginDraw()/EndDraw() only");

            _textWriter.WriteLine($"  <line fromX={start.X} fromY={start.Y} toX={end.X} toY={end.Y}>{color}  </line>");
        }

        public void EndDraw()
        {
            if (!_drawing)
                throw new Exception("Drawing has not been started");

            _textWriter.WriteLine("</draw>");
            _drawing = false;
        }
    }
}