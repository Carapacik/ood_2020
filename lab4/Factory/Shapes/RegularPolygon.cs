using System;
using System.Collections.Generic;

namespace Factory.Shapes
{
    public class RegularPolygon : Shape
    {
        public RegularPolygon(Color color, int vertexCount, Point center, double radius) : base(color)
        {
            if (vertexCount < 3)
                throw new Exception("Regular polygon should has at least 3 vertexes!");

            VertexCount = vertexCount;
            Center = center;
            Radius = radius;
        }

        private int VertexCount { get; }
        private Point Center { get; }
        private double Radius { get; }

        private List<Point> Vertices
        {
            get
            {
                var vertexes = new List<Point>();
                var offset = 2 * Math.PI / VertexCount;

                for (var i = 0; i < VertexCount; i++)
                    vertexes.Add(new Point(Center.X + Radius * Math.Cos(offset * i),
                        Center.Y + Radius * Math.Sin(offset * i)));

                return vertexes;
            }
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.Color = Color;
            var vertexes = Vertices;

            for (var i = 0; i < VertexCount - 1; i++)
                canvas.DrawLine(vertexes[i], vertexes[i + 1]);
            canvas.DrawLine(vertexes[^1], vertexes[0]);
        }
    }
}