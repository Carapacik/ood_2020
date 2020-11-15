using System;
using Factory;
using Factory.Shapes;
using Xunit;

namespace FactoryTests
{
    public class PictureDraftTests
    {
        [Fact]
        private void AddShape_MultipleShapes_AddedShapesToPictureDraft()
        {
            var draft = new PictureDraft();
            var ellipse = new Ellipse(Color.Black, new Point(10, 10), 5, 6);
            var rectangle = new Rectangle(Color.Pink, new Point(10, 10), new Point(15, 15));

            draft.AddShape(ellipse);
            draft.AddShape(rectangle);

            Assert.Equal(2, draft.ShapeCount);
            Assert.Equal(ellipse, draft.GetShape(0));
            Assert.Equal(rectangle, draft.GetShape(1));
        }

        [Fact]
        private void GetShape_IndexOutOfRange_ThrowException()
        {
            var draft = new PictureDraft();
            var shape = new Ellipse(Color.Black, new Point(10, 10), 5, 6);

            draft.AddShape(shape);

            Assert.Equal(1, draft.ShapeCount);
            Assert.Throws<Exception>(() => draft.GetShape(1));
            Assert.Throws<Exception>(() => draft.GetShape(-1));
        }
    }
}