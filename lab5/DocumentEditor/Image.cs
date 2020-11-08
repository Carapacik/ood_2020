using System;
using System.Drawing;
using System.IO;

namespace DocumentEditor
{
    public class Image : IImage
    {
        private const string StoragePath = "storage";
        private readonly string _sourcePath;
        private bool _isDeleted;

        public Image(string path, int width, int height)
        {
            _sourcePath = path;
            if (!Directory.Exists(StoragePath))
                Directory.CreateDirectory(StoragePath);
            Path = System.IO.Path.Combine(StoragePath, Guid.NewGuid() + System.IO.Path.GetExtension(path));
            File.Copy(path, Path);
            Resize(width, height);
        }

        public string Path { get; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public void Resize(int width, int height)
        {
            if (_isDeleted)
                throw new Exception("Cannot access to deleted image!");
            Bitmap bitmap;
            using (var image = System.Drawing.Image.FromFile(Path))
            {
                bitmap = new Bitmap(image, width, height);
            }

            File.Delete(Path);
            bitmap.Save(Path);

            Width = width;
            Height = height;
        }

        public void Delete()
        {
            File.Delete(Path);
            _isDeleted = true;
        }

        public override string ToString()
        {
            return _sourcePath;
        }
    }
}