using System.IO;
using Composite;

namespace CompositeTests
{
    public class TestCanvas : ICanvas
    {
        private readonly TextWriter _textWriter;

        public TestCanvas(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public void SetOutlineColor(uint color)
        {
            _textWriter.WriteLine($"SetOutlineColor #{color}");
        }

        public void SetLineThickness(uint value)
        {
            _textWriter.WriteLine($"SetLineThickness #{value}");
        }

        public void SetFillColor(uint color)
        {
            _textWriter.WriteLine($"SetFillColor #{color}");
        }

        public void DrawLine(Point from, Point to)
        {
            _textWriter.WriteLine($"DrawLine from {from} to {to}");
        }

        public void FillPolygon(Point[] points)
        {
            _textWriter.WriteLine("FillPolygon:");
            foreach (var p in points) _textWriter.WriteLine(p);
        }

        public void DrawEllipse(Point center, double radiusX, double radiusY)
        {
            _textWriter.WriteLine($"Ellipse center {center} radiusX {radiusX} radiusY {radiusY}");
        }

        public void FillEllipse(Point center, double radiusX, double radiusY)
        {
            _textWriter.WriteLine($"FillEllipse center {center} radiusX {radiusX} radiusY {radiusY}");
        }
    }
}