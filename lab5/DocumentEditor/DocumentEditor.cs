using System;
using System.IO;
using System.Linq;

namespace DocumentEditor
{
    public class DocumentEditor
    {
        private readonly IDocument _document;
        private readonly Menu _menu;
        private readonly TextWriter _textWriter;

        public DocumentEditor(TextWriter textWriter, TextReader textReader)
        {
            _textWriter = textWriter;
            _menu = new Menu(_textWriter, textReader);
            _document = new Document();
            _menu.AddItem("help", "Show help", ShowInstructions);
            _menu.AddItem("insertParagraph", "Insert paragraph <position>|end <text>", InsertParagraph);
            _menu.AddItem("insertImage", "Inserting image: <position>|end <width> <height> <path>", InsertImage);
            _menu.AddItem("replaceText", "Replace text in paragraph <position> <text>", ReplaceText);
            _menu.AddItem("resizeImage", "Resize image: <position>|end <width> <height>", ResizeImage);
            _menu.AddItem("setTitle", "Set title of document <title>", SetTitle);
            _menu.AddItem("list", "Show document as list", ShowList);
            _menu.AddItem("delete", "Delete item <position>", DeleteItem);
            _menu.AddItem("undo", "Undo command", Undo);
            _menu.AddItem("redo", "Redo command", Redo);
            _menu.AddItem("save", "Save document to html <path>", Save);
            _menu.AddItem("exit", "Exit program", Exit);
        }

        public void Start()
        {
            _menu.Run();
        }

        private void DeleteItem(string[] args)
        {
            if (args.Length < 2) throw new Exception("Not enough arguments");
            var position = args[1].ToLowerInvariant() == "end" ? -1 : int.Parse(args[1]);
            _document.DeleteItem(position);
        }

        private void InsertParagraph(string[] args)
        {
            if (args.Length < 3) throw new Exception("Not enough arguments");
            var position = args[1].ToLowerInvariant() == "end" ? -1 : int.Parse(args[1]);
            var text = string.Join(" ", args.Skip(2));
            _document.InsertParagraph(text, position);
        }

        private void InsertImage(string[] args)
        {
            if (args.Length < 5) throw new Exception("Not enough arguments");
            var position = args[1].ToLowerInvariant() == "end" ? -1 : int.Parse(args[1]);
            var width = int.Parse(args[2]);
            var height = int.Parse(args[3]);
            var path = args[4];
            _document.InsertImage(path, width, height, position);
        }

        private void ResizeImage(string[] args)
        {
            if (args.Length < 4) throw new Exception("Not enough arguments");
            var position = args[1].ToLowerInvariant() == "end" ? -1 : int.Parse(args[1]);
            var width = int.Parse(args[2]);
            var height = int.Parse(args[3]);
            _document.ResizeImage(width, height, position);
        }

        private void ReplaceText(string[] args)
        {
            if (args.Length < 3) throw new Exception("Not enough arguments");
            var position = args[1].ToLowerInvariant() == "end" ? -1 : int.Parse(args[1]);
            var text = string.Join(" ", args.Skip(2));
            _document.ReplaceText(text, position);
        }

        private void Save(string[] args)
        {
            if (args.Length < 2) throw new Exception("Not enough arguments");
            var path = args[1];
            _document.Save(path);
        }

        private void Redo(string[] args)
        {
            _document.Redo();
        }

        private void Undo(string[] args)
        {
            _document.Undo();
        }

        private void Exit(string[] args)
        {
            _menu.Exit();
        }

        private void ShowInstructions(string[] args)
        {
            _menu.ShowInstructions();
        }

        private void ShowList(string[] args)
        {
            _textWriter.WriteLine(_document.Title);
            for (var i = 0; i < _document.ItemsCount; i++)
            {
                var item = _document.GetItem(i);
                _textWriter.WriteLine($"[{i}] {item.GetType().Name}: {item}");
            }
        }

        private void SetTitle(string[] args)
        {
            if (args.Length < 2)
            {
                _textWriter.WriteLine("Not enough arguments");
            }
            else
            {
                var str = string.Join(" ", args.Skip(1).ToArray());
                _document.SetTitle(str);
            }
        }
    }
}