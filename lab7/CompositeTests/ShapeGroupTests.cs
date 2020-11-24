using System.IO;
using Composite;
using Composite.Shapes;
using Xunit;

namespace CompositeTests
{
    public class ShapeGroupTests
    {
        [Fact]
        private void GetFrame_SingleShape_ReturnShapeFrame()
        {
            var groupShape = new ShapeGroup();
            var ellipse = new Ellipse(new Point(25, 25), 25, 30);
            groupShape.InsertShape(ellipse);

            var frame = groupShape.GetFrame();

            Assert.Equal(ellipse.GetFrame().LeftTop, frame.LeftTop);
            Assert.Equal(ellipse.GetFrame().Width, frame.Width);
            Assert.Equal(ellipse.GetFrame().Height, frame.Height);
        }

        [Fact]
        private void GetFrame_MultiplyShape_ReturnCombinedFrame()
        {
            var groupShape = new ShapeGroup();
            var ellipse = new Ellipse(new Point(25, 25), 25, 30);
            var rectangle = new Rectangle(new Point(50, 50), 10, 30);
            var triangle = new Triangle(new Point(10, 10), new Point(30, 10), new Point(10, 30));

            groupShape.InsertShape(ellipse);
            groupShape.InsertShape(rectangle);
            groupShape.InsertShape(triangle);

            var frame = groupShape.GetFrame();

            Assert.Equal(new Point(0, -5), frame.LeftTop);
            Assert.Equal(60, frame.Width);
            Assert.Equal(85, frame.Height);
        }

        [Fact]
        private void GetFrame_EmptyShape_ReturnNull()
        {
            var groupShape = new ShapeGroup();
            var frame = groupShape.GetFrame();

            Assert.Null(frame);
        }

        [Fact]
        private void GetFrame_EmptyGroup_ReturnNull()
        {
            var groupShape = new ShapeGroup();
            groupShape.InsertShape(new ShapeGroup());
            var frame = groupShape.GetFrame();

            Assert.Null(frame);
        }

        [Fact]
        private void SetFrame_SingleShape_ShapeResizedCorrectly()
        {
            var groupShape = new ShapeGroup();
            var ellipse = new Ellipse(new Point(100, 100), 25, 25);
            groupShape.InsertShape(ellipse);

            var newFrame = new Rect(new Point(200, 200), 60, 60);

            groupShape.SetFrame(newFrame);

            var someShape = groupShape.GetShapeByIndex(0);
            Assert.Equal(newFrame.LeftTop, someShape.GetFrame().LeftTop);
            Assert.Equal(newFrame.Width, someShape.GetFrame().Width);
            Assert.Equal(newFrame.Height, someShape.GetFrame().Height);
            var ellipseShape = Assert.IsType<Ellipse>(someShape);
            Assert.Equal(new Point(230, 230), ellipseShape.Center);
            Assert.Equal(30, ellipseShape.RadiusX);
            Assert.Equal(30, ellipseShape.RadiusY);
        }

        [Fact]
        private void SetFrame_MultiplyShape_ReturnCombinedFrame()
        {
            var groupShape = new ShapeGroup();
            var ellipse = new Ellipse(new Point(20, 20), 25, 30);
            var rectangle = new Rectangle(new Point(50, 50), 10, 30);

            groupShape.InsertShape(ellipse);
            groupShape.InsertShape(rectangle, 1);

            groupShape.SetFrame(new Rect(new Point(50, 50), 40, 40));

            var ellipseShape = Assert.IsType<Ellipse>(groupShape.GetShapeByIndex(0));
            Assert.Equal(new Point(65.38461538461539, 63.33333333333333), ellipseShape.Center);
            Assert.Equal(15.384615384615385, ellipseShape.RadiusX);
            Assert.Equal(13.333333333333332, ellipseShape.RadiusY);

            var rectangleShape = Assert.IsType<Rectangle>(groupShape.GetShapeByIndex(1));
            Assert.Equal(new Point(83.84615384615384, 76.66666666666666), rectangleShape.GetFrame().LeftTop);
            Assert.Equal(6.153846153846154, rectangleShape.GetFrame().Width);
            Assert.Equal(13.333333333333332, rectangleShape.GetFrame().Height);
        }

        [Fact]
        private void StylesGet_EmptyChildShapes_ReturnsNull()
        {
            var groupShape = new ShapeGroup();

            var fillStyle = groupShape.FillStyle;
            var outlineStyle = groupShape.OutlineStyle;

            Assert.Null(fillStyle);
            Assert.Null(outlineStyle);
        }

        [Fact]
        private void StylesGet_ShapesWithSameColor_ReturnsColor()
        {
            var groupShape = new ShapeGroup();
            const uint fillColor = 0xFFB22222;
            const uint outlineColor = 0xFFFF1493;
            var rectangle = new Rectangle(new Point(100, 100), 20, 30);
            rectangle.FillStyle.Color = fillColor;
            rectangle.OutlineStyle.Color = outlineColor;
            var triangle = new Triangle(new Point(10, 10), new Point(20, 10), new Point(10, 20));
            triangle.FillStyle.Color = fillColor;
            triangle.OutlineStyle.Color = outlineColor;

            groupShape.InsertShape(rectangle);
            groupShape.InsertShape(triangle);

            var actualFillColor = groupShape.FillStyle.Color;
            var actualOutlineColor = groupShape.OutlineStyle.Color;

            Assert.Equal(fillColor, actualFillColor);
            Assert.Equal(outlineColor, actualOutlineColor);
        }

        [Fact]
        private void StylesGet_ShapesWithDifferentColor_ReturnNullColor()
        {
            var groupShape = new ShapeGroup();
            var rectangle = new Rectangle(new Point(100, 100), 20, 30);
            const uint fillColor = 0xFFB22222;
            const uint outlineColor = 0xFFFF1493;
            rectangle.FillStyle.Color = fillColor;
            rectangle.OutlineStyle.Color = outlineColor;
            var triangle = new Triangle(new Point(10, 10), new Point(20, 10), new Point(10, 20));
            groupShape.InsertShape(rectangle);
            groupShape.InsertShape(triangle);

            var actualFillStyle = groupShape.FillStyle;
            var actualOutlineStyle = groupShape.OutlineStyle;

            Assert.True(actualFillStyle.IsEnabled);
            Assert.Null(actualFillStyle.Color);
            Assert.True(actualOutlineStyle.IsEnabled);
            Assert.Equal((uint) 1, actualOutlineStyle.Thickness);
            Assert.Null(actualOutlineStyle.Color);
        }

        [Fact]
        private void StylesSet_ShapesWithDifferentStyles_ShapesHaveNewStyle()
        {
            var groupShape = new ShapeGroup();
            var rectangle = new Rectangle(new Point(100, 100), 20, 30);
            const uint fillColor = 0xFFB22222;
            const uint outlineColor = 0xFFFF1493;
            rectangle.FillStyle.Color = fillColor;
            rectangle.OutlineStyle.Color = outlineColor;
            var triangle = new Triangle(new Point(10, 10), new Point(20, 10), new Point(10, 20));
            groupShape.InsertShape(rectangle);
            groupShape.InsertShape(triangle);

            const uint newFillColor = 0xFFFFFFFF;
            const uint newOutlineColor = 0x00000000;
            const uint newOutlineThickness = 2;

            groupShape.FillStyle.Color = newFillColor;
            groupShape.OutlineStyle.Color = newOutlineColor;
            groupShape.OutlineStyle.Thickness = newOutlineThickness;

            Assert.Equal(newFillColor, rectangle.FillStyle.Color);
            Assert.Equal(newOutlineColor, rectangle.OutlineStyle.Color);
            Assert.Equal(newOutlineThickness, rectangle.OutlineStyle.Thickness);

            Assert.Equal(newFillColor, triangle.FillStyle.Color);
            Assert.Equal(newOutlineColor, triangle.OutlineStyle.Color);
            Assert.Equal(newOutlineThickness, triangle.OutlineStyle.Thickness);
        }

        [Fact]
        private void StylesSet_ChangeStyleProperties_StylesChangedOurProperties()
        {
            var groupShape = new ShapeGroup();
            const uint fillColor = 0xFFB22222;
            const uint outlineColor = 0xFFFF1493;
            var rectangle = new Rectangle(new Point(100, 100), 20, 30);
            rectangle.FillStyle.Color = fillColor;
            rectangle.OutlineStyle.Color = outlineColor;
            var triangle = new Triangle(new Point(10, 10), new Point(20, 10), new Point(10, 20));
            triangle.FillStyle.Color = fillColor;
            triangle.OutlineStyle.Color = outlineColor;

            groupShape.InsertShape(rectangle);
            groupShape.InsertShape(triangle, 1);

            var fillStyle = groupShape.FillStyle;
            var outlineStyle = groupShape.OutlineStyle;
            const uint newColor = 0xFFFFFFFF;
            const bool newEnableState = false;
            const uint newThickness = 3;

            fillStyle.Color = newColor;
            outlineStyle.Color = newColor;
            fillStyle.IsEnabled = newEnableState;
            outlineStyle.IsEnabled = newEnableState;
            outlineStyle.Thickness = newThickness;

            var rectangleShape = Assert.IsType<Rectangle>(groupShape.GetShapeByIndex(0));
            Assert.Equal(newColor, rectangleShape.FillStyle.Color);
            Assert.Equal(newColor, rectangleShape.OutlineStyle.Color);
            Assert.Equal(newThickness, rectangleShape.OutlineStyle.Thickness);
            Assert.Equal(newEnableState, rectangleShape.OutlineStyle.IsEnabled);
            Assert.Equal(newEnableState, rectangleShape.FillStyle.IsEnabled);
            var triangleShape = Assert.IsType<Triangle>(groupShape.GetShapeByIndex(1));
            Assert.Equal(newColor, triangleShape.FillStyle.Color);
            Assert.Equal(newColor, triangleShape.OutlineStyle.Color);
            Assert.Equal(newThickness, triangleShape.OutlineStyle.Thickness);
            Assert.Equal(newEnableState, triangleShape.OutlineStyle.IsEnabled);
            Assert.Equal(newEnableState, triangleShape.FillStyle.IsEnabled);
        }

        [Fact]
        private void Draw_TwoShapes_CorrectDrawOnCanvasAllShapes()
        {
            const uint fillColor = 0xFFB22222;
            const uint outlineColor = 0xFFFF1493;
            const uint thickness = 2;

            var triangle = new Triangle(new Point(10, 10), new Point(30, 10), new Point(10, 30));
            triangle.FillStyle.Color = fillColor;
            triangle.OutlineStyle.Color = outlineColor;
            triangle.OutlineStyle.Thickness = thickness;

            var ellipse = new Ellipse(new Point(25, 25), 24, 36);
            ellipse.FillStyle.Color = fillColor;
            ellipse.OutlineStyle.Color = outlineColor;

            var groupShape = new ShapeGroup();
            groupShape.InsertShape(triangle);
            groupShape.InsertShape(ellipse, 1);

            var sw = new StringWriter();
            var canvas = new TestCanvas(sw);
            groupShape.Draw(canvas);
            var expected = new StringWriter();
            expected.WriteLine("SetFillColor #4289864226");
            expected.WriteLine("FillPolygon:\r\n(10;10)\r\n(30;10)\r\n(10;30)");
            expected.WriteLine("SetLineThickness #2");
            expected.WriteLine("SetOutlineColor #4294907027");
            expected.WriteLine("DrawLine from (10;10) to (30;10)\r\n" +
                               "DrawLine from (30;10) to (10;30)\r\nDrawLine from (10;30) to (10;10)");

            expected.WriteLine("SetFillColor #4289864226");
            expected.WriteLine("FillEllipse center (25;25) radiusX 24 radiusY 36");
            expected.WriteLine("SetLineThickness #1");
            expected.WriteLine("SetOutlineColor #4294907027");
            expected.WriteLine("Ellipse center (25;25) radiusX 24 radiusY 36");


            Assert.Equal(expected.ToString(), sw.ToString());
        }
    }
}