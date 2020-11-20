using System;
using Composite.Styles;

namespace Composite.Shapes
{
    public class Rectangle : IShape
    {
        public Rectangle(Point leftTop, double width, double height)
        {
            if (width < 0 || height < 0) throw new Exception("Cannot build a Rectangle from these parameters!");

            LeftTop = leftTop;
            Width = width;
            Height = height;
            OutlineStyle = new OutlineStyle(0x00000000, 1);
            FillStyle = new Style();
        }

        private Point LeftTop { get; set; }
        private double Width { get; set; }
        private double Height { get; set; }

        public Rect GetFrame()
        {
            return new Rect(LeftTop, Width, Height);
        }

        public void SetFrame(Rect frame)
        {
            LeftTop = frame.LeftTop;
            Width = frame.Width;
            Height = frame.Height;
        }

        public IOutlineStyle OutlineStyle { get; }
        public IStyle FillStyle { get; }

        public void Draw(ICanvas canvas)
        {
            var frame = GetFrame();
            var points = new[]
            {
                frame.LeftTop, new Point(frame.LeftTop.X + frame.Width, frame.LeftTop.Y),
                new Point(frame.LeftTop.X + frame.Width, frame.LeftTop.Y + frame.Height),
                new Point(frame.LeftTop.X, frame.LeftTop.Y + frame.Height)
            };

            if (FillStyle.IsEnabled.HasValue && FillStyle.IsEnabled.Value && FillStyle.Color.HasValue)
            {
                canvas.SetFillColor(FillStyle.Color.Value);
                canvas.FillPolygon(points);
            }

            if (!OutlineStyle.IsEnabled.HasValue || !OutlineStyle.IsEnabled.Value || !OutlineStyle.Color.HasValue ||
                !OutlineStyle.Thickness.HasValue) return;
            canvas.SetLineThickness(OutlineStyle.Thickness.Value);
            canvas.SetOutlineColor(OutlineStyle.Color.Value);
            canvas.DrawLine(points[0], points[1]);
            canvas.DrawLine(points[1], points[2]);
            canvas.DrawLine(points[2], points[3]);
            canvas.DrawLine(points[3], points[0]);
        }
    }
}