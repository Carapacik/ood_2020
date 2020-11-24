using System;
using DocumentEditor;
using DocumentEditor.Commands;
using Xunit;

namespace DocumentEditorTests
{
    public class HistoryTests
    {
        [Fact]
        private void AddAndExecuteCommand_OneCommand_Success()
        {
            var history = new History();
            var text = new Text {Value = "Test"};
            history.AddAndExecuteCommand(new SetTitleCommand(text, "Title1"));

            Assert.Equal("Title1", text.Value);
            Assert.True(history.CanUndo);
            Assert.False(history.CanRedo);
        }

        [Fact]
        private void AddAndExecuteCommand_ElevenCommands_RemoveFirstCommand()
        {
            var history = new History();
            var text = new Text {Value = "Test"};
            for (var i = 0; i < 11; i++)
                history.AddAndExecuteCommand(new SetTitleCommand(text, $"Title{i}"));

            for (var i = 0; i < 10; i++)
            {
                Assert.True(history.CanUndo);
                history.Undo();
            }

            Assert.False(history.CanUndo);
        }

        [Fact]
        private void UndoRedo_EmptyHistory_ExceptionThrown()
        {
            var history = new History();

            Assert.False(history.CanRedo);
            Assert.False(history.CanUndo);
            Assert.Throws<Exception>(() => history.Undo());
            Assert.Throws<Exception>(() => history.Redo());
        }

        [Fact]
        private void UndoRedo_MultiplyCommands_ExpectedOrder()
        {
            var history = new History();
            var title0 = new Text {Value = "Test"};
            const string title1 = "Title1";
            const string title2 = "Title2";

            history.AddAndExecuteCommand(new SetTitleCommand(title0, title1));
            Assert.Equal(title1, title0.Value);

            history.AddAndExecuteCommand(new SetTitleCommand(title0, title2));
            Assert.Equal(title2, title0.Value);

            history.Undo();
            Assert.Equal(title1, title0.Value);

            history.Undo();
            Assert.Equal("Test", title0.Value);
            Assert.False(history.CanUndo);
            Assert.True(history.CanRedo);

            history.Redo();
            Assert.Equal(title1, title0.Value);

            history.Redo();
            Assert.Equal(title2, title0.Value);
            Assert.False(history.CanRedo);
            Assert.True(history.CanUndo);
        }
    }
}