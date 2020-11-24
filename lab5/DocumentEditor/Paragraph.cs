namespace DocumentEditor
{
    public class Paragraph : IParagraph
    {
        public string Text { get; set; }

        public void Delete()
        {
        }

        public override string ToString()
        {
            return Text;
        }
    }
}