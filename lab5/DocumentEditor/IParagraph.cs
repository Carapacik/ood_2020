namespace DocumentEditor
{
    public interface IParagraph : IDocumentItem
    {
        string Text { get; set; }
    }
}