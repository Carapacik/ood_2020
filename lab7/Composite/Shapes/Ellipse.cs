using Composite.Styles;

namespace Composite.Shapes
{
    public class Ellipse : IShape
    {
        public Ellipse(Point center, double radiusX, double radiusY)
        {
            Center = center;
            RadiusX = radiusX;
            RadiusY = radiusY;

            OutlineStyle = new OutlineStyle(0x00000000, 1);
            FillStyle = new Style();
        }

        public Point Center { get; private set; }
        public double RadiusX { get; private set; }
        public double RadiusY { get; private set; }

        public Rect GetFrame()
        {
            return new(new Point(Center.X - RadiusX, Center.Y - RadiusY), 2 * RadiusX, 2 * RadiusY);
        }

        public void SetFrame(Rect frame)
        {
            var prevFrame = GetFrame();
            RadiusX *= frame.Width / prevFrame.Width;
            RadiusY *= frame.Height / prevFrame.Height;
            Center = new Point(frame.LeftTop.X + frame.Width / 2, frame.LeftTop.Y + frame.Height / 2);
        }

        public IOutlineStyle OutlineStyle { get; }
        public IStyle FillStyle { get; }

        public void Draw(ICanvas canvas)
        {
            if (FillStyle.IsEnabled.HasValue && FillStyle.IsEnabled.Value && FillStyle.Color.HasValue)
            {
                canvas.SetFillColor(FillStyle.Color.Value);
                canvas.FillEllipse(Center, RadiusX, RadiusY);
            }

            if (!OutlineStyle.IsEnabled.HasValue || !OutlineStyle.IsEnabled.Value || !OutlineStyle.Color.HasValue ||
                !OutlineStyle.Thickness.HasValue) return;
            canvas.SetLineThickness(OutlineStyle.Thickness.Value);
            canvas.SetOutlineColor(OutlineStyle.Color.Value);
            canvas.DrawEllipse(Center, RadiusX, RadiusY);
        }
    }
}