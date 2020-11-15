using System;
using Factory;
using Factory.Shapes;
using Xunit;

namespace FactoryTests
{
    public class ShapeFactoryTests
    {
        [Fact]
        private void CreateShape_InvalidDescription_ExceptionIsThrown()
        {
            const string inputStr = "concuss";
            var shapeFactory = new ShapeFactory();
            Assert.Throws<ArgumentException>(() => shapeFactory.CreateShape(inputStr));
        }

        [Fact]
        private void CreateShape_InvalidColor_ExceptionIsThrown()
        {
            const string inputStr = "rectangle brown 250 250 500 400";
            var shapeFactory = new ShapeFactory();
            Assert.Throws<ArgumentException>(() => shapeFactory.CreateShape(inputStr));
        }

        [Fact]
        public void CreateShape_RegularPolygon_WithValidArgs()
        {
            var shapeFactory = new ShapeFactory();
            var center = new Point(11, 10);
            const double radius = 11.2;
            const int vertexCount = 5;
            const Color color = Color.Blue;
            var regularPolygon = new RegularPolygon(color, vertexCount, center, radius);
            var shape = (RegularPolygon) shapeFactory.CreateShape($"regularPolygon {color} 5 11 10 11.2");
            
            Assert.IsType<RegularPolygon>(shape);
            Assert.Equal(regularPolygon.Color, shape.Color);
            Assert.Equal(regularPolygon.Center.X, shape.Center.X);
            Assert.Equal(regularPolygon.Center.Y, shape.Center.Y);
            Assert.Equal(regularPolygon.Radius, shape.Radius);
            Assert.Equal(regularPolygon.VertexCount, shape.VertexCount);
        }

        [Fact]
        private void CreateShape_RegularPolygonIncorrectArgumentCount_ThrowException()
        {
            const string inputStr = "regularPolygon black 10 10 2";
            var shapeFactory = new ShapeFactory();
            
            Assert.Throws<ArgumentException>(() => shapeFactory.CreateShape(inputStr));
        }

        [Fact]
        private void CreateShape_RegularPolygonInvalidArguments_ThrowException()
        {
            const string inputStr = "regularPolygon black 10 cs10 20 monster";
            var shapeFactory = new ShapeFactory();
            
            Assert.Throws<ArgumentException>(() => shapeFactory.CreateShape(inputStr));
        }

        [Fact]
        public void CreateShape_Triangle_WithValidArgs()
        {
            var shapeFactory = new ShapeFactory();
            var vertex1 = new Point(-2, 3);
            var vertex2 = new Point(4.05, 3);
            var vertex3 = new Point(2, 5);
            const Color color = Color.Blue;
            var triangle = new Triangle(color, vertex1, vertex2, vertex3);
            var shape = (Triangle) shapeFactory.CreateShape($"triangle {color} -2 3 4.05 3 2 5");
            
            Assert.IsType<Triangle>(shape);
            Assert.Equal(triangle.Color, shape.Color);
            Assert.Equal(triangle.Vertex1.X, shape.Vertex1.X);
            Assert.Equal(triangle.Vertex1.Y, shape.Vertex1.Y);
            Assert.Equal(triangle.Vertex2.X, shape.Vertex2.X);
            Assert.Equal(triangle.Vertex2.Y, shape.Vertex2.Y);
            Assert.Equal(triangle.Vertex3.X, shape.Vertex3.X);
            Assert.Equal(triangle.Vertex3.Y, shape.Vertex3.Y);
        }

        [Fact]
        private void CreateShape_TriangleIncorrectArgumentCount_ThrowException()
        {
            const string inputStr = "triangle blue 20 20";
            var shapeFactory = new ShapeFactory();
            
            Assert.Throws<ArgumentException>(() => shapeFactory.CreateShape(inputStr));
        }

        [Fact]
        private void CreateShape_TriangleInvalidArguments_ThrowException()
        {
            const string inputStr = "triangle blue 20 20 trinket";
            var shapeFactory = new ShapeFactory();
            
            Assert.Throws<ArgumentException>(() => shapeFactory.CreateShape(inputStr));
        }

        [Fact]
        public void CreateShape_Rectangle_WithValidArgs()
        {
            var shapeFactory = new ShapeFactory();
            var leftTop = new Point(10, 10.1);
            var rightBottom = new Point(25, 25);
            const Color color = Color.Pink;
            var rectangle = new Rectangle(color, leftTop, rightBottom);
            var shape = (Rectangle) shapeFactory.CreateShape($"rectangle {color} 10 10.1 25 25");
            
            Assert.IsType<Rectangle>(shape);
            Assert.Equal(rectangle.Color, shape.Color);
            Assert.Equal(rectangle.LeftTop.X, shape.LeftTop.X);
            Assert.Equal(rectangle.LeftTop.Y, shape.LeftTop.Y);
            Assert.Equal(rectangle.RightBottom.X, shape.RightBottom.X);
            Assert.Equal(rectangle.RightBottom.Y, shape.RightBottom.Y);
        }

        [Fact]
        private void CreateShape_RectangleIncorrectArgumentCount_ThrowException()
        {
            const string inputStr = "rectangle pink 10 10";
            var shapeFactory = new ShapeFactory();
            
            Assert.Throws<Exception>(() => shapeFactory.CreateShape(inputStr));
        }

        [Fact]
        private void CreateShape_RectangleInvalidArguments_ThrowException()
        {
            const string inputStr = "rectangle black 20 20.5 60 an animal";
            var shapeFactory = new ShapeFactory();
            
            Assert.Throws<Exception>(() => shapeFactory.CreateShape(inputStr));
        }

        [Fact]
        public void CreateShape_Ellipse_WithValidArgs()
        {
            var shapeFactory = new ShapeFactory();
            var center = new Point(25.3, 25.3);
            const double radiusX = 25.6;
            const double radiusY = 10.2;
            const Color color = Color.Blue;
            var ellipse = new Ellipse(color, center, radiusX, radiusY);
            var shape = (Ellipse) shapeFactory.CreateShape($"ellipse {color} 25.3 25.3 25.6 10.2");
            
            Assert.IsType<Ellipse>(shape);
            Assert.Equal(ellipse.Color, shape.Color);
            Assert.Equal(ellipse.Center.X, shape.Center.X);
            Assert.Equal(ellipse.Center.Y, shape.Center.Y);
            Assert.Equal(ellipse.RadiusX, shape.RadiusX);
            Assert.Equal(ellipse.RadiusY, shape.RadiusY);
        }

        [Fact]
        private void CreateShape_EllipseIncorrectArgumentCount_ThrowException()
        {
            const string inputStr = "ellipse black 20 20";
            var shapeFactory = new ShapeFactory();
            
            Assert.Throws<ArgumentException>(() => shapeFactory.CreateShape(inputStr));
        }

        [Fact]
        private void CreateShape_EllipseInvalidArguments_ThrowException()
        {
            const string inputStr = "ellipse black 20 20 s mmm";
            var shapeFactory = new ShapeFactory();
            
            Assert.Throws<ArgumentException>(() => shapeFactory.CreateShape(inputStr));
        }
    }
}