using System;
using DocumentEditor;
using Xunit;

namespace DocumentEditorTests
{
    public class DocumentTests
    {
        [Fact]
        private void SetTitle_CorrectTitle_TitleChanged()
        {
            var doc = new Document {Title = "Tilt"};


            Assert.Equal("Tilt", doc.Title);
        }

        [Fact]
        private void InsertParagraph_MultipleData_ParagraphInserted()
        {
            var doc = new Document();

            doc.InsertParagraph("hello");
            doc.InsertParagraph("world");
            doc.InsertParagraph("meme", 1);

            Assert.Equal("hello", doc.GetItem(0).ToString());
            Assert.Equal("meme", doc.GetItem(1).ToString());
            Assert.Equal("world", doc.GetItem(2).ToString());
        }

        [Fact]
        private void ReplaceText_CorrectIndex_TextReplaced()
        {
            var doc = new Document();
            doc.InsertParagraph("hello");
            doc.ReplaceText("bye", 0);
            Assert.Equal("bye", doc.GetItem(0).ToString());
        }

        [Fact]
        private void ReplaceText_InCorrectIndex_ThrowException()
        {
            var doc = new Document();
            doc.InsertParagraph("hello");
            Assert.Throws<ArgumentOutOfRangeException>(() => doc.ReplaceText("none", 1));
        }

        [Fact]
        private void ReplaceText_ReplaceInNoParagraph_ThrowException()
        {
            var doc = new Document();
            doc.InsertImage("1.png", 300, 300);
            doc.InsertParagraph("bye");

            Assert.Throws<Exception>(() => doc.ReplaceText("hello", 0));
        }

        [Fact]
        private void InsertImage_ManyImages_ImagesInsertedInCorrectOrder()
        {
            var doc = new Document();
            doc.InsertImage("1.png", 300, 300);
            doc.InsertImage("2.png", 300, 300, 0);


            Assert.Equal("2.png", doc.GetItem(0).ToString());
            Assert.Equal("1.png", doc.GetItem(1).ToString());
        }

        [Fact]
        private void ResizeImage_CorrectIndex_ImageResized()
        {
            var doc = new Document();
            doc.InsertImage("1.png", 300, 300);

            doc.ResizeImage(400, 400, 0);

            var image = (Image) doc.GetItem(0);
            Assert.Equal(400, image.Width);
            Assert.Equal(400, image.Height);
        }

        [Fact]
        private void ResizeImage_InvalidIndex_ThrowException()
        {
            var doc = new Document();
            doc.InsertImage("1.png", 300, 300);

            Assert.Throws<ArgumentOutOfRangeException>(() => doc.ResizeImage(200, 200, 1));
        }

        [Fact]
        private void ResizeImage_ResizeNoImage_ThrowException()
        {
            var doc = new Document();
            doc.InsertImage("1.png", 300, 300);
            doc.InsertParagraph("bye");

            Assert.Throws<Exception>(() => doc.ResizeImage(200, 200, 1));
        }
    }
}