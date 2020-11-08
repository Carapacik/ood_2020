using System.IO;
using DocumentEditor;
using Xunit;

namespace DocumentEditorTests
{
    public class MenuTests
    {
        [Fact]
        public void Run_WithUnknownCommand_ShouldPrintMessage()
        {
            const string commandShortcut = "unknownCommand";
            var sr = new StringReader(commandShortcut);
            var sw = new StringWriter();
            var menu = new Menu(sw, sr);

            menu.AddItem("test", "test description", s => sw.Write("execute command"));
            menu.Run();

            const string expected = "Unknown command\r\n";
            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void Run_WithEmptyCommand_ShouldPrintMessage()
        {
            const string commandShortcut = "\n";
            var sr = new StringReader(commandShortcut);
            var sw = new StringWriter();
            var menu = new Menu(sw, sr);

            menu.Run();

            const string expected = "Unknown command\r\n";
            Assert.Equal(expected, sw.ToString());
        }
    }
}