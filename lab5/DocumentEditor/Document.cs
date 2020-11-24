using System;
using System.Collections.Generic;
using DocumentEditor.Commands;

namespace DocumentEditor
{
    public class Document : IDocument
    {
        private readonly List<IDocumentItem> _documentItems = new List<IDocumentItem>();
        private readonly History _history = new History();
        private readonly Text _title = new Text {Value = "No title"};
        public int ItemsCount => _documentItems.Count;

        public string Title
        {
            get => _title.Value;
            set => _history.AddAndExecuteCommand(new SetTitleCommand(_title, value));
        }

        public IParagraph InsertParagraph(string text, int position = -1)
        {
            var paragraph = new Paragraph {Text = text};
            _history.AddAndExecuteCommand(new InsertItemCommand(_documentItems, paragraph, position));
            return paragraph;
        }

        public void ReplaceText(string text, int position)
        {
            if (position == -1)
                position = _documentItems.Count - 1;

            var item = _documentItems[position];
            if (!(item is Paragraph paragraph))
                throw new Exception("Invalid position for ReplaceText");
            _history.AddAndExecuteCommand(new ReplaceTextCommand(paragraph, text));
        }


        public IImage InsertImage(string path, int width, int height, int position = -1)
        {
            var image = new Image(path, width, height);
            _history.AddAndExecuteCommand(new InsertItemCommand(_documentItems, image, position));
            return image;
        }

        public void ResizeImage(int width, int height, int position)
        {
            var item = _documentItems[position];
            if (!(item is IImage image)) throw new Exception("Invalid position for ResizeImage");
            _history.AddAndExecuteCommand(new ResizeImageCommand(image, width, height));
        }

        public void DeleteItem(int position)
        {
            if (position < 0 || position > ItemsCount)
                throw new Exception($"Invalid position: {position}. Cannot delete item.");

            _history.AddAndExecuteCommand(new DeleteItemCommand(_documentItems, position));
        }

        public IDocumentItem GetItem(int index)
        {
            return _documentItems[index];
        }

        public void Redo()
        {
            _history.Redo();
        }

        public void Undo()
        {
            _history.Undo();
        }

        public void Save(string path)
        {
            DocumentSaver.Save(path, Title, _documentItems);
        }
    }
}