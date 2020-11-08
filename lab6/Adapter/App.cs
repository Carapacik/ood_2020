using System;
using Adapter.GraphicsLib;
using Adapter.ModernGraphicsLib;
using Adapter.ShapeDrawingLib;
using Point = Adapter.ShapeDrawingLib.Point;

namespace Adapter
{
    public static class App
    {
        public static void PaintPicture(CanvasPainter canvasPainter)
        {
            var triangle = new Triangle(new Point(10, 15), new Point(100, 200), new Point(150, 250), 0xDEDE1F);
            var rectangle = new Rectangle(new Point(30, 40), 18, 24);

            Console.WriteLine("Triangle:");
            canvasPainter.Draw(triangle);
            Console.WriteLine("Rectangle:");
            canvasPainter.Draw(rectangle);
        }

        public static void PaintPictureOnCanvas()
        {
            var canvas = new Canvas();
            var canvasPainter = new CanvasPainter(canvas);
            PaintPicture(canvasPainter);
        }

        public static void PaintPictureOnModernGraphicsRendererObject()
        {
            var renderer = new ModernGraphicsRenderer(Console.Out);
            var objectAdapter = new ObjectAdapter(renderer);
            var canvasPainter = new CanvasPainter(objectAdapter);

            try
            {
                renderer.BeginDraw();
                PaintPicture(canvasPainter);
                renderer.EndDraw();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void PaintPictureOnModernGraphicsRendererClass()
        {
            var classAdapter = new ClassAdapter(Console.Out);
            var painter = new CanvasPainter(classAdapter);

            try
            {
                classAdapter.BeginDraw();
                PaintPicture(painter);
                classAdapter.EndDraw();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}