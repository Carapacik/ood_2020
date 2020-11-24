using System.Collections.Generic;
using System.IO;
using DocumentEditor;
using Xunit;

namespace DocumentEditorTests
{
    public class DocumentSaverTests
    {
        [Fact]
        private void Save_WithCorrectArguments_()
        {
            var documentItems = new List<IDocumentItem> {new Paragraph {Text = "test\"s\""}};

            const string file1 = "file1.html";
            var expected = new StreamWriter(file1);
            expected.WriteLine("<!DOCTYPE html>");
            expected.WriteLine("<html>");
            expected.WriteLine("  <head>");
            expected.WriteLine("    <title>&amp;&apos;file&lt;</title>");
            expected.WriteLine("  </head>");
            expected.WriteLine("  <body>");
            expected.WriteLine("  <p>test&quot;s&quot;</p>");
            expected.WriteLine("  </body>");
            expected.WriteLine("</html>");
            expected.Close();

            const string title = "&'file<";
            const string file2 = "file2.html";
            DocumentSaver.Save(file2, title, documentItems);
            Assert.Equal(File.ReadAllText(file1), File.ReadAllText(file2));
        }
    }
}