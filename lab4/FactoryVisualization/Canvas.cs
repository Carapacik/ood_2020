using System;
using System.Windows.Media;
using System.Windows.Shapes;
using Factory;
using Color = Factory.Color;
using Ellipse = System.Windows.Shapes.Ellipse;

namespace FactoryVisualization
{
    public class Canvas : ICanvas
    {
        private readonly System.Windows.Controls.Canvas _canvas;

        public Canvas(System.Windows.Controls.Canvas canvas)
        {
            _canvas = canvas;
        }

        public Color Color { get; set; }

        public void DrawLine(Point from, Point to)
        {
            var line = new Line
            {
                X1 = from.X,
                Y1 = from.Y,
                X2 = to.X,
                Y2 = to.Y,
                Stroke = ChooseColor()
            };
            _canvas.Children.Add(line);
        }

        public void DrawEllipse(Point center, double xRadius, double yRadius)
        {
            var ellipse = new Ellipse
            {
                Width = xRadius * 2,
                Height = yRadius * 2,
                Stroke = ChooseColor()
            };

            System.Windows.Controls.Canvas.SetLeft(ellipse, center.X - xRadius);
            System.Windows.Controls.Canvas.SetTop(ellipse, center.Y - yRadius);
            _canvas.Children.Add(ellipse);
        }

        private SolidColorBrush ChooseColor()
        {
            return Color switch
            {
                Color.Red => Brushes.Red,
                Color.Green => Brushes.Green,
                Color.Blue => Brushes.Blue,
                Color.Pink => Brushes.Pink,
                Color.Yellow => Brushes.Yellow,
                Color.Black => Brushes.Black,
                _ => throw new Exception(
                    $"{Color} isn't available in our color library.")
            };
        }
    }
}