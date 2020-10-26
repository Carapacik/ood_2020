using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Factory.Shapes;

namespace Factory
{
    public class ShapeFactory : IShapeFactory
    {
        private readonly Dictionary<string, Func<Color, string[], Shape>> _commands;

        public ShapeFactory()
        {
            _commands = new Dictionary<string, Func<Color, string[], Shape>>
            {
                {"rectangle", CreateRectangle},
                {"triangle", CreateTriangle},
                {"regularPolygon", CreateRegularPolygon},
                {"ellipse", CreateEllipse}
            };
        }

        public Shape CreateShape(string description)
        {
            var shape = new KeyValuePair<string, Func<Color, string[], Shape>>();
            foreach (var x in _commands.Where(x => description.StartsWith(x.Key)))
            {
                shape = x;
                break;
            }

            var command = shape.Value;
            if (command == null) throw new ArgumentException("Couldn't parse shape name");

            var args = description.Split();
            if (!Enum.TryParse<Color>(args[1], true, out var color))
                throw new ArgumentException("Couldn't parse shape color");

            return command.Invoke(color, description.Split().Skip(2).ToArray());
        }

        private static Shape CreateRectangle(Color color, string[] args)
        {
            if (args.Length < 4) throw new Exception("Couldn't create rectangle: not enough arguments");

            if (double.TryParse(args[0], NumberStyles.Any, CultureInfo.InvariantCulture, out var topLeftX) &&
                double.TryParse(args[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var topLeftY) &&
                double.TryParse(args[2], NumberStyles.Any, CultureInfo.InvariantCulture, out var bottomRightX) &&
                double.TryParse(args[3], NumberStyles.Any, CultureInfo.InvariantCulture, out var bottomRightY))
                return new Rectangle(color, new Point(topLeftX, topLeftY), new Point(bottomRightX, bottomRightY));

            throw new Exception("Couldn't create rectangle: failed to parse arguments");
        }

        private static Shape CreateTriangle(Color color, string[] args)
        {
            if (args.Length < 6) throw new ArgumentException("Couldn't create triangle: not enough arguments");

            if (double.TryParse(args[0], NumberStyles.Any, CultureInfo.InvariantCulture, out var v1X) &&
                double.TryParse(args[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var v1Y) &&
                double.TryParse(args[2], NumberStyles.Any, CultureInfo.InvariantCulture, out var v2X) &&
                double.TryParse(args[3], NumberStyles.Any, CultureInfo.InvariantCulture, out var v2Y) &&
                double.TryParse(args[4], NumberStyles.Any, CultureInfo.InvariantCulture, out var v3X) &&
                double.TryParse(args[5], NumberStyles.Any, CultureInfo.InvariantCulture, out var v3Y))
                return new Triangle(color, new Point(v1X, v1Y), new Point(v2X, v2Y), new Point(v3X, v3Y));

            throw new ArgumentException("Couldn't create triangle: failed to parse arguments");
        }

        private static Shape CreateEllipse(Color color, string[] args)
        {
            if (args.Length < 4) throw new ArgumentException("Couldn't create ellipse: not enough arguments");

            if (double.TryParse(args[0], NumberStyles.Any, CultureInfo.InvariantCulture, out var centerX) &&
                double.TryParse(args[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var centerY) &&
                double.TryParse(args[2], NumberStyles.Any, CultureInfo.InvariantCulture, out var radiusX) &&
                double.TryParse(args[3], NumberStyles.Any, CultureInfo.InvariantCulture, out var radiusY))
                return new Ellipse(color, new Point(centerX, centerY), radiusX, radiusY);

            throw new ArgumentException("Couldn't create ellipse: failed to parse arguments");
        }

        private static Shape CreateRegularPolygon(Color color, string[] args)
        {
            if (args.Length < 4) throw new ArgumentException("Couldn't create regularPolygon: not enough arguments");

            if (int.TryParse(args[0], NumberStyles.Any, CultureInfo.InvariantCulture, out var vertexCount) &&
                double.TryParse(args[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var centerX) &&
                double.TryParse(args[2], NumberStyles.Any, CultureInfo.InvariantCulture, out var centerY) &&
                double.TryParse(args[3], NumberStyles.Any, CultureInfo.InvariantCulture, out var radius))
                return new RegularPolygon(color, vertexCount, new Point(centerX, centerY), radius);

            throw new ArgumentException("Couldn't create regularPolygon: failed to parse arguments");
        }
    }
}