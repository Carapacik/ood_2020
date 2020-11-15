using System.IO;
using Factory;
using Factory.Shapes;
using Xunit;

namespace FactoryTests
{
    public class DesignerTests
    {
        [Fact]
        private void CreateDraft_StreamWithCorrectShape_DraftCreated()
        {
            var inputStream =
                new StringReader("rectangle blue 250 250 500 400\r\ntriangle black 249 249 375 100 499 249");
            var designer = new Designer(new ShapeFactory());
            var draft = designer.CreateDraft(inputStream);

            Assert.Equal(2, draft.ShapeCount);
            Assert.IsType<Rectangle>(draft.GetShape(0));
            Assert.IsType<Triangle>(draft.GetShape(1));
        }

        [Fact]
        private void CreateDraft_StreamWithIncorrectShape_DraftIsCreatedWithoutInvalidShape()
        {
            var inputStream =
                new StringReader("rectangle bl 250 250 500 400\r\ntriangle black 249 249 375 100 499 249");
            var designer = new Designer(new ShapeFactory());

            var draft = designer.CreateDraft(inputStream);

            Assert.Equal(1, draft.ShapeCount);
            Assert.IsType<Triangle>(draft.GetShape(0));
        }

        [Fact]
        private void CreateDraft_EmptyStream_EmptyDraftCreated()
        {
            var inputStream = new StringReader("");
            var designer = new Designer(new ShapeFactory());

            var draft = designer.CreateDraft(inputStream);

            Assert.Equal(0, draft.ShapeCount);
        }
    }
}