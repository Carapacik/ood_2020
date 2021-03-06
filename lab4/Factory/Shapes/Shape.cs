namespace Factory.Shapes
{
    public abstract class Shape
    {
        protected Shape(Color color)
        {
            Color = color;
        }

        public Color Color { get; }

        public abstract void Draw(ICanvas canvas);
    }
}