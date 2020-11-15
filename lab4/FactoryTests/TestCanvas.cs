using System.IO;
using Factory;

namespace FactoryTests
{
    public class TestCanvas : ICanvas
    {
        private readonly TextWriter _textWriter;

        public TestCanvas(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public Color Color { get; set; }

        public void DrawLine(Point from, Point to)
        {
            _textWriter.WriteLine($"{ColorToString()} line from {from} to {to}");
        }

        public void DrawEllipse(Point center, double w, double h)
        {
            _textWriter.WriteLine($"{ColorToString()} ellipse center: {center} radiusX: {w}, radiusY: {h}");
        }

        private string ColorToString()
        {
            return Color switch
            {
                Color.Red => "Red",
                Color.Green => "Green",
                Color.Blue => "Blue",
                Color.Yellow => "Yellow",
                Color.Pink => "Pink",
                _ => "Black"
            };
        }
    }
}