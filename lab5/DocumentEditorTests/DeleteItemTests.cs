using System;
using System.Collections.Generic;
using System.IO;
using DocumentEditor;
using DocumentEditor.Commands;
using Xunit;

namespace DocumentEditorTests
{
    public class DeleteItemTests
    {
        [Fact]
        private void ExecuteAndUnExecute_ListWithOneItem_ListReturnsToInitialState()
        {
            var paragraph = new Paragraph {Text = "text"};
            var items = new List<IDocumentItem> {paragraph};
            var deleteItemCommand = new DeleteItemCommand(items, 0);

            deleteItemCommand.Execute();
            Assert.Empty(items);

            deleteItemCommand.UnExecute();
            Assert.Equal(new List<IDocumentItem> {paragraph}, items);
        }

        [Fact]
        private void ExecuteAndUnExecute_ListWithMultipleValues_CorrectElementIsDeleted()
        {
            var one = new Paragraph {Text = "one"};
            var two = new Paragraph {Text = "two"};
            var paragraph = new Paragraph {Text = "text"};
            var items = new List<IDocumentItem> {one, two, paragraph};
            var deleteItemCommand = new DeleteItemCommand(items, 2);

            deleteItemCommand.Execute();
            Assert.Equal(new List<IDocumentItem> {one, two}, items);

            deleteItemCommand.UnExecute();
            Assert.Equal(new List<IDocumentItem> {one, two, paragraph}, items);
        }

        [Fact]
        private void ExecuteAndUnExecute_EmptyList_ExceptionIsThrown()
        {
            var items = new List<IDocumentItem>();

            Assert.Throws<Exception>(() => new DeleteItemCommand(items, 0));
        }

        [Fact]
        private void ExecuteAndUnExecute_ListWithImage_ImageDeletedAfterDispose()
        {
            var image = new Image("1.png", 300, 300);
            var items = new List<IDocumentItem> {image};
            using (var command = new DeleteItemCommand(items, 0))
            {
                command.Execute();

                Assert.True(File.Exists(image.Path));
                Assert.Empty(items);
            }

            Assert.False(File.Exists(image.Path));

            image.Delete();
        }
    }
}