using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DocumentEditor
{
    public static class DocumentSaver
    {
        private static readonly List<Tuple<string, string>> Symbols = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("&", "&amp;"),
            new Tuple<string, string>("<", "&lt;"),
            new Tuple<string, string>(">", "&gt;"),
            new Tuple<string, string>("'", "&apos;"),
            new Tuple<string, string>("\"", "&quot;")
        };

        public static void Save(string path, string title, List<IDocumentItem> documentItems)
        {
            using var sw = new StreamWriter(path);
            sw.WriteLine("<!DOCTYPE html>");
            sw.WriteLine("<html>");
            sw.WriteLine("  <head>");
            sw.WriteLine($"    <title>{ConvertToHtmlSymbols(title)}</title>");
            sw.WriteLine("  </head>");
            sw.WriteLine("  <body>");
            sw.Write(CreateBody(path, documentItems));
            sw.WriteLine("  </body>");
            sw.WriteLine("</html>");
        }

        private static string CreateBody(string path, List<IDocumentItem> documentItems)
        {
            var str = "";
            foreach (var item in documentItems)
                switch (item)
                {
                    case IImage image:
                    {
                        var dirName = Path.Combine(Path.GetDirectoryName(path), "images");
                        var newPath = Path.Combine(dirName, Path.GetFileName(image.Path));
                        if (!Directory.Exists(dirName))
                            Directory.CreateDirectory(dirName);

                        File.Copy(image.Path, newPath, true);
                        str += $"  <img src=\"{newPath}\" width=\"{image.Width}\" height=\"{image.Height}\"/>\r\n";
                        break;
                    }
                    case IParagraph paragraph:
                        str += $"  <p>{ConvertToHtmlSymbols(paragraph.Text)}</p>\r\n";
                        break;
                }

            return str;
        }

        private static string ConvertToHtmlSymbols(string str)
        {
            if (str != null)
                str = Symbols.Aggregate(str, (current, symbol) => current.Replace(symbol.Item1, symbol.Item2));
            return str;
        }
    }
}