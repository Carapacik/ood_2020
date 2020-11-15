namespace Factory.Shapes
{
    public class Ellipse : Shape
    {
        public Ellipse(Color color, Point center, double radiusX, double radiusY) : base(color)
        {
            Center = center;
            RadiusX = radiusX;
            RadiusY = radiusY;
        }

        public Point Center { get; }
        public double RadiusX { get; }
        public double RadiusY { get; }

        public override void Draw(ICanvas canvas)
        {
            canvas.Color = Color;
            canvas.DrawEllipse(Center, RadiusX, RadiusY);
        }
    }
}