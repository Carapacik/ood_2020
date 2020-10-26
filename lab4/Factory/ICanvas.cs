using Factory.Shapes;

namespace Factory
{
    public interface ICanvas
    {
        Color Color { set; }
        void DrawLine(Point from, Point to);
        void DrawEllipse(Point center, double width, double height);
    }
}