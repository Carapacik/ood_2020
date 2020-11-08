namespace DocumentEditor
{
    public interface IDocument
    {
        int ItemsCount { get; }
        string Title { get; set; }
        void SetTitle(string title);
        IImage InsertImage(string path, int width, int height, int position = -1);
        void ResizeImage(int width, int height, int position);
        IParagraph InsertParagraph(string text, int position = -1);
        void ReplaceText(string text, int position);
        IDocumentItem GetItem(int index);
        void DeleteItem(int position);
        void Undo();
        void Redo();
        void Save(string path);
    }
}