using System;
using DocumentEditor;
using DocumentEditor.Commands;
using Moq;
using Xunit;

namespace DocumentEditorTests
{
    public class HistoryTests
    {
        private static readonly Mock<IDocument> MockDocument = new Mock<IDocument>();

        [Fact]
        private void AddAndExecuteCommand_OneCommand_Success()
        {
            var history = new History();
            history.AddAndExecuteCommand(new SetTitleCommand(MockDocument.Object, "Title1"));

            MockDocument.VerifySet(x => x.Title = "Title1");
            Assert.True(history.CanUndo);
            Assert.False(history.CanRedo);
        }

        [Fact]
        private void AddAndExecuteCommand_ElevenCommands_RemoveFirstCommand()
        {
            var history = new History();
            for (var i = 0; i < 11; i++)
                history.AddAndExecuteCommand(new SetTitleCommand(MockDocument.Object, $"Title{i}"));

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
            var title0 = MockDocument.Object.Title;
            const string title1 = "Title1";
            const string title2 = "Title2";

            history.AddAndExecuteCommand(new SetTitleCommand(MockDocument.Object, title1));
            MockDocument.VerifySet(x => x.Title = title1);

            history.AddAndExecuteCommand(new SetTitleCommand(MockDocument.Object, title2));
            MockDocument.VerifySet(x => x.Title = title2);

            history.Undo();
            MockDocument.VerifySet(x => x.Title = title1);

            history.Undo();
            MockDocument.VerifySet(x => x.Title = title0);
            Assert.False(history.CanUndo);
            Assert.True(history.CanRedo);

            history.Redo();
            MockDocument.VerifySet(x => x.Title = title1);

            history.Redo();
            MockDocument.VerifySet(x => x.Title = title2);
            Assert.False(history.CanRedo);
            Assert.True(history.CanUndo);
        }
    }
}