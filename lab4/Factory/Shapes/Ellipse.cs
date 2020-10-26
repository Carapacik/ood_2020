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

        private Point Center { get; }
        private double RadiusX { get; }
        private double RadiusY { get; }

        public override void Draw(ICanvas canvas)
        {
            canvas.Color = Color;
            canvas.DrawEllipse(Center, RadiusX, RadiusY);
        }
    }
}