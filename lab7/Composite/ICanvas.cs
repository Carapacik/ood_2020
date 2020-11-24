namespace Composite
{
    public interface ICanvas
    {
        void SetOutlineColor(uint color);
        void SetLineThickness(uint value);
        void SetFillColor(uint color);

        void DrawLine(Point from, Point to);

        void DrawEllipse(Point center, double radiusX, double radiusY);
        void FillEllipse(Point center, double radiusX, double radiusY);

        void FillPolygon(Point[] points);
    }
}