using System;
using System.IO;
using Factory;
using Factory.Shapes;
using Xunit;

namespace FactoryTests
{
    public class ShapeTests
    {
        [Fact]
        private void Ellipse_Create_ExpectedPropertyValues()
        {
            var center = new Point(100, 100);
            const double radiusX = 10;
            const double radiusY = 11;
            const Color color = Color.Pink;
            var shape = new Ellipse(color, center, radiusX, radiusY);
            
            Assert.Equal(color, shape.Color);
            Assert.Equal(center, shape.Center);
            Assert.Equal(radiusX, shape.RadiusX);
            Assert.Equal(radiusY, shape.RadiusY);
        }

        [Fact]
        private void Ellipse_Draw_WriteDrawInfo()
        {
            var center = new Point(100, 100);
            const double radiusX = 10;
            const double radiusY = 11;
            const Color color = Color.Pink;
            var shape = new Ellipse(color, center, radiusX, radiusY);
            var sw = new StringWriter();
            var canvas = new TestCanvas(sw);
            shape.Draw(canvas);
            var expected = $"Pink ellipse center: {center} radiusX: {radiusX}, radiusY: {radiusY}\r\n";
            
            Assert.Equal(expected, sw.ToString());
        }


        [Fact]
        private void Triangle_Create_ExpectedPropertyValues()
        {
            var vertex1 = new Point(10, 10);
            var vertex2 = new Point(25, 25);
            var vertex3 = new Point(35, 10);
            const Color color = Color.Black;
            var shape = new Triangle(color, vertex1, vertex2, vertex3);
            
            Assert.Equal(color, shape.Color);
            Assert.Equal(vertex1, shape.Vertex1);
            Assert.Equal(vertex2, shape.Vertex2);
            Assert.Equal(vertex3, shape.Vertex3);
        }

        [Fact]
        private void Triangle_Draw_WriteDrawInfo()
        {
            var vertex1 = new Point(10, 10);
            var vertex2 = new Point(25, 25);
            var vertex3 = new Point(35, 10);
            const Color color = Color.Black;
            var shape = new Triangle(color, vertex1, vertex2, vertex3);
            var sw = new StringWriter();
            var canvas = new TestCanvas(sw);
            shape.Draw(canvas);
            var expected = $"Black line from {vertex1} to {vertex2}\r\n" +
                           $"Black line from {vertex2} to {vertex3}\r\nBlack line from {vertex3} to {vertex1}\r\n";
            
            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        private void Rectangle_CreateWithCorrectData_ExpectedPropertyValues()
        {
            var leftTop = new Point(10, 10);
            var rightBottom = new Point(25, 25);
            const Color color = Color.Black;
            var shape = new Rectangle(color, leftTop, rightBottom);
            
            Assert.Equal(color, shape.Color);
            Assert.Equal(leftTop, shape.LeftTop);
            Assert.Equal(rightBottom, shape.RightBottom);
        }

        [Fact]
        public void Rectangle_Draw_WriteDrawInfo()
        {
            var leftTop = new Point(10, 10);
            var rightBottom = new Point(25, 25);
            const Color color = Color.Black;
            var shape = new Rectangle(color, leftTop, rightBottom);
            var sw = new StringWriter();
            var canvas = new TestCanvas(sw);
            shape.Draw(canvas);
            const string expected = "Black line from (10, 10) to (25, 10)\r\nBlack line from (25, 10) to (25, 25)\r\n" +
                                    "Black line from (25, 25) to (10, 25)\r\nBlack line from (10, 25) to (10, 10)\r\n";
            
            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        private void Rectangle_CreateWithIncorrectData_ThrowException()
        {
            var leftTop = new Point(30, 30);
            var rightBottom = new Point(10, 10);
            const Color color = Color.Black;
            
            Assert.Throws<ArgumentException>(() => new Rectangle(color, leftTop, rightBottom));
        }

        [Fact]
        private void RegularPolygon_CreateWithCorrectData_ExpectedPropertyValues()
        {
            const int vertexCount = 6;
            var center = new Point(10, 10);
            const int radius = 100;
            const Color color = Color.Blue;
            var shape = new RegularPolygon(color, vertexCount, center, radius);
            
            Assert.Equal(color, shape.Color);
            Assert.Equal(vertexCount, shape.VertexCount);
            Assert.Equal(center, shape.Center);
            Assert.Equal(radius, shape.Radius);
        }

        [Fact]
        private void RegularPolygon_CreateWithInvalidData_ExpectedPropertyValues()
        {
            const int vertexCount = 2;
            var center = new Point(10, 10);
            const int radius = 100;
            const Color color = Color.Blue;
            
            Assert.Throws<Exception>(() => new RegularPolygon(color, vertexCount, center, radius));
        }
    }
}