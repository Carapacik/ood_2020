using Composite.Shapes;

namespace Composite
{
    public class Slide : ShapeManager, IDrawable
    {
        public Slide(int width, int height, uint backgroundColor)
        {
            Width = width;
            Height = height;
            BackgroundColor = backgroundColor;
        }

        private double Width { get; }
        private double Height { get; }
        private uint BackgroundColor { get; }

        public void Draw(ICanvas canvas)
        {
            var points = new[] {new Point(0, 0), new Point(Width, 0), new Point(Width, Height), new Point(0, Height)};
            canvas.SetFillColor(BackgroundColor);
            canvas.FillPolygon(points);
            canvas.DrawLine(points[0], points[1]);
            canvas.DrawLine(points[1], points[2]);
            canvas.DrawLine(points[2], points[3]);
            canvas.DrawLine(points[3], points[0]);

            for (var i = 0; i < ShapesCount; i++) GetShapeByIndex(i).Draw(canvas);
        }
    }
}