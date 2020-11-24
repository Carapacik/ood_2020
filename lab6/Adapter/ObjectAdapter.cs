using System.Drawing;
using Adapter.GraphicsLib;
using Adapter.ModernGraphicsLib;
using Point = Adapter.ModernGraphicsLib.Point;

namespace Adapter
{
    public class ObjectAdapter : ICanvas
    {
        private readonly RgbaColor _color = new RgbaColor(0, 0, 0, 1);
        private readonly ModernGraphicsRenderer _renderer;
        private Point _point;

        public ObjectAdapter(ModernGraphicsRenderer renderer)
        {
            _renderer = renderer;
        }

        public void LineTo(int x, int y)
        {
            _renderer.DrawLine(_point, new Point(x, y), _color);
            MoveTo(x, y);
        }

        public void MoveTo(int x, int y)
        {
            _point = new Point(x, y);
        }

        public void SetColor(uint rgbColor)
        {
            var color = Color.FromArgb((int) rgbColor);
            _color.R = color.R / 255f;
            _color.G = color.G / 255f;
            _color.B = color.B / 255f;
            _color.A = 1.0f;
        }
    }
}