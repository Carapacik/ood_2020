namespace Factory.Shapes
{
    public class Triangle : Shape
    {
        public Triangle(Color color, Point vertex1, Point vertex2, Point vertex3) : base(color)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            Vertex3 = vertex3;
        }

        private Point Vertex1 { get; }
        private Point Vertex2 { get; }
        private Point Vertex3 { get; }

        public override void Draw(ICanvas canvas)
        {
            canvas.Color = Color;
            canvas.DrawLine(Vertex1, Vertex2);
            canvas.DrawLine(Vertex2, Vertex3);
            canvas.DrawLine(Vertex3, Vertex1);
        }
    }
}