using DocumentEditor;
using DocumentEditor.Commands;
using Xunit;

namespace DocumentEditorTests
{
    public class ReplaceTextTests
    {
        [Fact]
        private void ExecuteAndUnExecute_CorrectArguments_ExpectedText()
        {
            const string text = "Text";
            const string nextText = "Next Text";
            var paragraph = new Paragraph {Text = text};
            var command = new ReplaceTextCommand(paragraph, nextText);

            command.Execute();
            Assert.Equal(nextText, paragraph.Text);

            command.UnExecute();
            Assert.Equal(text, paragraph.Text);
        }
    }
}