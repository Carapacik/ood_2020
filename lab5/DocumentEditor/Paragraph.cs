using System;

namespace DocumentEditor
{
    public class Paragraph : IParagraph
    {
        public string Text { get; set; }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Text;
        }
    }
}