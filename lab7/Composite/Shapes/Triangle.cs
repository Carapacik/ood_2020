using System;
using Composite.Styles;

namespace Composite.Shapes
{
    public class Triangle : IShape
    {
        public Triangle(Point vertex1, Point vertex2, Point vertex3)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            Vertex3 = vertex3;

            OutlineStyle = new OutlineStyle(0x00000000, 1);
            FillStyle = new Style();
        }

        private Point Vertex1 { get; set; }
        private Point Vertex2 { get; set; }
        private Point Vertex3 { get; set; }

        public IOutlineStyle OutlineStyle { get; }
        public IStyle FillStyle { get; }

        public Rect GetFrame()
        {
            var minX = Min(Vertex1.X, Vertex2.X, Vertex3.X);
            var minY = Min(Vertex1.Y, Vertex2.Y, Vertex3.Y);
            var maxX = Max(Vertex1.X, Vertex2.X, Vertex3.X);
            var maxY = Max(Vertex1.Y, Vertex2.Y, Vertex3.Y);
            return new Rect(new Point(minX, minY), maxX - minX, maxY - minY);
        }

        public void SetFrame(Rect frame)
        {
            var prevFrame = GetFrame();
            Vertex1 = SetNewVertex(Vertex1, frame, prevFrame);
            Vertex2 = SetNewVertex(Vertex2, frame, prevFrame);
            Vertex3 = SetNewVertex(Vertex3, frame, prevFrame);
        }

        public void Draw(ICanvas canvas)
        {
            var points = new[] {Vertex1, Vertex2, Vertex3};

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
            canvas.DrawLine(points[2], points[0]);
        }

        private static double Min(double a, double b, double c)
        {
            return Math.Min(a, Math.Min(b, c));
        }

        private static double Max(double a, double b, double c)
        {
            return Math.Max(a, Math.Max(b, c));
        }

        private static Point SetNewVertex(Point p, Rect frame, Rect prevFrame)
        {
            var scaleX = (p.X - prevFrame.LeftTop.X) / prevFrame.Width;
            var scaleY = (p.Y - prevFrame.LeftTop.Y) / prevFrame.Height;
            return new Point(frame.LeftTop.X + frame.Width * scaleX, frame.LeftTop.Y + frame.Height * scaleY);
        }
    }
}