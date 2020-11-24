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
            const string expectedTitle = "Next Title";
            var title = new Text();
            var prevTitle = title.Value;
            var command = new SetTitleCommand(title, expectedTitle);

            command.Execute();
            Assert.Equal(expectedTitle, title.Value);

            command.UnExecute();
            Assert.Equal(prevTitle, title.Value);
        }
    }
}