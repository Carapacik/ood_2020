using System.Collections.Generic;
using DocumentEditor;
using DocumentEditor.Commands;
using Xunit;

namespace DocumentEditorTests
{
    public class InsertItemTests
    {
        [Fact]
        private void ExecuteAndUnExecute_ListWithOneItem_ListReturnsToInitialState()
        {
            var paragraph = new Paragraph {Text = "text"};
            var items = new List<IDocumentItem>();
            var insertCommand = new InsertItemCommand(items, paragraph, -1);

            insertCommand.Execute();
            Assert.Equal(new List<IDocumentItem> {paragraph}, items);

            insertCommand.UnExecute();
            Assert.Empty(items);
        }

        [Fact]
        private void ExecuteAndUnExecute_ListWithMultipleValues_InsertItemInCorrectPosition()
        {
            var a = new Paragraph {Text = "one"};
            var b = new Paragraph {Text = "two"};
            var paragraph = new Paragraph {Text = "text"};
            var items = new List<IDocumentItem> {a, b};
            var insertCommand = new InsertItemCommand(items, paragraph, 1);

            insertCommand.Execute();
            Assert.Equal(new List<IDocumentItem> {a, paragraph, b}, items);

            insertCommand.UnExecute();
            Assert.Equal(new List<IDocumentItem> {a, b}, items);
        }
    }
}