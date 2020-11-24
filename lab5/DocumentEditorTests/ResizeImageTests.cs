using DocumentEditor;
using DocumentEditor.Commands;
using Xunit;

namespace DocumentEditorTests
{
    public class ResizeImageTests
    {
        [Fact]
        private void ExecuteAndUnExecute_CorrectArguments_ExpectedSize()
        {
            const string pathToImage = "1.png";
            var image = new Image(pathToImage, 300, 300);

            var command = new ResizeImageCommand(image, 600, 600);

            command.Execute();
            Assert.Equal(600, image.Width);
            Assert.Equal(600, image.Height);

            command.UnExecute();
            Assert.Equal(300, image.Width);
            Assert.Equal(300, image.Height);

            image.Delete();
        }
    }
}