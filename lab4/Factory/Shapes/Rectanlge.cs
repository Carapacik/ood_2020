using System;
using System.Collections.Generic;

namespace Factory.Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(Color color, Point leftTop, Point rightBottom) : base(color)
        {
            if (rightBottom.Y < leftTop.Y || rightBottom.X < leftTop.X)
                throw new ArgumentException("Cannot build a Rectangle from these parameters!");

            LeftTop = leftTop;
            RightBottom = rightBottom;
        }

        private Point LeftTop { get; }
        private Point RightBottom { get; }

        public override void Draw(ICanvas canvas)
        {
            canvas.Color = Color;
            var points = new List<Point>
                {LeftTop, new Point(RightBottom.X, LeftTop.Y), RightBottom, new Point(LeftTop.X, RightBottom.Y)};
            canvas.DrawLine(points[0], points[1]);
            canvas.DrawLine(points[1], points[2]);
            canvas.DrawLine(points[2], points[3]);
            canvas.DrawLine(points[3], points[0]);
        }
    }
}