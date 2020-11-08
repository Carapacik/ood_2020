using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DocumentEditor
{
    public class DocumentSaver
    {
        private readonly List<IDocumentItem> _documentItems;

        private readonly List<Tuple<string, string>> _symbols = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("&", "&amp;"),
            new Tuple<string, string>("<", "&lt;"),
            new Tuple<string, string>(">", "&gt;"),
            new Tuple<string, string>("'", "&apos;"),
            new Tuple<string, string>("\"", "&quot;")
        };

        public DocumentSaver(List<IDocumentItem> documentItems)
        {
            _documentItems = documentItems;
        }

        public void Save(string path, string title)
        {
            using var sw = new StreamWriter(path);
            sw.WriteLine("<!DOCTYPE html>");
            sw.WriteLine("<html>");
            sw.WriteLine("  <head>");
            sw.WriteLine($"    <title>{title}</title>");
            sw.WriteLine("  </head>");
            sw.WriteLine("  <body>");
            sw.Write(CreateBody(path));
            sw.WriteLine("  </body>");
            sw.WriteLine("</html>");
        }

        private string CreateBody(string path)
        {
            var str = "";
            foreach (var item in _documentItems)
                switch (item)
                {
                    case IImage image:
                    {
                        var dirName = Path.Combine(Path.GetDirectoryName(path), "images");
                        var newPath = Path.Combine(dirName, Path.GetFileName(image.Path));
                        if (!Directory.Exists(dirName))
                            Directory.CreateDirectory(dirName);

                        File.Copy(image.Path, newPath, true);
                        str += $"\t<img src=\"{newPath}\" width=\"{image.Width}\" height=\"{image.Height}\"\n";
                        break;
                    }
                    case IParagraph paragraph:
                        str += $"\t<p>{ConvertHtmlSymbols(paragraph.Text)}</p>\n";
                        break;
                }

            return str;
        }

        private string ConvertHtmlSymbols(string str)
        {
            if (str != null)
                str = _symbols.Aggregate(str, (current, symbol) => current.Replace(symbol.Item1, symbol.Item2));
            return str;
        }
    }
}