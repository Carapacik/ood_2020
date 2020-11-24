using System;
using System.Linq;
using System.Windows.Media;
using System.Windows.Shapes;
using Composite;
using canvas = System.Windows.Controls.Canvas;

namespace CompositeVisualization
{
    public class Canvas : ICanvas
    {
        private readonly canvas _canvas;
        private SolidColorBrush _fillColor;
        private SolidColorBrush _outlineColor;
        private uint _thickness;

        public Canvas(canvas canvas)
        {
            _canvas = canvas;
            _fillColor = new SolidColorBrush(Colors.Transparent);
            _outlineColor = new SolidColorBrush(Colors.Black);
            _thickness = 1;
        }

        public void SetFillColor(uint color)
        {
            _fillColor = ChooseColor(color);
        }

        public void SetOutlineColor(uint color)
        {
            _outlineColor = ChooseColor(color);
        }

        public void SetLineThickness(uint value)
        {
            _thickness = value;
        }

        public void DrawLine(Point from, Point to)
        {
            var line = new Line
            {
                X1 = from.X,
                Y1 = from.Y,
                X2 = to.X,
                Y2 = to.Y,
                Stroke = _outlineColor,
                StrokeThickness = _thickness
            };
            _canvas.Children.Add(line);
        }

        public void DrawEllipse(Point center, double radiusX, double radiusY)
        {
            var ellipse = new Ellipse
            {
                Width = radiusX * 2,
                Height = radiusY * 2,
                Stroke = _outlineColor,
                StrokeThickness = _thickness
            };

            canvas.SetLeft(ellipse, center.X - radiusX);
            canvas.SetTop(ellipse, center.Y - radiusY);
            _canvas.Children.Add(ellipse);
        }

        public void FillEllipse(Point center, double radiusX, double radiusY)
        {
            var ellipse = new Ellipse
            {
                Width = radiusX * 2,
                Height = radiusY * 2,
                Fill = _fillColor
            };

            canvas.SetLeft(ellipse, center.X - radiusX);
            canvas.SetTop(ellipse, center.Y - radiusY);
            _canvas.Children.Add(ellipse);
        }

        public void FillPolygon(Point[] points)
        {
            var polygon = new Polygon
            {
                Points = new PointCollection(points.Select(ToPoint)),
                Fill = _fillColor
            };
            _canvas.Children.Add(polygon);
        }

        private static System.Windows.Point ToPoint(Point point)
        {
            return new System.Windows.Point(point.X, point.Y);
        }

        private static SolidColorBrush ChooseColor(uint color)
        {
            var bytesColor = BitConverter.GetBytes(color);
            return new SolidColorBrush(Color.FromArgb(bytesColor[3], bytesColor[2], bytesColor[1], bytesColor[0]));
        }
    }
}