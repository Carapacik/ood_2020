using DocumentEditor;
using DocumentEditor.Commands;
using Xunit;

namespace DocumentEditorTests
{
    public class SetTitleTests
    {
        [Fact]
        private void ExecuteAndUnExecute_CorrectArguments_TitleRenamedAndRenamedBack()
        {
            var document = new Document();
            var prevTitle = document.Title;

            const string expectedTitle = "Next Title";

            var command = new SetTitleCommand(document, expectedTitle);

            command.Execute();
            Assert.Equal(expectedTitle, document.Title);

            command.UnExecute();
            Assert.Equal(prevTitle, document.Title);
        }
    }
}