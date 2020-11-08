namespace DocumentEditor
{
    public interface IImage : IDocumentItem
    {
        string Path { get; }
        int Width { get; }
        int Height { get; }
        void Resize(int width, int height);
    }
}