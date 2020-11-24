using System.IO;
using Xunit;

namespace DocumentEditorTests
{
    public class DocumentEditorTests
    {
        [Fact]
        public void DeleteItem_WithIncorrectArgsCount_PrintErrorMessage()
        {
            const string command = "delete\n";
            var sr = new StringReader(command);
            var sw = new StringWriter();
            var editor = new DocumentEditor.DocumentEditor(sw, sr);
            editor.Start();
            const string expected = "Not enough arguments\r\n";
            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void DeleteItem_WithCorrectArgsCount_DeleteItemFromDocument()
        {
            const string command = "insertParagraph 0 papyrus\ndelete 0\n";
            var sr = new StringReader(command);
            var sw = new StringWriter();
            var editor = new DocumentEditor.DocumentEditor(sw, sr);
            editor.Start();
            const string expected = "";
            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void InsertParagraph_WithIncorrectArgsCount_PrintErrorMessage()
        {
            const string command1 = "insertParagraph\n";
            var sr1 = new StringReader(command1);
            var sw1 = new StringWriter();
            var editor1 = new DocumentEditor.DocumentEditor(sw1, sr1);
            editor1.Start();
            const string expected1 = "Not enough arguments\r\n";
            Assert.Equal(expected1, sw1.ToString());

            const string command2 = "insertParagraph 1\n";
            var sr2 = new StringReader(command2);
            var sw2 = new StringWriter();
            var editor2 = new DocumentEditor.DocumentEditor(sw2, sr2);
            editor2.Start();
            const string expected2 = "Not enough arguments\r\n";
            Assert.Equal(expected2, sw2.ToString());
        }

        [Fact]
        public void InsertParagraph_WithCorrectArgsCount_InsertParagraphToDocument()
        {
            const string command = "insertParagraph 0 papyrus\ninsertParagraph end left side\n";
            var sr = new StringReader(command);
            var sw = new StringWriter();
            var editor = new DocumentEditor.DocumentEditor(sw, sr);
            editor.Start();
            const string expected = "";
            Assert.Equal(expected, sw.ToString());
        }


        [Fact]
        public void ReplaceText_WithIncorrectArgsCount_PrintErrorMessage()
        {
            const string expected = "Not enough arguments\r\n";
            const string command1 = "insertParagraph 0 papyrus\nreplaceText";
            var sr1 = new StringReader(command1);
            var sw1 = new StringWriter();
            var editor1 = new DocumentEditor.DocumentEditor(sw1, sr1);
            editor1.Start();
            Assert.Equal(expected, sw1.ToString());

            const string command2 = "insertParagraph 0 papyrus\nreplaceText 0";
            var sr2 = new StringReader(command2);
            var sw2 = new StringWriter();
            var editor2 = new DocumentEditor.DocumentEditor(sw2, sr2);
            editor2.Start();
            Assert.Equal(expected, sw2.ToString());
        }

        [Fact]
        public void ReplaceText_WithCorrectArgsCount_ReplaceTextInParagraph()
        {
            const string command = "insertParagraph 0 papyrus\nreplaceText 0 paper\n";
            var sr = new StringReader(command);
            var sw = new StringWriter();
            var editor = new DocumentEditor.DocumentEditor(sw, sr);
            editor.Start();
            const string expected = "";
            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void InsertImage_WithIncorrectArgsCount_PrintErrorMessage()
        {
            const string expected = "Not enough arguments\r\n";
            const string command1 = "insertImage\n";
            var sr1 = new StringReader(command1);
            var sw1 = new StringWriter();
            var editor1 = new DocumentEditor.DocumentEditor(sw1, sr1);
            editor1.Start();
            Assert.Equal(expected, sw1.ToString());

            const string command2 = "insertImage 0\n";
            var sr2 = new StringReader(command2);
            var sw2 = new StringWriter();
            var editor2 = new DocumentEditor.DocumentEditor(sw2, sr2);
            editor2.Start();
            Assert.Equal(expected, sw2.ToString());

            const string command3 = "insertImage 0 200\n";
            var sr3 = new StringReader(command3);
            var sw3 = new StringWriter();
            var editor3 = new DocumentEditor.DocumentEditor(sw3, sr3);
            editor3.Start();
            Assert.Equal(expected, sw3.ToString());

            const string command4 = "insertImage 0 200 200\n";
            var sr4 = new StringReader(command4);
            var sw4 = new StringWriter();
            var editor4 = new DocumentEditor.DocumentEditor(sw4, sr4);
            editor4.Start();
            Assert.Equal(expected, sw4.ToString());
        }

        [Fact]
        public void InsertImage_WithCorrectArgsCount_InsertImageInDocument()
        {
            const string command = "insertImage 0 200 200 1.png\n";
            var sr = new StringReader(command);
            var sw = new StringWriter();
            var editor = new DocumentEditor.DocumentEditor(sw, sr);
            editor.Start();
            const string expected = "";
            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void ResizeImage_WithIncorrectArgsCount_PrintErrorMessage()
        {
            const string expected = "Not enough arguments\r\n";
            const string command1 = "insertImage 0 200 200 1.png\nresizeImage\n";
            var sr1 = new StringReader(command1);
            var sw1 = new StringWriter();
            var editor1 = new DocumentEditor.DocumentEditor(sw1, sr1);
            editor1.Start();
            Assert.Equal(expected, sw1.ToString());

            const string command2 = "insertImage 0 200 200 1.png\nresizeImage 0\n";
            var sr2 = new StringReader(command2);
            var sw2 = new StringWriter();
            var editor2 = new DocumentEditor.DocumentEditor(sw2, sr2);
            editor2.Start();
            Assert.Equal(expected, sw2.ToString());

            const string command3 = "insertImage 0 200 200 1.png\nresizeImage 0 100\n";
            var sr3 = new StringReader(command3);
            var sw3 = new StringWriter();
            var editor3 = new DocumentEditor.DocumentEditor(sw3, sr3);
            editor3.Start();
            Assert.Equal(expected, sw3.ToString());
        }

        [Fact]
        public void ResizeImage_WithCorrectArgsCount_ResizeImageInDocument()
        {
            const string command = "insertImage 0 200 200 1.png\nresizeImage 0 300 400\n";
            var sr = new StringReader(command);
            var sw = new StringWriter();
            var editor = new DocumentEditor.DocumentEditor(sw, sr);
            editor.Start();
            const string expected = "";
            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void ShowList_PrintListOfItemsInDocument()
        {
            const string command =
                "setTitle paper\ninsertParagraph 0 papyrus\ninsertImage end 200 200 1.png\nlist";
            var sr = new StringReader(command);
            var sw = new StringWriter();
            var editor = new DocumentEditor.DocumentEditor(sw, sr);
            editor.Start();
            const string expected = "paper\r\n[0] Paragraph: papyrus\r\n[1] Image: 1.png\r\n";
            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void Undo_UndoExecuted()
        {
            const string command = "setTitle am\nundo\nlist";
            var sr = new StringReader(command);
            var sw = new StringWriter();
            var editor = new DocumentEditor.DocumentEditor(sw, sr);
            editor.Start();
            const string expected = "No title\r\n";
            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void Redo_RedoExecutedAfterUndo()
        {
            const string command = "setTitle am\nundo\nredo\nlist";
            var sr = new StringReader(command);
            var sw = new StringWriter();
            var editor = new DocumentEditor.DocumentEditor(sw, sr);
            editor.Start();
            const string expected = "am\r\n";
            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void Exit_StoppingProgram()
        {
            const string command = "setTitle am\nlist\nexit";
            var sr = new StringReader(command);
            var sw = new StringWriter();
            var editor = new DocumentEditor.DocumentEditor(sw, sr);
            editor.Start();
            const string expected = "am\r\n";
            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        private void Save_IncorrectArgsCount_PrintErrorMessage()
        {
            const string command = "save";
            var sr = new StringReader(command);
            var sw = new StringWriter();
            var editor = new DocumentEditor.DocumentEditor(sw, sr);
            editor.Start();

            const string expected = "Not enough arguments\r\n";
            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        private void Save_CorrectArgsCount_SaveDocumentToPath()
        {
            var path = Directory.GetCurrentDirectory() + "\\index.html";
            var command = $"save {path}";
            var sr = new StringReader(command);
            var sw = new StringWriter();
            var editor = new DocumentEditor.DocumentEditor(sw, sr);
            editor.Start();
            const string expected = "";

            Assert.Equal(expected, sw.ToString());
            Assert.True(File.Exists(path));

            File.Delete(path);
        }
    }
}