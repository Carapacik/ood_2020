using Adapter.GraphicsLib;

namespace Adapter.ShapeDrawingLib
{
    public class CanvasPainter
    {
        private readonly ICanvas _canvas;

        public CanvasPainter(ICanvas canvas)
        {
            _canvas = canvas;
        }

        public void Draw(ICanvasDrawable canvasDrawable)
        {
            canvasDrawable.Draw(_canvas);
        }
    }
}