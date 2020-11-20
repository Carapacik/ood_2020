namespace Composite
{
    public class Rect
    {
        public readonly double Height;
        public readonly Point LeftTop;
        public readonly double Width;

        public Rect(Point leftTop, double width, double height)
        {
            LeftTop = leftTop;
            Width = width;
            Height = height;
        }
    }
}