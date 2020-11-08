using Adapter.GraphicsLib;

namespace Adapter.ShapeDrawingLib
{
    public class Rectangle : ICanvasDrawable
    {
        private readonly uint _color;
        private readonly int _height;
        private readonly Point _leftTop;
        private readonly int _width;

        public Rectangle(Point leftTop, int width, int height, uint color = 0x000000)
        {
            _leftTop = leftTop;
            _width = width;
            _height = height;
            _color = color;
        }

        public void Draw(ICanvas canvas)
        {
            canvas.SetColor(_color);
            canvas.MoveTo(_leftTop.X, _leftTop.Y);
            canvas.LineTo(_leftTop.X, _leftTop.Y + _height);
            canvas.LineTo(_leftTop.X + _width, _leftTop.Y + _height);
            canvas.LineTo(_leftTop.X + _width, _leftTop.Y);
            canvas.LineTo(_leftTop.X, _leftTop.Y);
        }
    }
}