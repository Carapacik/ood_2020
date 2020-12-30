using Composite;
using Composite.Shapes;
using Xunit;

namespace CompositeTests
{
    public class ShapeManagerTests
    {
        [Fact]
        private void InsertShape_InsertShapesWithoutSpecifyingOnIndex_ShapesOrderInDescOrder()
        {
            var shapeManager = new ShapeManager();
            var ellipse = new Ellipse(new Point(25, 25), 25, 30);
            var rectangle = new Rectangle(new Point(50, 50), 10, 30);
            var triangle = new Triangle(new Point(10, 10), new Point(30, 10), new Point(10, 30));

            shapeManager.InsertShape(ellipse);
            shapeManager.InsertShape(rectangle);
            shapeManager.InsertShape(triangle);

            Assert.Equal(3, shapeManager.ShapesCount);
            Assert.Same(triangle, shapeManager.GetShapeByIndex(0));
            Assert.Same(rectangle, shapeManager.GetShapeByIndex(1));
            Assert.Same(ellipse, shapeManager.GetShapeByIndex(2));
        }

        [Fact]
        private void InsertShape_InsertShapesWithSpecifyingOnIndex_ShapesOrderInDirectionOrder()
        {
            var shapeManager = new ShapeManager();
            var ellipse = new Ellipse(new Point(25, 25), 25, 30);
            var rectangle = new Rectangle(new Point(50, 50), 10, 30);
            var triangle = new Triangle(new Point(10, 10), new Point(30, 10), new Point(10, 30));

            shapeManager.InsertShape(ellipse);
            shapeManager.InsertShape(rectangle, 1);
            shapeManager.InsertShape(triangle, 2);

            Assert.Equal(3, shapeManager.ShapesCount);
            Assert.Same(ellipse, shapeManager.GetShapeByIndex(0));
            Assert.Same(rectangle, shapeManager.GetShapeByIndex(1));
            Assert.Same(triangle, shapeManager.GetShapeByIndex(2));
        }

        [Fact]
        private void RemoveShapeByIndex_RemoveShapes_ShapesRemoved()
        {
            var shapeManager = new ShapeManager();
            var ellipse = new Ellipse(new Point(25, 25), 25, 30);
            var rectangle = new Rectangle(new Point(50, 50), 10, 30);
            var triangle = new Triangle(new Point(10, 10), new Point(30, 10), new Point(10, 30));
            shapeManager.InsertShape(ellipse);
            shapeManager.InsertShape(rectangle);
            shapeManager.InsertShape(triangle);

            shapeManager.RemoveShapeAtIndex(0);
            shapeManager.RemoveShapeAtIndex(1);

            Assert.Equal(1, shapeManager.ShapesCount);
            Assert.Equal(rectangle, shapeManager.GetShapeByIndex(0));
        }
    }
}